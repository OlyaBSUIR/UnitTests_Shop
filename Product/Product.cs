using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct
{
    public class Product
    {
        public String name { get; set; }
        public int price { get; set; }
        public bool isOnSale { get; set; }
        public int countNeedToBuyForSale { get; set; }
        public int salePrice { get; set; }

        public Product(String name, int price, bool isOnSale = false, int countNeedToBuyForSale = 0, int salePrice = 0)
        {
            if (name == null || name == "")
            {
                throw new ArgumentException("Неверное наименование продукта");
            }
            if (price <= 0)
            {
                throw new ArgumentException("Неверное количество товара");
            }
            this.name = name;
            this.price = price;
            this.isOnSale = isOnSale;
            this.countNeedToBuyForSale = countNeedToBuyForSale;
            this.salePrice = salePrice;
        }


        /* public override bool Equals(object obj)
         {
             if (obj == null)
                 return false;
             Product product = obj as Product; // возвращает null если объект нельзя привести к типу Money
             if (product as Product == null)
                 return false;

             return (product.name == this.name) && (product.price == this.price);
         }*/
    }
}

