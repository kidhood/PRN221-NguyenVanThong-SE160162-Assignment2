using InventoryManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDAO
{
    public class SupplierDAO
    {
        private readonly InventoryManagementContext _dbContext = null;
        private static int PAGE_SIZE = 6;
        private static SupplierDAO instance = null;

        public static SupplierDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SupplierDAO();
                }
                return instance;
            }
        }

        public SupplierDAO()
        {
            _dbContext = new InventoryManagementContext();
        }

        public List<Supplier> getListSuplier()
        {
            return _dbContext.Suppliers.Where(x => !x.IsDelete.Value).ToList();
        }

        public List<Supplier> GetSupplierByPaging(int pageNumber)
        {
            return _dbContext.Suppliers
                    .Where(x => !x.IsDelete.Value)
                    .OrderBy(p => p.Id)
                    .Skip((pageNumber - 1) * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();
        }

        public List<Supplier> GetSupplierByName(string name)
        {
            return _dbContext.Suppliers.Where(p => !p.IsDelete.Value && p.Name.ToLower().Contains(name)).ToList();
        }

        public bool Update(Supplier supplier)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Suppliers.Update(supplier);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Save(Supplier supplier)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Suppliers.Add(supplier);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
