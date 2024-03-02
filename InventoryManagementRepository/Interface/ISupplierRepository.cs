using InventoryManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementRepository.Interface
{
    public interface ISupplierRepository
    {
        List<Supplier> GetSupplierByName(string name);
        List<Supplier> GetSupplierByPaging(int pageNumber);
        public List<Supplier> GetSuppliers();
        bool RegisterSupplier(Supplier supplier);
        bool Update(Supplier supplier);
    }
}
