using KudosShop.Models;
using KudosShop.Services;
using KudosShop.Services.Interfaces;
using KudosShop.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RegisterPurchaseController : Controller
    {

        private readonly ITransactionService _transactionService;
        private readonly IUsersManagementService _usersManagementService;
        private readonly IProductServices _productServices;

        public RegisterPurchaseController(ITransactionService transactionService, IUsersManagementService usersManagementService, IProductServices productServices)
        {
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            _usersManagementService = usersManagementService ?? throw new ArgumentNullException(nameof(usersManagementService));
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
        }

        [HttpPost]
        public Response RegisterPurchase(RegisterPurchaseRequest registerPurchaseRequest)
        {
            try
            {
                VismaToPersonTransactionValidation validCheck = new VismaToPersonTransactionValidation();
                ProductValidation validCheckProduct = new ProductValidation();
                var validationResultProduct = validCheckProduct.CheckValidation(_productServices.GetProductById(registerPurchaseRequest.ProductId));
                var validationResult = validCheck.CheckValidation(_usersManagementService.GetUserById(registerPurchaseRequest.UserId));
                if (validationResult.Code == 0)
                {
                    if (validationResultProduct.Code == 0)
                    {
                        return _transactionService.RegisterPurchase(registerPurchaseRequest.UserId, registerPurchaseRequest.ProductId);
                    }
                    return validationResultProduct;
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
