using InventoryManagementBO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDAO
{
    public class ProductDAO
    {
        private readonly InventoryManagementContext _dbContext = null;
        private static int PAGE_SIZE = 6;

        private static ProductDAO instance = null;

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }

        public ProductDAO()
        {
            _dbContext = new InventoryManagementContext();
        }

        public List<Product> getProductsByPaging(int pageNumber)
        {
            return _dbContext.Products
                    .Where(p => !p.IsDelete.Value)
                    .OrderBy(p => p.Id)
                    .Skip((pageNumber - 1) * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();
        }

        public List<Product> getProductsByName(string name)
        {
            return _dbContext.Products.Where(p => !p.IsDelete.Value && p.Name.ToLower().Contains(name)).ToList(); 
        }

        public bool SaveProduct(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProducts(List<Product> products)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Products.UpdateRange(products);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Product> GetProductsByIds(List<int?> list)
        {
            return _dbContext.Products.Where(x => list.Contains(x.Id)).ToList();
        }
    }
}
