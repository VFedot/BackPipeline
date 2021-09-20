using KudosShop.Repository;
using KudosShop.Models;
using KudosShop.Services;
using KudosShop.Models;
using KudosShop.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudosShop.Repository.Interfaces;


namespace KudosShop.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public Response PesonToPersonTransaction(int senderId, int receiverId, int kudosAmount, string reason)
        {

            using (kudosshopContext context = new kudosshopContext())
            {
                Response responsebuilder = new Response();
                var resp = responsebuilder.ResponseBuild(0);




                var transaction = new Transaction();
                transaction.SendersId = senderId;
                transaction.ReceiverId = receiverId;
                transaction.TransactionType = 1;
                transaction.TransactionDate = DateTime.Now;
                transaction.Amount = kudosAmount;
                transaction.Reason = reason;
                context.Transactions.Add(transaction);
                context.SaveChanges();


                return resp;
            }

        }
        public Response SendKudosFromVisma(int id, int ammount, string reason)
        {
            using (var context = new kudosshopContext())
            {
                Response responsebuilder = new Response();
                var resp = responsebuilder.ResponseBuild(0);

                var transaction = new Transaction();
                transaction.SendersId = 1;
                transaction.ReceiverId = id;
                transaction.TransactionType = 2;
                transaction.TransactionDate = DateTime.Now;
                transaction.Amount = ammount;
                transaction.Reason = reason;
                context.Transactions.Add(transaction);
                context.SaveChanges();

                return resp;
            }
        }


        public IEnumerable<Transaction> GetUsersHistoryLog(int id)
        {
            using (var context = new kudosshopContext())
            {
                IEnumerable<Transaction> result = context.Transactions.Where(x => x.ReceiverId == id || x.SendersId == id).ToList();
                return result;

            }

        }

        public Response RegisterPurchase(int userId, int productId)
        {

            ProductValidation productVal = new ProductValidation();
            using (var context = new kudosshopContext())
            {
                Response responsebuilder = new Response();
                var resp = responsebuilder.ResponseBuild(0);

                var product = context.Products.FirstOrDefault(s => s.ProductId == productId);
                var transaction = new Transaction();
                transaction.SendersId = userId;
                transaction.ReceiverId = 1;
                transaction.TransactionType = 2;
                transaction.TransactionDate = DateTime.Now;
                transaction.ProductId = product.ProductId;
                transaction.Amount = product.ProductPrice;
                transaction.Reason = "Purchase of " + product.ProductName.ToString();
                context.Transactions.Add(transaction);
                context.SaveChanges();

                return resp;
            }
        }



    }
}
