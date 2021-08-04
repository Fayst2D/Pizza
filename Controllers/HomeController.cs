using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Data;
using PizzaShop.Models;


namespace Pizza.Controllers
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
