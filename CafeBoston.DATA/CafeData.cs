using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBoston.DATA
{
    public class CafeData
    {
        public int TableCount { get; set; } = 20;
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Order> ActiveOrders { get; set; } = new List<Order>();
        public List<Order> PastOrders { get; set; } = new List<Order>();
    }
}
