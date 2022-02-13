using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Core.Entities
{
    public class OrderDetail
    {

        public int OrderId { get; set; }

        public int OrderDetailId { get; set; }

        public int PizzaId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public Pizza Pizza { get; set; }

        public Order Order { get; set; }

    }
}
