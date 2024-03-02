using InventoryManagementBO.Models;
using InventoryManagementDAO;
using InventoryManagementRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementRepository
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {
        }

        public List<Product> GetProductByIds(List<int?> list)
        => ProductDAO.Instance.GetProductsByIds(list);

        public List<Product> GetProductByName(string name)
        => ProductDAO.Instance.getProductsByName(name);

        public List<Product> GetProductByPaging(int pageNumber)
            =>  ProductDAO.Instance.getProductsByPaging(pageNumber);

        public bool SaveProduct(Product product)
        {
            return ProductDAO.Instance.SaveProduct(product);
        }

        public bool UpdateListProduct(List<Product> products)
        => ProductDAO.Instance.UpdateProducts(products);

        public bool UpdateProduct(Product product)
        {
            return ProductDAO.Instance.UpdateProduct(product);
        }
    }
}
