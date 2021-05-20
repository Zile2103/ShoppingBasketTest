using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Models
{
    public class Product
    {
        private string productName;
        private decimal price;

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }       

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Product(string id,string name, decimal price)
        {
            Id = id;
            ProductName = name;
            Price = price;
        }

        public Product() { }


    }
}
