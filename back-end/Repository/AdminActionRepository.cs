using KudosShop.Models;
using KudosShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Repository
{
    public class AdminActionRepository : IAdminActionRepository
    {
        public IEnumerable<AdminAction> GetAdminsHistoryLog()
        {
            using (var context = new kudosshopContext())
            {
                IEnumerable<AdminAction> result = context.AdminActions.ToList();
                return result;
            }
                
        }
    }
}
