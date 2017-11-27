using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProduct;
using MyShoppingCart;
using System.Diagnostics;

namespace ShoppinCart.Test
{
    [TestClass]
    public class ShoppinCartTest
    {
        private ShoppingCart cart;
        private Product sweet;

        // Запускается перед стартом каждого тестирующего метода
        [TestInitialize]
        public void TestInitialize()
        {
            sweet = new Product("Конфеточки", 125, true, 3, 300);
            cart = new ShoppingCart();
            cart.addToCart(sweet);
        }

        [TestMethod]
        public void ShoppingCart_addToCart_ContainsProduct()
        {
            Assert.AreNotEqual(true, cart.isEmpty());
        }

        [TestMethod]
        public void ShopingCart_takeFromCart_Empty()
        {
            bool expected = true;
            cart.takeFromCart();

            bool actual = cart.isEmpty();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShopingCart_takeFromCart_ProductsEquals()
        {
            Product product = cart.takeFromCart();
            Assert.AreEqual(sweet, product);
        }
    }
}
