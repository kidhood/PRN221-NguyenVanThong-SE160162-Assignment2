using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using InventoryManagementBO.Models;
using InventoryManagementBO.Utilities;
using InventoryManagementGUI.Model;
using InventoryManagementService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementGUI.Pages;

public class ManageProduct : PageModel
{
    private readonly ISupplierService _supplierService;
    private readonly IOrderDetailService oderDetailService;
    private readonly IOrderService orderService;
    private readonly IProductService productService;

    public ManageProduct(IProductService productService, IOrderDetailService oderDetailService,
        IOrderService orderService, ISupplierService supplierService)
    {
        this.productService = productService;
        this.oderDetailService = oderDetailService;
        this.orderService = orderService;
        _supplierService = supplierService;
    }

    [DataMember] [BindProperty] public List<Product> ListProduct { get; set; }

    [BindProperty] public ProductDetail ProductDetail { get; set; }

    public void OnGet()
    {
        ListProduct = productService.GetProductByPaging(1);
        ProductDetail = new ProductDetail();
        ProductDetail.ListSupplier = _supplierService.GetSuppliers().Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString()
        }).ToList();
    }

    public IActionResult OnPostGetProductListPaging([FromBody] int pageNumber)
    {
        var list = productService.GetProductByPaging(pageNumber);
        return Partial("_ManageProductListPartial", list);
    }

    public IActionResult OnPostSearchByName([FromBody] string keySearch)
    {
        var list = productService.GetProductByName(keySearch);
        return Partial("_ManageProductListPartial", list);
    }

    public IActionResult OnPostCreateProduct()
    {
        PostResult result = null;
        ModelState.Remove("Id");
        if (!ModelState.IsValid)
            return Partial("_AddOrEditProduct", ProductDetail);
        var producTemp = CreateProduct();
        if (producTemp.Id == 0)
            if (productService.RegisterProduct(producTemp))
            {
                result = new PostResult
                {
                    Result = Result.Ok,
                    Data = "add"
                };
                return new JsonResult(result);
            }

        if (productService.UpdateProduct(producTemp))
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

    public IActionResult OnPostDeleteProduct()
    {
        PostResult result = null;
        var pro = new Product();
        pro.Id = ProductDetail.Id;
        pro.IsDelete = true;
        if (productService.UpdateProduct(pro))
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

    private Product CreateProduct()
    {
        var product = new Product
        {
            Id = ProductDetail.Id,
            Name = ProductDetail.Name,
            ImagePath = ProductDetail.ImagePath,
            Quantity = ProductDetail.Quantity,
            Description = ProductDetail.Description,
            Price = ProductDetail.Price,
            IsDelete = false
        };

        return product;
    }
}

public class ProductDetail
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product ImagePath is required")]
    public string ImagePath { get; set; }

    [Required(ErrorMessage = "Product Quantity is required")]
    [Range(1, 1000, ErrorMessage = "product quantity must in range 0 - 1000")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Product Description is required")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Product Price is required")]
    [Range(1, 1000, ErrorMessage = "product Price must in range 0 - 1000")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Product Supplier is required")]
    public int SupplierId { get; set; }

    public List<SelectListItem> ListSupplier { get; set; }
}