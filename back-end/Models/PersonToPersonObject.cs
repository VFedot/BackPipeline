using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Models
{
    public class PersonToPersonObject
    {
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public int kudosAmount { get; set; }
        public string reason { get; set; }
    }
}
