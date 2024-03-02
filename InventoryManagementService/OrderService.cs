using InventoryManagementBO.Models;
using InventoryManagementRepository;
using InventoryManagementRepository.Interface;
using InventoryManagementService.Interface;

namespace InventoryManagementService;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;

    public OrderService()
    {
        orderRepository = new OrderRepository();
    }

    public List<Order>? GetOrderByPaging(int pageNumber)
    {
        return orderRepository.GetOrderByPaging(pageNumber);
    }

    public List<Order> GetOrderById(int id)
    {
        return orderRepository.GetOrderById(id);
    }

    public Order RegisterNewOrder(Order order)
    {
        return orderRepository.RegisterNewOrder(order);
    }

    public bool RegisterOrder(Order order)
    {
        return orderRepository.RegisterOrder(order);
    }
}