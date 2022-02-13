namespace PizzaShop.Models
{
    public class CartItem
    {
        public Pizza.Core.Entities.Pizza Pizza { get; set; }

        public int Quantity { get; set; }

        public CartItem(Pizza.Core.Entities.Pizza pizza,int quantity)
        {
            Pizza = pizza;
            Quantity = quantity;
        }
        public CartItem()
        {

        }
    }
}
