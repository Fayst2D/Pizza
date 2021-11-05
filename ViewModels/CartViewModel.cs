using PizzaShop.Models;
using System.Collections.Generic;

namespace PizzaShop.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> Cart { get; set; }

        public int Sum { get; set; }
    }
}
