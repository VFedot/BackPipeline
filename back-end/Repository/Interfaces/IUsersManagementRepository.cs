using KudosShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KudosShop.Repository.Interfaces
{
    public interface IUsersManagementRepository
    {

        public Response AddUser(User user);
        public Response EditUser(User user);
        public Response DeleteUser(int userId);
        public Kudos CheckUserBalance(int id);
        public User GetUserById(int userId);
        public IEnumerable<UserKudosInfo> GetAllUsers();

    }
}
