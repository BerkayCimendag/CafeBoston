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
        public DateTime? StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public string TotalPriceTRY => TotalPrice().ToString("c2");
        public decimal TotalPrice() => OrderDetails.Sum(x => x.TotalPrice());
        
    }
}
