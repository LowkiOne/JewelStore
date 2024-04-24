namespace WebShopJewel.Models
{
    public class ShoppingCartAccount
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public decimal TotalCartPrice { get; set; }
        public ICollection<ShoppingCart> Items { get; set; }
    }
}
