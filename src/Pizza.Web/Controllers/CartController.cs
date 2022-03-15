using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Core.Services;
using Pizza.Data.Data;
using Pizza.Web.ViewModels;

namespace Pizza.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ApplicationDbContext _dbContext;

        public CartController(ICartService cart, ApplicationDbContext context)
        {
            _cartService = cart;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetItems(HttpContext.Session);


            decimal sum = 0;
            if (cart != null)
            {
               sum = _cartService.GetTotalPrice(HttpContext.Session);
            }

            return View(new CartViewModel{
                Sum = sum,
                Cart = cart
            });
        }

        public async Task<IActionResult> Add(int id)
        {
            var pizza = await _dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);

            if (pizza == null)
            {
                return NotFound();
            }

            _cartService.AddToCart(pizza,HttpContext.Session);

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var pizza = await _dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);

            if(pizza == null)
            {
                return NotFound();
            }
            _cartService.Remove(pizza, HttpContext.Session);

            return RedirectToAction("Index");
        }

    }
}
