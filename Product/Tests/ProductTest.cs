using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProduct;
using System.Diagnostics;

namespace ProductTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Product_CreateNewProduct_CreatedNewProduct()
        {
            Product sweet = null;
            try
            {
                sweet = new Product("Конфеточки", 125, true, 3, 300);
                Assert.IsNotNull(sweet);
            }
            catch (ArgumentException)
            {
                Assert.Fail("No exception shoudn't be thrown");
            }
        }

        [TestMethod]
        public void Product_CreateNewProductWithWrongName_IsNotCreatedNewProduct()
        {
            String expected = "Incorrect name of product";
            Product sweet = null;
            try
            {
                sweet = new Product("", 125, true, 3, 300);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Product_CreateNewProductWithNullName_IsNotCreatedNewProduct()
        {
            String expected = "Incorrect name of product";
            Product sweet = null;
            try
            {
                sweet = new Product(null, 125, true, 3, 300);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        public void Product_CreateNewProductWithWrongPrice_IsNotCreatedNewProduct()
        {
            Product sweet = null;
            String expected = "Incorrect price for product";
            try
            {
                sweet = new Product("Конфеточки", -5, true, 3, 300);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
    }
}
