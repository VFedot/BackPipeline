using KudosShop.Models;
using KudosShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace KudosShop.Repository
{
    public class UsersManagementRepository : IUsersManagementRepository
    {
        public Response AddUser(User user)
        {

            Response response = new Response();
            using (var context = new kudosshopContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                
            }
            return response.ResponseBuild(0);
        }

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

                if (user == null) return null;

                return new Kudos
                {
                    KudosAmount = sum,
                    Name = user.UserName,
                    Surname = user.UserSurname
                };
            }
        }

        public Response DeleteUser(int userId)
        {
            Response response = new Response();
            using (var context = new kudosshopContext())
            {
                var user = context.Users.FirstOrDefault(user => user.UserId == userId && user.UserType != 3);
                user.UserType = 3;
                context.Users.Update(user);
                context.SaveChanges();

            }
            return response.ResponseBuild(0);

        }

        public Response EditUser(User requestedUser)
        {
            Response response = new Response();
            using (var context = new kudosshopContext())
            {
                var newInfoUser = context.Users.FirstOrDefault(user => user.UserId == requestedUser.UserId);
                newInfoUser.UserName = requestedUser.UserName;
                newInfoUser.UserSurname = requestedUser.UserSurname;
                newInfoUser.UserType = requestedUser.UserType;
                context.Users.Update(newInfoUser);
                context.SaveChanges();

            }
            return response.ResponseBuild(0);
        }

        public IEnumerable<UserKudosInfo> GetAllUsers()
        {
            using (var context = new kudosshopContext())
            {
                return context.UserKudosInfos.ToList();
            }
        }

        public User GetUserById(int userId)
        {
            using (var context = new kudosshopContext())
            {
                return context.Users.FirstOrDefault<User>(s => s.UserId == userId);
            }

        }

    }
}
