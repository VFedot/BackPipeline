using KudosShop.Services;
using KudosShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopItemsController : Controller
    {

        private readonly IProductServices _productService;

        public ShopItemsController(IProductServices productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var allProducts = _productService.GetAllProducts();
            if (!allProducts.Any())
            {
                return BadRequest("NO PRODUCTS");
            }
            return Ok(allProducts);
        }
    }
}
