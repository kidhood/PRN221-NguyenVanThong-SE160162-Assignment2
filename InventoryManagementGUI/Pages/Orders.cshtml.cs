using System.Runtime.Serialization;
using InventoryManagementBO.Models;
using InventoryManagementService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagementGUI.Pages;

public class Orders : PageModel
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IOrderService _orderService;

    [DataMember] public List<Order> ListOrder;

    public Orders(IOrderService orderService, IOrderDetailService orderDetailService)
    {
        _orderService = orderService;
        _orderDetailService = orderDetailService;
    }

    public void OnGet()
    {
        ListOrder = _orderService.GetOrderByPaging(1);
    }

    public IActionResult OnPostShowCartItem([FromBody] int orderId)
    {
        var listCartItem = _orderDetailService.GetCartItemByOrderId(orderId);
        return new JsonResult(new { Result = "OK", ListCartItem = listCartItem });
    }

    public IActionResult OnPostGetOrderListPaging([FromBody] int pageNumber)
    {
        var listOrder = _orderService.GetOrderByPaging(pageNumber);
        return Partial("_OrderListPartial", listOrder);
    }

    public IActionResult OnPostSearchById([FromBody] int id)
    {
        var listOrder = _orderService.GetOrderById(id);
        return Partial("_OrderListPartial", listOrder);
    }
}