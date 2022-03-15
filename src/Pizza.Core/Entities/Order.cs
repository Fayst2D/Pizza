using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public decimal Total { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
