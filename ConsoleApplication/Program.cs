using MyBeltConveyor;
using MyProduct;
using MyShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Product sweet = new Product();
            sweet.price = 125;
            sweet.isOnSale = true;
            sweet.countNeedToBuyForSale = 3;
            sweet.salePrice = 300;
            ShoppingCart cart = new ShoppingCart();
            cart.addToCart(sweet);
            cart.addToCart(sweet);
            cart.addToCart(sweet);
            cart.addToCart(sweet);
            cart.addToCart(sweet);
            BeltConveyor conveyor = new BeltConveyor();
            conveyor.putCartOnTConveyor(cart);
            int price = conveyor.getTotalPrice();
            Console.WriteLine(price);
            Console.ReadLine();
            

        }
    }
}
