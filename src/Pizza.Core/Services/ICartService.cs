using Microsoft.AspNetCore.Http;
using Pizza.Core.Entities;
using PizzaShop.Models;

namespace Pizza.Core.Services
{
    public interface ICartService
    {
        void AddToCart(Entities.Pizza pizza, ISession session);

        void ClearCart(ISession session);

        void Remove(Entities.Pizza pizza,ISession session);

        List<CartItem> GetItems(ISession session);

        decimal GetTotalPrice(ISession session);

        void CreateOrder(Order order, ISession session);
    }
}
