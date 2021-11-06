using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Models;
using System.Threading.Tasks;

using System.Collections.Generic;
using PizzaShop.SessionExtension;
using PizzaShop.ViewModels;

namespace PizzaShop.Services.Implemintations
{
    public class CartService : ICartService
    {
        private const string key = "cart";

        public async Task AddToCartAsync(Models.Pizza pizza, ISession session)
        {           
            var cart = session.Get<List<CartItem>>(key);

            if (cart == null)
            {
                cart = new List<CartItem>();

                cart.Add(new CartItem(pizza,1));             
            }  
            else
            {  
                int index = GetItemIndex(pizza.Id, session);
                
                if(index == -1)
                {
                    cart.Add(new CartItem(pizza, 1));
                }
                else
                {
                    cart[index].Quantity++;
                }               
            }
            session.Set(key, cart);
        }       

        private int GetItemIndex(int id, ISession session)
        {
            var cart = session.Get<List<CartItem>>(key);

            foreach(var item in cart)
            {
                if(item.Pizza.Id == id)
                {
                    return item.Pizza.Id;
                }
            }

            return -1;
        }

        public void ClearCart(ISession session)
        {
            session.Set(key, null);
        }

        public CartViewModel GetCartViewModel(ISession session)
        {
            var cart = session.Get<List<CartItem>>(key);

            int sum = 0;

            foreach(var item in cart)
            {
                sum += item.Quantity*item.Pizza.Price;
            }

            return new() { Cart = cart, Sum = sum };
        }

        public async Task RemoveAsync(Models.Pizza pizza, ISession session)
        {
            var cart = session.Get<List<CartItem>>(key);
                         
            int index = GetItemIndex(pizza.Id, session);
                  
            if(cart[index].Quantity > 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.Remove(cart[index]);
            }                

            session.Set(key, cart);            
        }
    }
}
