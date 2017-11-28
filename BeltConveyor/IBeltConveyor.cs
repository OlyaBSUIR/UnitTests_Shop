using MyProduct;
using MyShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeltConveyor
{
    public interface IBeltConveyor
    {
        int getTotalPrice();
        void putCartOnTConveyor(IShoppingCart cart);
        void putCartOnTConveyor(List<IProduct> products);
        void printCheck();
    }

}
