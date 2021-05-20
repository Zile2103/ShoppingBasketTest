using ShoppingBasket.Helpers;
using ShoppingBasket.Interfaces;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Functionalities
{
    public class WorkWithBasket : IWorkWithBasket
    {
       
        public decimal GetBasketSumDiscount(List<Basket> b)
        {
            decimal sumAllInBasket = 0M;
            List<Basket> listBasket = GetActionData.GetBasketInfo(b);

            if (listBasket != null)
            {
                foreach (Basket i in listBasket)
                {
                    sumAllInBasket += i.SumWithDiscount;
                }
            }
           
            return sumAllInBasket;
        }

        
        public List<Basket> GetBasketProducts(List<Basket> b)
        {
            List<Basket> listInfo = GetActionData.GetBasketInfo(b);
           
            return listInfo;
        }

       
        public IEnumerable<Product> AddProducts()
        {
            List<Product> listProducts = new List<Product>();

            Product p = new Product("B","Butter", 0.8M);
            Product p1 = new Product("M","Milk", 1.15M);
            Product p2 = new Product("BR","Bread", 1.00M);

            listProducts.Add(p);
            listProducts.Add(p1);
            listProducts.Add(p2);

            return listProducts;
        }

       
        public void ClearBasket(List<Basket> b)
        {
            b.Clear();
        }
       
        
        public decimal GetBasketSum(List<Basket> b)
        {
            decimal sum = 0;
            foreach (Basket i in b)
            {
                sum += i.Sum;
            }
            return sum;
        }
    }
}
