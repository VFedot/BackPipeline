using KudosShop.Models;
using System.Collections.Generic;

namespace KudosShop.Services.Interfaces
{
    public interface IUsersManagementService
    {
        public Response AddUser(User user);
        public Response EditUser(User user);
        public Response DeleteUser(int userId);
        Kudos CheckUserBalance(int id);
        public User GetUserById(int userId);
        IEnumerable<UserKudosInfo> GetAllUsers();
    }
}
