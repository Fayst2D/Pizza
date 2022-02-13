using Microsoft.AspNetCore.Http;

using PizzaShop.Models;
using System.Threading.Tasks;

using System.Collections.Generic;
using Pizza.Core.Services;
using Pizza.Core.SessionExtension;
using Pizza.Core.Entities;

namespace PizzaShop.Services.Implemintations
{
    public class CartService : ICartService
    {
        private const string Key = "cart";

        public async Task AddToCartAsync(Pizza.Core.Entities.Pizza pizza, ISession session)
        {           
            var cart = session.Get<List<CartItem>>(Key);

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
            session.Set(Key, cart);
        }       

        private int GetItemIndex(int id, ISession session)
        {
            var cart = session.Get<List<CartItem>>(Key);

            int index = 0;

            foreach(var item in cart)
            {
                if(item.Pizza.Id == id)
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        public void ClearCart(ISession session)
        {
            session.Set(Key, null);
        }

        public async Task RemoveAsync(Pizza.Core.Entities.Pizza pizza, ISession session)
        {
            var cart = session.Get<List<CartItem>>(Key);
                         
            int index = GetItemIndex(pizza.Id, session);
                  
            if(cart[index].Quantity > 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.Remove(cart[index]);
            }                

            session.Set(Key, cart);            
        }

        public List<CartItem> GetItems(ISession session)
        {
            return session.Get<List<CartItem>>(Key);
        }

        public int GetTotalPrice(ISession session)
        {
            var cart = GetItems(session);

            int sum = 0;

            foreach(var item in cart)
            {
                sum += item.Quantity * item.Pizza.Price;
            }

            return sum;
        }

        public void CreateOrder(Order order,ISession session)
        {
            var cart = GetItems(session);

            //order.OrderDetails = cart;
            order.Total = GetTotalPrice(session);
        }
    }
}
