using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProduct;
using MyShoppingCart;
using System.Diagnostics;
using System.Collections.Generic;
using Moq;

namespace ShoppinCart.Test
{

    [TestClass]
    public class ShoppinCartTest
    {
        private IShoppingCart cart;
        private IProduct sweet;

        // Запускается перед стартом каждого тестирующего метода
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
        public void ShoppingCart_addToCart_ContainsProduct()
        {
            cart.addToCart(sweet);
            Assert.AreNotEqual(true, cart.isEmpty());
        }

        [TestMethod]
        public void ShopingCart_takeFromCart_Empty()
        {
            bool expected = true;
            cart.addToCart(sweet);
            cart.takeFromCart();

            bool actual = cart.isEmpty();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShopingCart_takeFromCart_ProductsEquals()
        {
            cart.addToCart(sweet, 1);
            IProduct product = cart.takeFromCart();

            Assert.AreEqual(sweet, product);
        }

        [TestMethod]
        public void ShopingCart_isEmpty_EmptyCart()
        {
            cart.addToCart(sweet, 1);
            IProduct product = cart.takeFromCart();

            Assert.AreEqual(cart.isEmpty(), true);
        }

        [TestMethod]
        public void ShopingCart_takeAllProductsFromCart_returnTwoProduct()
        {
            List<IProduct> product = cart.takeAllProductsFromCart();
            cart.addToCart(sweet, 2);
            Assert.AreEqual(product.Count, 2);
        }
    }
}
