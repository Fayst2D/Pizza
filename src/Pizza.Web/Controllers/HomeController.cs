using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Data.Data;
using Pizza.Web.Models;


namespace Pizza.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
            
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Pizzas.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var pizza = from p in _context.Pizzas select p;
            
            if(!String.IsNullOrEmpty(searchString))
            {
                pizza = pizza.Where(p => p.Name.Contains(searchString));
            }

            return View(await pizza.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
