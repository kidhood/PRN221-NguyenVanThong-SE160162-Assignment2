using InventoryManagementBO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementService.Interface
{
    public interface ISupplierService
    {
        List<Supplier> GetProductByName(string text);
        List<Supplier> GetSupplierByPaging(int pageNumber);
        public List<Supplier> GetSuppliers();
        bool RegisterSupplier(Supplier supplier);
        bool UpdateSupplier(Supplier supplierSelected);
    }
}
