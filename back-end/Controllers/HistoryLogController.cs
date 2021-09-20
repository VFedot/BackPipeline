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

    public class UsersHistoryLogController : Controller
    {

        private readonly ITransactionService _transactionService;

        public UsersHistoryLogController(ITransactionService transactionService)
        {
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }

        [HttpGet("{id}")]
        public IActionResult GetUsersHistoryLog(int id)
        {
            IEnumerable<Transaction>  allTransactions = _transactionService.GetUsersHistoryLog(id);
            return Ok(allTransactions);
        }

    }

}
