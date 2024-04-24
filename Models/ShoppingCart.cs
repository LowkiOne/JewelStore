namespace WebShopJewel.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public int AmountProduct { get; set; }
    public decimal TotalPrice { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int ShoppingCartAccountId { get; set; }
    public ShoppingCartAccount ShoppingCartAccount { get; set; }
}
