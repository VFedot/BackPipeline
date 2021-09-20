using KudosShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Services.Interfaces
{
    public interface IUserService
    {
        Kudos CheckUserBalance(int id);
        IEnumerable<User> GetAllUsers();

    }
}
