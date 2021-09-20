using KudosShop.Models;
using KudosShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace KudosShop.Repository
{
    public class KudosRepository : IKudosRepository
    {
        public Kudos CheckUserBalance(int id)
        {
            using (var context = new kudosshopContext())
            {
                var users = context.Users;
                var transactions = context.Transactions;
                var totalReceive = transactions.Where(transactions => transactions.ReceiverId == id).Sum(transactions => transactions.Amount);
                var totalSend = transactions.Where(transactions => transactions.SendersId == id).Sum(transactions => transactions.Amount);

                var sum = totalReceive - totalSend;
                var user = users.FirstOrDefault(user => user.UserId == id);

                if (user == null) return new Kudos();

                return new Kudos
                {
                    KudosAmount = sum,
                    Name = user.UserName,
                    Surname = user.UserSurname
                };
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var context = new kudosshopContext())
            {
                return context.Users.ToList();
            }
        }
    }
}
