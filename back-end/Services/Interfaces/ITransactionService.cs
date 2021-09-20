using KudosShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Services.Interfaces
{
    public interface ITransactionService
    {
        Response PesonToPersonTransaction(int senderId, int receiverId, int kudosAmount, string reason);
        Response SendKudosFromVisma(int id, int ammount, string reason);
        IEnumerable<Transaction> GetUsersHistoryLog(int id);
        Response RegisterPurchase(int userId, int  purchaseId);

    }
}
