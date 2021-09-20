using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosShop.Models
{
    public class UserManagementObject
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }
        public int userType { get; set; }
    }
}
