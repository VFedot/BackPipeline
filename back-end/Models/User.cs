using System;
using System.Collections.Generic;

#nullable disable

namespace KudosShop.Models
{
    public partial class User
    {
        public User()
        {
            AdminActions = new HashSet<AdminAction>();
            TransactionReceivers = new HashSet<Transaction>();
            TransactionSenders = new HashSet<Transaction>();
        }

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int UserType { get; set; }
        public int UserId { get; set; }

        public virtual UserType UserTypeNavigation { get; set; }
        public virtual ICollection<AdminAction> AdminActions { get; set; }
        public virtual ICollection<Transaction> TransactionReceivers { get; set; }
        public virtual ICollection<Transaction> TransactionSenders { get; set; }
    }
}
