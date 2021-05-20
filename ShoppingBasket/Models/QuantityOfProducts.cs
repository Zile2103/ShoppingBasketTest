using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Models
{
    public class QuantityOfProducts
    {
        private string id;
        private int quantity;
        private int actionQuantity;
        private int nonActionQuantity;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }      

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }       

        public int ActionQuantity
        {
            get { return actionQuantity; }
            set { actionQuantity = value; }
        }        

        public int NonActionQuantity
        {
            get { return nonActionQuantity; }
            set { nonActionQuantity = value; }
        }




    }
}
