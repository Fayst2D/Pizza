namespace PizzaShop.Models
{
    public class CartItem
    {
        public Pizza Pizza { get; set; }

        public int Quantity { get; set; }

        public CartItem(Pizza pizza,int quantity)
        {
            Pizza = pizza;
            Quantity = quantity;
        }
    }
}
