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
    public class SupplierRepository : ISupplierRepository
    {
        public SupplierRepository()
        {
        }

        public List<Supplier> GetSupplierByName(string name)
        => SupplierDAO.Instance.GetSupplierByName(name);

        public List<Supplier> GetSupplierByPaging(int pageNumber)
        => SupplierDAO.Instance.GetSupplierByPaging(pageNumber);

        public List<Supplier> GetSuppliers()
         => SupplierDAO.Instance.getListSuplier();

        public bool RegisterSupplier(Supplier supplier)
        => SupplierDAO.Instance.Save(supplier);

        public bool Update(Supplier supplier)
        => SupplierDAO.Instance.Update(supplier);
    }
}
