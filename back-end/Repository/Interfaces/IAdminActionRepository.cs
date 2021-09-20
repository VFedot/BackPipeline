using KudosShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace KudosShop.Repository.Interfaces
{
    public interface IAdminActionRepository
    {
        public IEnumerable<AdminAction> GetAdminsHistoryLog();
    }
}
