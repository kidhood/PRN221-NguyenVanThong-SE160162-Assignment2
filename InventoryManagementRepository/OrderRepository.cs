using InventoryManagementBO.Models;
using InventoryManagementDAO;
using InventoryManagementRepository.Interface;

namespace InventoryManagementRepository;

public class OrderRepository : IOrderRepository
{
    public List<Order>? GetOrderByPaging(int pageNumber)
    {
        return OrderDAO.Instance.GetOrderByPaging(pageNumber);
    }

    public Order RegisterNewOrder(Order order)
    {
        return OrderDAO.Instance.SaveNewOrder(order);
    }

    public bool RegisterOrder(Order order)
    {
        return OrderDAO.Instance.SaveOrder(order);
    }

    public List<Order> GetOrderById(int id)
    {
        return OrderDAO.Instance.GetOrderById(id);
    }
}