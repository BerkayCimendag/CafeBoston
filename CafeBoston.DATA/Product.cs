using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBoston.DATA
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
