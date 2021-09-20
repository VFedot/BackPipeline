using KudosShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        public Response PesonToPersonTransaction(int senderId, int receiverId, int kudosAmount, string reason);

        public Response SendKudosFromVisma(int id, int ammount, string reason);
        public IEnumerable<Transaction> GetUsersHistoryLog(int id);

        public Response RegisterPurchase(int userId, int purchaseId);

    }
}
