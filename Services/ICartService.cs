using Microsoft.AspNetCore.Http;
using PizzaShop.ViewModels;
using System.Threading.Tasks;

namespace PizzaShop.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(Models.Pizza pizza, ISession session);

        void ClearCart(ISession session);

        Task RemoveAsync(Models.Pizza pizza,ISession session);

        CartViewModel GetCartViewModel(ISession session);

    }
}
