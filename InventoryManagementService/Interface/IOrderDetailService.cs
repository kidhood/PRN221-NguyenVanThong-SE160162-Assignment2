using InventoryManagementBO.Models;
using InventoryManagementRepository.DTO;

namespace InventoryManagementService.Interface;

public interface IOrderDetailService
{
    List<OrderDetail> GetOrderDetailsByOrderId(int id);

    List<CartItem> GetCartItemByOrderId(int id);
    public bool RegisterOrderDetail(OrderDetail orderDetail);
    bool RegisterOrderDetail(List<OrderDetail> orderDetails);
}