using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Services;
using System.Threading.Tasks;

namespace PizzaShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly ApplicationDbContext dbContext;

        public CartController(ICartService cart, ApplicationDbContext _context)
        {
            cartService = cart;
            dbContext = _context;
        }

        public IActionResult Index()
        {
            return View(cartService.GetCartViewModel(HttpContext.Session));
        }

        public async Task<IActionResult> Add(int id)
        {
            var pizza = await dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);

            await cartService.AddToCartAsync(pizza,HttpContext.Session);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var pizza = await dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);

            await cartService.RemoveAsync(pizza, HttpContext.Session);

            return RedirectToAction("Index");
        }


    }
}
