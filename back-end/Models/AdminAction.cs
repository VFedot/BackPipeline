using System;
using System.Collections.Generic;

#nullable disable

namespace KudosShop.Models
{
    public partial class AdminAction
    {
        public int OperationId { get; set; }
        public int UserId { get; set; }
        public DateTime OperationDate { get; set; }
        public string OperationDescription { get; set; }

        public virtual User User { get; set; }
    }
}
