using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct
{
    public class Product
    {
        public String name { get; set; }
        public int price { get; set; }
        public bool isOnSale { get; set; }
        public int countNeedToBuyForSale { get; set; }
        public int salePrice { get; set; }
    }
}
