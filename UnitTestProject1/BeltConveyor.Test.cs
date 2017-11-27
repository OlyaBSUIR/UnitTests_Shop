using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProduct;
using MyShoppingCart;
using MyBeltConveyor;

namespace BeltConveyorTest
{
    [TestClass]
    public class BeltConveyorTest
    {
        [TestMethod]
        public void getTotalPrice_BuyThreeSweetWithPrice125_return300BecauseSale()
        {
            Product sweet = new Product("Конфеточки", 125, true, 3, 300);
            ShoppingCart cart = new ShoppingCart();
            cart.addToCart(sweet, 3);
            BeltConveyor conveyor = new BeltConveyor();
            conveyor.putCartOnTConveyor(cart);
            int expectedPrice = 300;
            int actualPrice = conveyor.getTotalPrice();
            Assert.AreEqual(expectedPrice, actualPrice);
        }

    }
}
