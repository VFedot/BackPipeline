using KudosShop.Models;
using KudosShop.Services;
using KudosShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace KudosShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly IUsersManagementService _userService;

        public UsersController(IUsersManagementService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof (userService));
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = _userService.GetAllUsers().Where(user => user.UserId > 1 && user.UserType != 3);
            if (!allUsers.Any())
            {
                return BadRequest("NO USERS");
            }

            return Ok(allUsers);
        }
       
        [HttpGet("getkudos/{id}")]
        public IActionResult GetKudos(int id)
        {
            if (id < 0 )
            {
                return BadRequest("INVALID ID");
            }
            var result = _userService.CheckUserBalance(id);
            if (result == null) return BadRequest("INVALID ID");
            return Ok(result);
        }

        [HttpPost("add")]
        public ActionResult CreateUser(UserManagementObject UMO)
        {
            Response response = new Response();

            if (string.IsNullOrEmpty(UMO.userName) || string.IsNullOrEmpty(UMO.userSurname))
            {
                return BadRequest(response.ResponseBuild(9));
            }
            User user = new User
            {
                UserName = UMO.userName,
                UserSurname = UMO.userSurname,
                UserType = UMO.userType
            };

            return Ok(_userService.AddUser(user));
        }

        [HttpPut("edit")]
        public ActionResult EditUser(UserManagementObject UMO)
        {

            Response response = new Response();

            if (string.IsNullOrEmpty(UMO.userName) || string.IsNullOrEmpty(UMO.userSurname))
            {
                return BadRequest(response.ResponseBuild(9));
            }

            User user = new User
            {
                UserId = UMO.userId,
                UserName = UMO.userName,
                UserSurname = UMO.userSurname,
                UserType = UMO.userType
            };

            return Ok(_userService.EditUser(user));
        }

        [HttpDelete("delete")]
        public ActionResult DeleteUser(int userId)
        {
            Response response = new Response();
            if (userId < 2) return BadRequest(response.ResponseBuild(3));

            return Ok(_userService.DeleteUser(userId));
        }
    }
}
