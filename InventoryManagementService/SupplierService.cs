using InventoryManagementBO.Models;
using InventoryManagementRepository;
using InventoryManagementRepository.Interface;
using InventoryManagementService.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementService
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService()
        {
            supplierRepository = new SupplierRepository();
        }

        public List<Supplier> GetProductByName(string name)
        => supplierRepository.GetSupplierByName(name);

        public List<Supplier> GetSuppliers()
        => supplierRepository.GetSuppliers();

        public bool RegisterSupplier(Supplier supplier)
        => supplierRepository.RegisterSupplier(supplier);

        public bool UpdateSupplier(Supplier supplier)
        => supplierRepository.Update(supplier);

        List<Supplier> ISupplierService.GetSupplierByPaging(int pageNumber)
        => supplierRepository.GetSupplierByPaging(pageNumber);
    }
}
