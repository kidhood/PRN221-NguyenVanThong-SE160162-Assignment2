using System.Runtime.Serialization;
using InventoryManagementBO.Models;
using InventoryManagementService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagementGUI.Pages;

public class Products : PageModel
{
    private readonly IOrderDetailService oderDetailService;
    private readonly IOrderService orderService;
    private readonly IProductService productService;

    [DataMember] public Dictionary<int, Product> ListCartInItem;

    [DataMember] public List<Product> ListProduct;

    public Products(IProductService productService, IOrderDetailService oderDetailService, IOrderService orderService)
    {
        this.productService = productService;
        this.oderDetailService = oderDetailService;
        this.orderService = orderService;
    }

    public void OnGet()
    {
        ListProduct = productService.GetProductByPaging(1);
        ListCartInItem = new Dictionary<int, Product>();
    }

    public IActionResult OnPostOrderForm([FromBody] List<CartItem> items)
    {
        // Process the orderData here
        var orderTemp = CreateOrder(items);
        var isOrderSuccess = orderService.RegisterOrder(orderTemp);
        if (isOrderSuccess)
        {
            var orderDetails = CreateOrderDetail(orderTemp, items);
            if (oderDetailService.RegisterOrderDetail(orderDetails))
                return new AcceptedResult();
            return new BadRequestResult();
        }

        return new BadRequestResult();
    }

    public IActionResult OnPostGetProductListPaging([FromBody] int pageNumber)
    {
        var list = productService.GetProductByPaging(pageNumber);
        return Partial("_ProductListPartial", list);
    }

    public IActionResult OnPostSearchByName([FromBody] string keySearch)
    {
        var list = productService.GetProductByName(keySearch);
        return Partial("_ProductListPartial", list);
    }

    private Order CreateOrder(List<CartItem> items)
    {
        var order = new Order();
        order.TotalCost = Math.Round(items.Sum(x => x.Price * x.Quantity), 2);
        order.OrderDate = DateTime.Now;
        order.AccountId = 1;

        return order;
    }

    private List<OrderDetail> CreateOrderDetail(Order order, List<CartItem> items)
    {
        var orderDetails = new List<OrderDetail>();
        foreach (var item in items)
        {
            var detail = new OrderDetail();
            detail.ProductId = item.ProductId;
            detail.Quantiy = item.Quantity;
            detail.OrderId = order.Id;
            detail.Price = item.Price;

            orderDetails.Add(detail);
        }

        return orderDetails;
    }
}

public class OrderData
{
    public List<CartItem> CartItems { get; set; }
    public float TotalQuantity { get; set; }
    public float TotalPrice { get; set; }
}

public class CartItem
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string ProductImage { get; set; }
}