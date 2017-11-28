using MyProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingCart
{
    public class ShoppingCart : IShoppingCart
    {
        private List<IProduct> listOfProducts= new List<IProduct>();

        public List<IProduct> takeAllProductsFromCart()
        {
            return listOfProducts;
        }

        public void addToCart(IProduct product, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                listOfProducts.Add(product);
            }
        }

        public IProduct takeFromCart()
        {
            IProduct product = listOfProducts.First();
            listOfProducts.Remove(product);
            return product;
        }

        public bool isEmpty()
        {
            return listOfProducts.Count==0;
        }

    }
}
