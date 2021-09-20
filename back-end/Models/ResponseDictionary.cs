using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Models
{
    public class ResponseDictionary
    {
        public Dictionary<int, string> Codes = new Dictionary<int, string>()
        {
            {0, "Success" },
            {1, "Sender not found" },
            {2, "Receiver not found" },
            {3, "User not found" },
            {4, "Kudos amount in transaction is negative or equals 0" },
            {5, "Not enough balance" },
            {6, "Sender = receiver" },
            {7, "Product not found" },
            {8, "Product is not available" },
            {9, "Value can't be null" },
            {10, "Server error" }
        };

        
    }
}
