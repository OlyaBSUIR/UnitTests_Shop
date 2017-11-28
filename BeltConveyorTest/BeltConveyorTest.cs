using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShoppingCart;
using MyBeltConveyor;
using MyProduct;
using Moq;
using System.Collections.Generic;


namespace BeltConveyorTest
{
    [TestClass]
    public class BeltConveyorTest
    {
        private IShoppingCart cart;
        private IBeltConveyor conveyor;

        [TestInitialize]
        public void TestInitialize()
        {
            conveyor = new BeltConveyor();
            //cart = new ShoppingCartStub();
        }

        [TestMethod]
        public void beltConveyor_printCheck()
        {
            IProduct sweet;

            var mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(s => s.name).Returns("Конфеточки");
            mockProduct.SetupGet(s => s.price).Returns(125);


            sweet = mockProduct.Object;

            var mockCart = new Mock<IShoppingCart>();
            //mockCart.Setup(s => s.setListOfProducts(It.IsAny<List<IProduct>>()));
            mockCart.Setup(s => s.takeAllProductsFromCart()).Returns(new List<IProduct> {sweet});

            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart.takeAllProductsFromCart());
            conveyor.printCheck();

            mockProduct.VerifyAll();
        }

        [TestMethod]
        public void getTotalPrice_BuyThreeSweetWithPrice125_return300BecauseSale()
        {
            IProduct sweet;

            var mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(s => s.name).Returns("Конфеточки");
            mockProduct.SetupGet(s => s.price).Returns(125);
            mockProduct.SetupGet(s => s.isOnSale).Returns(true);
            mockProduct.SetupGet(s => s.countNeedToBuyForSale).Returns(3);
            mockProduct.SetupGet(s => s.salePrice).Returns(300);

            sweet = mockProduct.Object;

            var mockCart = new Mock<IShoppingCart>();
            //mockCart.Setup(s => s.setListOfProducts(It.IsAny<List<IProduct>>()));
            mockCart.Setup(s => s.takeAllProductsFromCart()).Returns(new List<IProduct> { sweet, sweet, sweet });


            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart.takeAllProductsFromCart());
            int expectedPrice = 300;
            int actualPrice = conveyor.getTotalPrice();
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void getTotalPrice_BuyFiveSweetWithPrice125_return550BecauseSale()
        {
            IProduct sweet = new Product("Конфеточки", 125, true, 3, 300);

            cart.addToCart(sweet, 5);
            conveyor.putCartOnTConveyor(cart);
            int expectedPrice = 550;
            int actualPrice = conveyor.getTotalPrice();
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void beltConveyor_BuyFiveSweetWithPrice125_return550BecauseSale()
        {
            IProduct sweet = new Product("Конфеточки", 125, true, 3, 300);
            cart.addToCart(sweet, 5);
            conveyor.putCartOnTConveyor(cart);
            int expectedPrice = 550;
            int actualPrice = conveyor.getTotalPrice();
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void getTotalPrice_BuyTwoSweetWithPrice125_return250NoSale()
        {
            IProduct sweet = new Product("Конфеточки", 125, true, 3, 300);
            cart.addToCart(sweet, 2);
            conveyor.putCartOnTConveyor(cart);
            int expectedPrice = 250;
            int actualPrice = conveyor.getTotalPrice();
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void getTotalPrice_BuyFourSweetsAndSevenApples_return1025()
        {
            IProduct sweet = new Product("Конфеточки", 125, true, 3, 300);
            cart.addToCart(sweet, 2);
            IProduct apple = new Product("Яблочки", 100, true, 6, 500);
            cart.addToCart(apple, 5);
            cart.addToCart(sweet, 2);
            cart.addToCart(apple, 2);
            conveyor.putCartOnTConveyor(cart);
            int expectedPrice = 1025;
            int actualPrice = conveyor.getTotalPrice();
            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}
