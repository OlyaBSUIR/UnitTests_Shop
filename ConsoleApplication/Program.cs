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
            Product sweet = new Product("Конфеточки", 125, true, 3, 300);
            Product apple = new Product("Яблочки", 100, true, 6, 500);

            ShoppingCart cart = new ShoppingCart();
            cart.addToCart(sweet, 5);
            cart.addToCart(apple, 7);
            Product sweet1;
            try
            {
                 sweet1 = new Product(null, 125, true, 3, 300);
            }
            catch(Exception ex)
            {

            }
            BeltConveyor conveyor = new BeltConveyor();
            conveyor.putCartOnTConveyor(cart);
            int price = conveyor.getTotalPrice();
            Console.WriteLine(price);
            Console.ReadLine();
            
        }
    }
}
