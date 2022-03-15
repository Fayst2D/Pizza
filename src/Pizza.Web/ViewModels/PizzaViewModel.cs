using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PizzaShop.ViewModels
{
    public class PizzaViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public int Diameter { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Recipe { get; set; }

        public IFormFile Image { get; set; }
    }
}
