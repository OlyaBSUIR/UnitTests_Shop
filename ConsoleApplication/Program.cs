using BeltConveyorTest;
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
           // var mock = new Mock<ShoppingCartStub>();
          //  mock.SetupGet(s => s.listOfProducts).Returns(() => new List<IProduct> { sweet, sweet, sweet });
   
           // cart = mock.Object;
            cart.addToCart(sweet, 5);
            cart.addToCart(apple, 7);


            IBeltConveyor conveyor = new BeltConveyor();
            conveyor.putCartOnTConveyor(cart);
            int price = conveyor.getTotalPrice();
            Console.WriteLine(price);
            conveyor.printCheck();

            IProduct sweet1;

            var mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(s => s.name).Returns("Конфеточки");
            mockProduct.SetupGet(s => s.price).Returns(125);
            mockProduct.SetupGet(s => s.isOnSale).Returns(true);
            mockProduct.SetupGet(s => s.countNeedToBuyForSale).Returns(3);
            mockProduct.SetupGet(s => s.salePrice).Returns(300);

            sweet1 = mockProduct.Object;

            var mockCart = new Mock<IShoppingCart>();
            //mockCart.Setup(s => s.setListOfProducts(It.IsAny<List<IProduct>>()));
            mockCart.Setup(s => s.takeAllProductsFromCart()).Returns(new List<IProduct> { sweet1 });


            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart.takeAllProductsFromCart());
            conveyor.printCheck();
            Console.ReadLine();
            
        }
    }
}
