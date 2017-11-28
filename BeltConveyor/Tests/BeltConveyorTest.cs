using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShoppingCart;
using MyBeltConveyor;
using MyProduct;
using Moq;
using System.Collections.Generic;


namespace MyBeltConveyor
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
        }

        [TestMethod]
        public void PrintCheck_CheckPrinted()
        {
            IProduct sweet;
            var mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(s => s.name).Returns("Конфеточки");
            mockProduct.SetupGet(s => s.price).Returns(125);
            sweet = mockProduct.Object;
            var mockCart = new Mock<IShoppingCart>();
            mockCart.Setup(s => s.takeAllProductsFromCart()).Returns(new List<IProduct> { sweet });
            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart.takeAllProductsFromCart());

            conveyor.printCheck();

            mockProduct.VerifyAll();
        }

        [TestMethod]
        public void GetTotalPrice_BuyThreeSweetWithPrice125_Return300BecauseOfSale()
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
            mockCart.Setup(s => s.takeAllProductsFromCart()).Returns(new List<IProduct> { sweet, sweet, sweet });
            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart.takeAllProductsFromCart());
            int expectedPrice = 300;

            int actualPrice = conveyor.getTotalPrice();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void GetTotalPrice_BuyFiveSweetWithPrice125_Return550BecauseOfSale()
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
            mockCart.Setup(s => s.takeAllProductsFromCart()).Returns(new List<IProduct> { sweet, sweet, sweet, sweet, sweet });
            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart.takeAllProductsFromCart());
            int expectedPrice = 550;

            int actualPrice = conveyor.getTotalPrice();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void GetTotalPrice_BuyTwoSweetWithPrice125_Return250NoSale()
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
            mockCart.Setup(s => s.takeAllProductsFromCart()).Returns(new List<IProduct> { sweet, sweet });
            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart.takeAllProductsFromCart());
            int expectedPrice = 250;

            int actualPrice = conveyor.getTotalPrice();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void GetTotalPrice_BuyFourSweetsAndSevenApples_Return1025()
        {
            IProduct sweet;
            var mockSweet = new Mock<IProduct>();
            mockSweet.SetupGet(s => s.name).Returns("Конфеточки");
            mockSweet.SetupGet(s => s.price).Returns(125);
            mockSweet.SetupGet(s => s.isOnSale).Returns(true);
            mockSweet.SetupGet(s => s.countNeedToBuyForSale).Returns(3);
            mockSweet.SetupGet(s => s.salePrice).Returns(300);
            sweet = mockSweet.Object;
            IProduct apple;
            var mockApple = new Mock<IProduct>();
            mockApple.SetupGet(s => s.name).Returns("Яблочки");
            mockApple.SetupGet(s => s.price).Returns(100);
            mockApple.SetupGet(s => s.isOnSale).Returns(true);
            mockApple.SetupGet(s => s.countNeedToBuyForSale).Returns(6);
            mockApple.SetupGet(s => s.salePrice).Returns(500);
            apple = mockApple.Object;
            var mockCart = new Mock<IShoppingCart>();
            mockCart.Setup(s => s.takeAllProductsFromCart()).Returns(new List<IProduct> { sweet, sweet, sweet, sweet, apple, apple, apple, apple, apple, apple, apple });
            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart.takeAllProductsFromCart());
            int expectedPrice = 1025;

            int actualPrice = conveyor.getTotalPrice();
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void PutCartOnTConveyor_putCart_CartIsOnConveyor()
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
            mockCart.Setup(s => s.takeFromCart()).Returns(It.IsAny<IProduct>);
            mockCart.SetupSequence(m => m.isEmpty()).Returns(false).Returns(false).Returns(true);
            mockCart.Object.addToCart(sweet, 2);

            cart = mockCart.Object;
            conveyor.putCartOnTConveyor(cart);


            mockCart.Verify(v => v.isEmpty());
            mockCart.Verify(v => v.takeFromCart());

        }
    }
}
