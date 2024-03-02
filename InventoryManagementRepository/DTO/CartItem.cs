namespace InventoryManagementRepository.DTO;

public class CartItem
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string ProductImage { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }
}