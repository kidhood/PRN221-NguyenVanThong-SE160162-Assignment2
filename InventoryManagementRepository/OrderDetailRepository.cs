using InventoryManagementBO.Models;
using InventoryManagementDAO;
using InventoryManagementRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementRepository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetailRepository()
        {
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int id)
        => OrderDetailDAO.Instance.GetOrderDetailsByOrderId(id);

        public bool RegisterOrderDetail(OrderDetail orderDetail)
        => OrderDetailDAO.Instance.SaveOrderDetail(orderDetail);

        public bool RegisterOrderDetail(List<OrderDetail> orderDetails)
        => OrderDetailDAO.Instance.SaveOrderDetail(orderDetails);
    }
}
