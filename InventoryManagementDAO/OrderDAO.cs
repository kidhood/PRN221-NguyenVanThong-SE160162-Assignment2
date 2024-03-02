using InventoryManagementBO.Models;

namespace InventoryManagementDAO;

public class OrderDAO
{
    private static readonly int PAGE_SIZE = 6;

    private static OrderDAO instance;
    private readonly InventoryManagementContext _dbContext;

    public OrderDAO()
    {
        _dbContext = new InventoryManagementContext();
    }

    public static OrderDAO Instance
    {
        get
        {
            if (instance == null) instance = new OrderDAO();
            return instance;
        }
    }

    public bool SaveOrder(Order order)
    {
        try
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Order SaveNewOrder(Order order)
    {
        try
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return order;
        }
        catch
        {
            return null;
        }
    }

    public List<Order>? GetOrderByPaging(int pageNumber)
    {
        return _dbContext.Orders
            .OrderByDescending(p => p.OrderDate)
            .Skip((pageNumber - 1) * PAGE_SIZE)
            .Take(PAGE_SIZE)
            .ToList();
    }

    public List<Order> GetOrderById(int id)
    {
        return _dbContext.Orders
            .Where(x => x.Id == id)
            .ToList();
    }
}