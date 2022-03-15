using Microsoft.AspNetCore.Mvc;
using Pizza.Core.Entities;
using Pizza.Core.Services;
using Pizza.Data.Data;
using Pizza.Web.ViewModels;

namespace Pizza.Web.Controllers
{
    public class OrderController : Controller
    {

        private readonly ICartService _cartService;
        private readonly ApplicationDbContext _dbContext;

        public OrderController(ICartService cart, ApplicationDbContext context)
        {
            _cartService = cart;
            _dbContext = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(OrderViewModel orderVm)
        {
            if (_cartService.GetItems(HttpContext.Session) == null)
            {
                return RedirectToAction("Index","Home");
            }


                Order order = new Order
            {
                OrderDate = DateTime.Now,
                Address = orderVm.Address,
                FirstName = orderVm.FirstName,
                SecondName = orderVm.SecondName,
                Phone = orderVm.Phone,
            };

            if (ModelState.IsValid)
            {               
                
                _cartService.CreateOrder(order,HttpContext.Session);

                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            

            return View(orderVm);
        }
    }
}
