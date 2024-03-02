using System;
using System.Collections.Generic;

namespace InventoryManagementBO.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public bool? IsDelete { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
