using Microsoft.AspNetCore.Http;
using PizzaShop.ViewModels;
using System.Threading.Tasks;

namespace PizzaShop.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(int id, ISession session);

        void ClearCart(ISession session);

        Task RemoveAsync(int id,ISession session);

        CartViewModel GetCartViewModel(ISession session);

    }
}
