using KudosShop.Models;
using KudosShop.Repository.Interfaces;
using KudosShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Services
{
    public class ProductService: IProductServices
    {
        private readonly IProductRepository _product;
        public ProductService(IProductRepository productRepository)
        {
            _product = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _product.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            return _product.GetProductById(productId);
        }
    }
}
