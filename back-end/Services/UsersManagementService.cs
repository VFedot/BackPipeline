using KudosShop.Models;
using KudosShop.Repository.Interfaces;
using KudosShop.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace KudosShop.Services
{
    public class UsersManagementService : IUsersManagementService
    {

        private readonly IUsersManagementRepository _userManagementRepository;

        public UsersManagementService(IUsersManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository ?? throw new ArgumentNullException(nameof(userManagementRepository));
        }

        public Response AddUser(User user)
        {
            return _userManagementRepository.AddUser(user);
        }

        public Response EditUser(User user)
        {
            Response response = new Response();
            var result = _userManagementRepository.CheckUserBalance(user.UserId);
            if (result == null)
            {
                return response.ResponseBuild(3);
            }
            return _userManagementRepository.EditUser(user);
        }

        public Response DeleteUser(int userId)
        {
            Response response = new Response();
            var result = _userManagementRepository.CheckUserBalance(userId);
            if (result == null)
            {
                return response.ResponseBuild(3);
            }
            return _userManagementRepository.DeleteUser(userId);
        }

        public Kudos CheckUserBalance(int id)
        {
            return _userManagementRepository.CheckUserBalance(id);
        }

        public IEnumerable<UserKudosInfo> GetAllUsers()
        {
            return _userManagementRepository.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return _userManagementRepository.GetUserById(userId);
        }
    }
}
