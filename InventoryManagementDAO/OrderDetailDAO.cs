using InventoryManagementBO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDAO
{
    public class OrderDetailDAO
    {
        private readonly InventoryManagementContext _dbContext = null;

        private static OrderDetailDAO instance = null;

        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        public OrderDetailDAO()
        {
            _dbContext = new InventoryManagementContext();
        }

        public bool SaveOrderDetail(OrderDetail order)
        {
            try
            {
                _dbContext.Add(order);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveOrderDetail(List<OrderDetail> orderDetails)
        {
            try
            {
                _dbContext.AddRange(orderDetails);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int id)
        {
            try
            {
                return _dbContext.OrderDetails.Include(x => x.Product).Where(x => x.OrderId == id).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
