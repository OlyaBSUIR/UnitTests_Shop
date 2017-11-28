using Moq;
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
            IProduct sweet = new Product("Конфеточки", 125, true, 3, 300);
            IProduct apple = new Product("Яблочки", 100, true, 6, 500);

            IShoppingCart cart = new ShoppingCart();
     
            cart.addToCart(sweet, 5);
            cart.addToCart(apple, 7);

            IBeltConveyor conveyor = new BeltConveyor();
            //conveyor.putCartOnTConveyor(cart);
            //int price = conveyor.getTotalPrice();
           // Console.WriteLine(price);
            //conveyor.printCheck();

            

        }
    }
}
