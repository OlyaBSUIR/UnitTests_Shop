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
            Product sweet = new Product("Конфеточки", 125, true, 3, 300);
            Assert.IsNotNull(sweet);
        }

        [TestMethod]
        public void Product_CreateNewProductWithWrongName_IsNotCreatedNewProduct()
        {
            Product sweet=null;
            try
            {
                sweet = new Product(null, 125, true, 3, 300);
            }
            catch(ArgumentException ex)
            {
                //Assert.Fail("Fail");
            }
            Assert.IsNull(sweet);
        }

        [TestMethod]
        public void Product_CreateNewProductWithWrongPrice_IsNotCreatedNewProduct()
        {
            Product sweet = null;
            try
            {
                sweet = new Product("Конфеточки", -5, true, 3, 300);
            }
            catch (ArgumentException ex)
            {
                //Assert.Fail("Fail");
            }
            Assert.IsNull(sweet);
        }
    }
}
