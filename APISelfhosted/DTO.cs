using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISelfhosted
{
    class DTO
    {
        public class clsCategory
        {
            public string CategoryName { get; set; }
            public string Description { get; set; }

            public List<clsProducts> ProductList { get; set; }
        }

        public class clsProducts
        {
            public string Name { get; set; }
            public string Origin { get; set; }
            public string ProductCondition { get; set; }
            public string Brand { get; set; }
            public int Quantity { get; set; }
        }

        public class clsOrderDetails
        {
            public string CustomerName { get; set; }
            public string CustomerPhone { get; set; }
            public DateTime DateofPurchase { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
