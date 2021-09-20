using System;
using System.Collections.Generic;

#nullable disable

namespace KudosShop.Models
{
    public partial class Transaction
    {
        public int SendersId { get; set; }
        public int ReceiverId { get; set; }
        public int TransactionType { get; set; }
        public int? ProductId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int Amount { get; set; }
        public string Reason { get; set; }
        public int TransactionId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User Receiver { get; set; }
        public virtual User Senders { get; set; }
    }
}
