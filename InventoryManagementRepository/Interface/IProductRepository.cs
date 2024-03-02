using InventoryManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementRepository.Interface
{
    public interface IProductRepository
    {
        List<Product> GetProductByIds(List<int?> list);
        List<Product> GetProductByName(string name);
        public List<Product> GetProductByPaging(int pageNumber);
        bool SaveProduct(Product product);
        bool UpdateListProduct(List<Product> products);
        bool UpdateProduct(Product product);
    }
}
