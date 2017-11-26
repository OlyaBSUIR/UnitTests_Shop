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

        public void addToCheck(Product product)
        {
            listOfProducts.Add(product);
        }

        public int getTotalPrice()
        {
            return 0;
            //var listOfSaleProduct
        }

    }
}
