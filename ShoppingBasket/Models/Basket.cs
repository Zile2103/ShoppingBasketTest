using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Models
{
    public class Basket : Product
    {
        //Kolicina
        private int quantity;
        //Suma bez popusta
        private decimal sum;
        //Suma sa popustom
        private decimal sumWithDiscount;
        //Kolicina na popustu
        private int numberOfActionProducts;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }    
       
        public decimal Sum
        {            
            get { return Quantity * Price; }
            set { sum = value; }
        }
       
        public decimal SumWithDiscount
        {
            get { return sumWithDiscount; }
            set { sumWithDiscount = value; }
        }
       
        public int NumberOfActionProducts
        {
            get { return numberOfActionProducts; }
            set { numberOfActionProducts = value; }
        }

    }
}
