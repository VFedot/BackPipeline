using KudosShop.Models;
using System.Collections.Generic;

namespace KudosShop.Repository.Interfaces
{
    public interface IKudosRepository
    {
        public Kudos CheckUserBalance(int id);
        public IEnumerable<User> GetAllUsers();

    }
}
