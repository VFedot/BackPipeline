using KudosShop.Models;
using KudosShop.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace KudosShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using (var context = new kudosshopContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProductById(int productId)
        {
            using (var context = new kudosshopContext())
            {
                return context.Products.FirstOrDefault<Product>(s => s.ProductId == productId);
            }

        }
    }
}
