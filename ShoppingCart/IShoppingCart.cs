using MyProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingCart
{
    public interface IShoppingCart
    {
        void addToCart(IProduct product, int count = 1);
        IProduct takeFromCart();
        bool isEmpty();
        List<IProduct> takeAllProductsFromCart();        

    }
}
