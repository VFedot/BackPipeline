using System;
using System.Collections.Generic;

#nullable disable

namespace KudosShop.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int UserTypeId { get; set; }
        public string UserType1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
