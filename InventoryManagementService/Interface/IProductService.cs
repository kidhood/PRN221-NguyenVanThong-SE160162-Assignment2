using InventoryManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementService.Interface
{
    public interface IProductService
    {
        public List<Product> GetProductByName(string text);
        public List<Product> GetProductByPaging(int pageNumber);
        bool RegisterProduct(Product product);
        bool UpdateProduct(Product product);
    }
}
