using KudosShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Validations
{
    public class ProductValidation
    {
        public Response CheckValidation(Product product)
        {
            Response response = new Response();


            if (product == null)
            {
                return response.ResponseBuild(7);
            }
            else if (product.ProductIsAvailable == false)
            {
                return response.ResponseBuild(8);
            }
            return response.ResponseBuild(0);
        }
    }
}
