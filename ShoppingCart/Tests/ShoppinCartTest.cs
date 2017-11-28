using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProduct;
using MyShoppingCart;
using System.Diagnostics;
using System.Collections.Generic;
using Moq;

namespace MyShoppingCart
{
    [TestClass]
    public class ShoppinCartTest
    {
        private IShoppingCart cart;
        private IProduct sweet;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockProduct = new Mock<IProduct>();
            mockProduct.SetupGet(s => s.name).Returns("Конфеточки");
            mockProduct.SetupGet(s => s.price).Returns(125);
            mockProduct.SetupGet(s => s.isOnSale).Returns(true);
            mockProduct.SetupGet(s => s.countNeedToBuyForSale).Returns(3);
            mockProduct.SetupGet(s => s.salePrice).Returns(300);
            sweet = mockProduct.Object;

            cart = new ShoppingCart();
        }

        [TestMethod]
        public void GetCountOfProductsInCart_PutOneProduct_ContainsOneProduct()
        {
            int expected = 1;
            cart.addToCart(sweet);

            int actual = cart.getCountOfProductsInCart();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShoppingCart_AddToCart_ContainsProduct()
        {
            bool expected = false;

            cart.addToCart(sweet);

            bool actual = cart.isEmpty();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShopingCart_TakeFromCart_CartIsEmpty()
        {
            bool expected = true;

            cart.addToCart(sweet);
            cart.takeFromCart();

            bool actual = cart.isEmpty();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShopingCart_TakeFromCart_ProductsEquals()
        {
            IProduct expected = sweet;

            cart.addToCart(sweet, 1);
            IProduct actual = cart.takeFromCart();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShopingCart_IsEmpty_EmptyCart()
        {
            bool expected = true;

            cart.addToCart(sweet);
            cart.takeFromCart();

            bool actual = cart.isEmpty();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShopingCart_TakeAllProductsFromCart_ReturnTwoProduct()
        {
            int expected = 2;
            cart.addToCart(sweet, 2);

            List<IProduct> product = cart.takeAllProductsFromCart();
            int actual = cart.getCountOfProductsInCart();

            Assert.AreEqual(expected, actual);
        }
    }
}
