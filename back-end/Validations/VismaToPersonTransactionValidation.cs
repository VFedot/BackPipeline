using KudosShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Validations
{
    public class VismaToPersonTransactionValidation
    {
        public Response CheckValidation(User sender)
        {
            Response response = new Response();


            if (sender == null)
            {
                return response.ResponseBuild(3);
            }
            return response.ResponseBuild(0);
        }
    }
}
