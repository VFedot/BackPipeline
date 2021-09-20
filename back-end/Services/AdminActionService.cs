using KudosShop.Repository;
using KudosShop.Models;
using KudosShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudosShop.Repository.Interfaces;

namespace KudosShop.Services
{
    public class AdminActionService : IAdminActionService
    {
        private readonly IAdminActionRepository _adminActionRepository;

        public AdminActionService(IAdminActionRepository adminActionRepository)
        {
            _adminActionRepository = adminActionRepository ?? throw new ArgumentNullException(nameof(adminActionRepository));
        }

        public IEnumerable<AdminAction> GetAdminsHistoryLog()
        {
            return _adminActionRepository.GetAdminsHistoryLog();
        }
    }
}
