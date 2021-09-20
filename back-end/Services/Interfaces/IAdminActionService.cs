using KudosShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Services.Interfaces
{
    public interface IAdminActionService
    {
        public IEnumerable<AdminAction> GetAdminsHistoryLog();
    }
}
