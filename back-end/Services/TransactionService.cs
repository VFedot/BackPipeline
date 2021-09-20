using KudosShop.Models;
using System;
using KudosShop.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudosShop.Services.Interfaces;
using KudosShop.Repository.Interfaces;

namespace KudosShop.Services
{
    public class TransactionService : ITransactionService
    {
    
        private readonly ITransactionRepository _transaction;
        public TransactionService(ITransactionRepository transactonsRepository)
        {
            _transaction = transactonsRepository ?? throw new ArgumentNullException(nameof(transactonsRepository));
        }
        public Response SendKudosFromVisma(int id, int ammount, string reason)
        {
            return _transaction.SendKudosFromVisma(id,ammount,reason);
        }
        
        public Response PesonToPersonTransaction(int senderId, int receiverId, int kudosAmount, string reason) {

            return _transaction.PesonToPersonTransaction(senderId, receiverId, kudosAmount, reason);

        }
        public Response RegisterPurchase(int userId, int purchaseId)
        {

            return _transaction.RegisterPurchase(userId, purchaseId);

        }


        public IEnumerable<Transaction> GetUsersHistoryLog(int id)
        {
            return _transaction.GetUsersHistoryLog(id);
        }

    }
}
