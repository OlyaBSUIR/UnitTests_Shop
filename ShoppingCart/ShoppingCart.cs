using MyProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingCart
{
    public class ShoppingCart
    {
        private List<Product> listOfProducts;
        private int totalSum;

        public ShoppingCart()
        {
            listOfProducts = new List<Product>();
        }

        public void addToCart(Product product, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                listOfProducts.Add(product);
            }
        }

        public Product takeFromCart()
        {
            Product product = listOfProducts.First();
            listOfProducts.Remove(product);
            return product;

        }

        public bool isEmpty()
        {
            return listOfProducts.Count==0;
        }

    }
}
