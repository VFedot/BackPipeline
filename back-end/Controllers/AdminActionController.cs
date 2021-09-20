using KudosShop.Models;
using KudosShop.Services;
using KudosShop.Services.Interfaces;
using KudosShop.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KudosShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AdminActionHistoryLogController : Controller
    {

        private readonly IAdminActionService _adminActionService;

        public AdminActionHistoryLogController(IAdminActionService adminActionService)
        {
            _adminActionService = adminActionService ?? throw new ArgumentNullException(nameof(adminActionService));
        }
        
        [HttpGet]
        public IActionResult GetAdminsHistoryLog()
        {
            IEnumerable<AdminAction> result = _adminActionService.GetAdminsHistoryLog();
            return Ok(result);
        }

    }

}
