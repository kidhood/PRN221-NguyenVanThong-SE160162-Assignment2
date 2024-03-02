using InventoryManagementBO.Models;

namespace InventoryManagementService.Interface;

public interface IOrderService
{
    Order RegisterNewOrder(Order order);
    public bool RegisterOrder(Order order);

    List<Order>? GetOrderByPaging(int pageNumber);
    List<Order> GetOrderById(int id);
}