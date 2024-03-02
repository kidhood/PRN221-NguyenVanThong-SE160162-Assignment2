using System;
using System.Collections.Generic;

namespace InventoryManagementBO.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? Quantiy { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public double? Price { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
