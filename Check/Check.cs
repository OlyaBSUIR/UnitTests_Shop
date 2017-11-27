using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProduct;

namespace MyCheck
{
    public class Check
    {
        private List<Product> listOfProducts;
        private int totalSum;

        public Check()
        {
            listOfProducts = new List<Product>();
        }

        public void addToCheck(Product product, int count = 1)
        {
            for (int i = 0; i < count; i++ )
            {
                listOfProducts.Add(product);
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
            if (listOfProducts!=null)
            {
                foreach (Product product in listOfProducts )
                {
                    totalSum += product.price;
                }
            }
            return totalSum;
        }

    }
}
