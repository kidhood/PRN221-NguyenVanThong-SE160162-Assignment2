using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using InventoryManagementBO.Models;
using InventoryManagementBO.Utilities;
using InventoryManagementGUI.Model;
using InventoryManagementService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagementGUI.Pages;

public class ManageSupplier : PageModel
{
    private readonly ISupplierService _supplierService;

    public ManageSupplier(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [DataMember] [BindProperty] public List<Supplier> ListSupplier { get; set; }

    [BindProperty] public SupplierDetail SupplierDetail { get; set; }

    public void OnGet()
    {
        ListSupplier = _supplierService.GetSuppliers();
    }

    public IActionResult OnPostGetSupplierListPaging([FromBody] int pageNumber)
    {
        var list = _supplierService.GetSupplierByPaging(pageNumber);
        return Partial("_ManagesSupplierListPartial", list);
    }

    public IActionResult OnPostSearchByName([FromBody] string keySearch)
    {
        var list = _supplierService.GetProductByName(keySearch);
        return Partial("_ManagesSupplierListPartial", list);
    }

    public IActionResult OnPostCreateSupplier()
    {
        PostResult result = null;
        ModelState.Remove("Id");
        if (!ModelState.IsValid)
            return Partial("_AddOrEditSupplier", SupplierDetail);
        var supplierTemp = CreateSupplier();
        if (supplierTemp.Id == 0)
            if (_supplierService.RegisterSupplier(supplierTemp))
            {
                result = new PostResult
                {
                    Result = Result.Ok,
                    Data = "add"
                };
                return new JsonResult(result);
            }

        if (_supplierService.UpdateSupplier(supplierTemp))
        {
            result = new PostResult
            {
                Result = Result.Ok,
                Data = "update"
            };
            return new JsonResult(result);
        }


        return new BadRequestResult();
    }

    public IActionResult OnPostDeleteSupplier()
    {
        PostResult result = null;
        var supp = new Supplier();
        supp.Id = SupplierDetail.Id;
        supp.IsDelete = true;
        if (_supplierService.UpdateSupplier(supp))
        {
            result = new PostResult
            {
                Result = Result.Ok,
                Data = "update"
            };
            return new JsonResult(result);
        }

        result = new PostResult
        {
            Result = Result.Error,
            Data = "update"
        };
        return new JsonResult(result);
    }

    private Supplier CreateSupplier()
    {
        var supplier = new Supplier
        {
            Id = SupplierDetail.Id,
            Name = SupplierDetail.Name,
            Phone = SupplierDetail.Phone,
            Email = SupplierDetail.Email,
            Address = SupplierDetail.Address,
            IsDelete = false
        };

        return supplier;
    }
}

public class SupplierDetail
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    [RegularExpression(@"^0\d{9,10}$", ErrorMessage = "Phone must start with 0 and have 10-11 digits")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }
}