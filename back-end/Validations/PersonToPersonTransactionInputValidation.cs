using KudosShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Validations
{
    public class PersonToPersonTransactionInputValidation
    {
        public Response CheckValidation(User sender, User receiver, int kudosAmount)
        {
            Response response = new Response();



            if (sender == null)
            {
                return response.ResponseBuild(1);
            }
            else if (receiver == null)
            {
                return response.ResponseBuild(2);
            }
            else if (receiver.UserId == sender.UserId)
            {
                return response.ResponseBuild(6);
            }
            else if (kudosAmount < 0)
            {
                return response.ResponseBuild(4);
            }

            return response.ResponseBuild(0);
        }
    }
}
