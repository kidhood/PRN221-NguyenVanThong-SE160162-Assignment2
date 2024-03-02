using InventoryManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementRepository.Interface
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetailsByOrderId(int id);
        public bool RegisterOrderDetail(OrderDetail orderDetail);
        bool RegisterOrderDetail(List<OrderDetail> orderDetails);
    }
}
