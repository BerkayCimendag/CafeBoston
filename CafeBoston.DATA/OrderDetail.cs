using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBoston.DATA
{
    public  class OrderDetail
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public readonly string TotalPriceTRY;
        public decimal TotalPrice()
        {
            return 0;
        }
    }
}
