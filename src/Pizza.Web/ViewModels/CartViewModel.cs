﻿using PizzaShop.Models;

namespace Pizza.Web.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> Cart { get; set; }

        public decimal Sum { get; set; }
    }
}
