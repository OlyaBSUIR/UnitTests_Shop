using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct
{
    public interface IProduct
    {
        String name { get; set; }
        int price { get; set; }
        bool isOnSale { get; set; }
        int countNeedToBuyForSale { get; set; }
        int salePrice { get; set; }
    }
}
