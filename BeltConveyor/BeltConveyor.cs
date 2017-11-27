using MyProduct;
using MyShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeltConveyor
{
    public class BeltConveyor
    {
        private ShoppingCart cart;
        private int totalSum;
        
        private List<Product> listOfProducts;

        public void putCartOnTConveyor(ShoppingCart cart)
        {
            this.cart = cart;
            scanCart();
        }

        private void scanCart()
        {
            listOfProducts = new List<Product>();
            while (!cart.isEmpty())
            {
                listOfProducts.Add(cart.takeFromCart());
            }
        }
        
        public int getTotalPrice()
        {
            var listOfProducts = this.listOfProducts;

            var listOfSaleProduct = listOfProducts.Where(t => t.isOnSale == true);
            if (listOfSaleProduct != null)
            {
                while (listOfSaleProduct.Count() != 0)
                {
                    Product product = listOfSaleProduct.First();
                    var listOfOneKindProduct = listOfSaleProduct.Where(t => t.name == product.name);
                    if (listOfOneKindProduct.Count() >= product.countNeedToBuyForSale)
                    {
                        totalSum += (listOfOneKindProduct.Count() / product.countNeedToBuyForSale) * product.salePrice;
                        if (listOfOneKindProduct.Count() % product.countNeedToBuyForSale != 0)
                        {
                            totalSum += (listOfOneKindProduct.Count() % product.countNeedToBuyForSale) * product.price;
                        }
                    }
                    else
                    {
                        totalSum += listOfOneKindProduct.Count() * product.salePrice;
                    }
                    listOfProducts.RemoveAll(p => p.name == product.name);

                }

            }
            if (listOfProducts != null)
            {
                foreach (Product product in listOfProducts)
                {
                    totalSum += product.price;
                }
            }
            return totalSum;
        }
    }
}
