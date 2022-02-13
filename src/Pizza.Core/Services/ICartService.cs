using Microsoft.AspNetCore.Http;
using Pizza.Core.Entities;
using PizzaShop.Models;

namespace Pizza.Core.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(Entities.Pizza pizza, ISession session);

        void ClearCart(ISession session);

        Task RemoveAsync(Entities.Pizza pizza,ISession session);

        List<CartItem> GetItems(ISession session);

        int GetTotalPrice(ISession session);

        void CreateOrder(Order order, ISession session);
    }
}
