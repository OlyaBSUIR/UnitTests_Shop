using MyBeltConveyor;
using MyProduct;
using MyShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeltConveyor
{
    public class BeltConveyor : IBeltConveyor
    {
        private IShoppingCart cart;
        private int totalSum;

        private List<IProduct> listOfProducts;

        public void putCartOnTConveyor(List<IProduct> products)
        {
            listOfProducts = products;
        }

        public void putCartOnTConveyor(IShoppingCart cart)
        {
            if (!cart.isEmpty())
            {
                this.cart = cart;
                scanCart();
            }
        }

        private void scanCart()
        {
            listOfProducts = new List<IProduct>();
            while (!cart.isEmpty())
            {
                listOfProducts.Add(cart.takeFromCart());
            }
        }

        public int getTotalPrice()
        {
            var listOfProducts = new List<IProduct>();
            totalSum = 0;
            foreach (IProduct product in this.listOfProducts)
            {
                listOfProducts.Add(product);
            }

            var listOfSaleProduct = listOfProducts.Where(t => t.isOnSale == true);
            if (listOfSaleProduct != null)
            {
                while (listOfSaleProduct.Count() != 0)
                {
                    IProduct product = listOfSaleProduct.First();
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
                        totalSum += listOfOneKindProduct.Count() * product.price;
                    }
                    listOfProducts.RemoveAll(p => p.name == product.name);

                }

            }
            if (listOfProducts != null)
            {
                foreach (IProduct product in listOfProducts)
                {
                    totalSum += product.price;
                }
            }
            return totalSum;
        }

        private int priceWithoutSale()
        {
            int sum = 0;
            foreach (IProduct product in listOfProducts)
            {
                sum += product.price;
            }
            return sum;
        }

        public void printCheck()
        {
            foreach (IProduct product in listOfProducts)
            {
                Console.WriteLine("Продукт: {0} , стоимость: {1}", product.name, product.price);
            }
            Console.WriteLine("Общая цена: {0}", priceWithoutSale());
            Console.WriteLine("Цена со скидкой: {0}", getTotalPrice());
        }
    }
}
