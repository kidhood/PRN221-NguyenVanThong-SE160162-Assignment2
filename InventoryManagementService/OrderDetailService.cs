using InventoryManagementBO.Models;
using InventoryManagementRepository;
using InventoryManagementRepository.DTO;
using InventoryManagementRepository.Interface;
using InventoryManagementService.Interface;

namespace InventoryManagementService;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository orderDetailRepository;
    private readonly IProductRepository productRepository;

    public OrderDetailService()
    {
        orderDetailRepository = new OrderDetailRepository();
        productRepository = new ProductRepository();
    }

    List<OrderDetail> IOrderDetailService.GetOrderDetailsByOrderId(int id)
    {
        return orderDetailRepository.GetOrderDetailsByOrderId(id);
    }

    public bool RegisterOrderDetail(OrderDetail orderDetail)
    {
        return orderDetailRepository.RegisterOrderDetail(orderDetail);
    }

    public bool RegisterOrderDetail(List<OrderDetail> orderDetails)
    {
        var products = productRepository.GetProductByIds(orderDetails.Select(x => x.ProductId).ToList());
        foreach (var product in products)
            product.Quantity = product.Quantity - orderDetails.First(x => x.ProductId == product.Id).Quantiy;

        if (productRepository.UpdateListProduct(products))
            orderDetailRepository.RegisterOrderDetail(orderDetails);
        else
            return false;

        return true;
    }

    public List<CartItem> GetCartItemByOrderId(int id)
    {
        var listOrderDetail = orderDetailRepository.GetOrderDetailsByOrderId(id);
        if (listOrderDetail != null && listOrderDetail.Count > 0)
        {
            var listCartItem = listOrderDetail.Select(x => new CartItem
            {
                ProductId = x.ProductId.Value,
                ProductName = x.Product.Name,
                ProductImage = x.Product.ImagePath,
                Price = x.Price.Value,
                Quantity = x.Quantiy.Value,
                TotalPrice = x.Price.Value * x.Quantiy.Value
            }).ToList();

            return listCartItem;
        }

        return new List<CartItem>();
    }
}