using InventoryManagementBO.Models;
using InventoryManagementRepository;
using InventoryManagementRepository.Interface;
using InventoryManagementService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public List<Product> GetProductByName(string name)
        =>    productRepository.GetProductByName(name);
        

        public List<Product> GetProductByPaging(int pageNumber)
        {
            return productRepository.GetProductByPaging(pageNumber);
        }

        public bool RegisterProduct(Product product)
        {
            return productRepository.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return productRepository.UpdateProduct(product);
        }
    }
}
