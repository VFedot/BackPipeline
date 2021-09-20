using KudosShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using KudosShop.Services;
using KudosShop.Services.Interfaces;
using KudosShop.Validations;

namespace KudosShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KudosFromVismaController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IUsersManagementService _usersManagementService;

        public KudosFromVismaController(ITransactionService transactionService, IUsersManagementService usersManagementService)
        {
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            _usersManagementService = usersManagementService ?? throw new ArgumentNullException(nameof(usersManagementService));
        }
        [HttpPost]

        public ActionResult KudosFromVismaPostRequest(KudosFromVismaObject kudosFromVismaObject)
        {
            try
            {
                VismaToPersonTransactionValidation validCheck = new VismaToPersonTransactionValidation();
                var validationResult = validCheck.CheckValidation(_usersManagementService.GetUserById(kudosFromVismaObject.userId));
                if (validationResult.Code == 0)
                {
                    return Ok(_transactionService.SendKudosFromVisma(kudosFromVismaObject.userId, kudosFromVismaObject.kudosAmount, kudosFromVismaObject.reason));
                }
                return BadRequest("INVALID ID");

            }
            catch (Exception e)
            {     
                return BadRequest("INVALID ID");
            }

        }

    }
}
