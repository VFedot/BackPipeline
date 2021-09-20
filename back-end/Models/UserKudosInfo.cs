using System;
using System.Collections.Generic;

#nullable disable

namespace KudosShop.Models
{
    public partial class UserKudosInfo
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int? UserType { get; set; }
        public int? Total { get; set; }
    }
}
