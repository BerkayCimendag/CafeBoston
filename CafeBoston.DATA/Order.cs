using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBoston.DATA
{
    public class Order
    {
        public int TableNo { get; set; }
        public OrderState State { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public readonly string TotalPriceTRY;
        public decimal TotalPrice()
        {
            return 0;
        }
    }
}
