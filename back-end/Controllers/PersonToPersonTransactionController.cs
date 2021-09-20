using KudosShop.Models;
using KudosShop.Services;
using KudosShop.Services.Interfaces;
using KudosShop.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace KudosShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PersonToPersonTransactionController : Controller
    {

        private readonly ITransactionService _transactionService;
        private readonly IUsersManagementService _usersManagementService;

        public PersonToPersonTransactionController(ITransactionService transactionService, IUsersManagementService usersManagementService)
        {
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            _usersManagementService = usersManagementService ?? throw new ArgumentNullException(nameof(usersManagementService));
        }

        [HttpPost]
        public Response PesonToPersonTransaction(PersonToPersonObject PTP)
        {
            
            try
            {
                PersonToPersonTransactionInputValidation validCheck = new PersonToPersonTransactionInputValidation();
                var validationResult = validCheck.CheckValidation(_usersManagementService.GetUserById(PTP.senderId), _usersManagementService.GetUserById(PTP.receiverId), PTP.kudosAmount);
                if (validationResult.Code == 0){
                    return _transactionService.PesonToPersonTransaction(PTP.senderId, PTP.receiverId, PTP.kudosAmount, PTP.reason);
                }
                return validationResult;
                
            }
            catch (Exception e)
            {
                Response resp = new Response();
                return resp.ResponseBuild(10);
            }
            
        }

    }

}
