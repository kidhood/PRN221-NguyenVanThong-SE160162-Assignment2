using InventoryManagementBO.Models;

namespace InventoryManagementRepository.Interface;

public interface IOrderRepository
{
    List<Order>? GetOrderByPaging(int pageNumber);
    Order RegisterNewOrder(Order order);
    public bool RegisterOrder(Order order);
    List<Order> GetOrderById(int id);
}