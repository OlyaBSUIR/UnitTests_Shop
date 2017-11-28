using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct
{
    public class Product : IProduct
    {
        private String _name;
        private int _price;
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Неверное наименование продукта");
                }
                _name = value;
            }
        }
        public int price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Неверное количество товара");
                }
                _price = value;
            }
        }
        public bool isOnSale { get; set; }
        public int countNeedToBuyForSale { get; set; }
        public int salePrice { get; set; }

        public Product(String name, int price, bool isOnSale = false, int countNeedToBuyForSale = 0, int salePrice = 0)
        {
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

