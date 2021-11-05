using Microsoft.AspNetCore.Mvc;
using PizzaShop.Services;

namespace PizzaShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cart)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
