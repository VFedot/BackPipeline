using System;
using System.Collections.Generic;

#nullable disable

namespace KudosShop.Models
{
    public partial class Product
    {
        public Product()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int ProductPrice { get; set; }
        public string ProductComment { get; set; }
        public bool ProductIsAvailable { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
