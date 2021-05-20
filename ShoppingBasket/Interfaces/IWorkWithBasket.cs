using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace ShoppingBasket.Interfaces
{
    interface IWorkWithBasket
    {
        /// <summary>
        /// Hardcoded values of products
        /// </summary>
        /// <returns>All hardcoded products</returns>
        IEnumerable<Product> AddProducts();       
        /// <summary>
        /// Method for viewing products and information in basket
        /// </summary>
        /// <param name="b"> Object basket</param>
        /// <returns>List of all products in basket with all information</returns>
        List<Basket> GetBasketProducts(List<Basket> b);
        /// <summary>
        /// Sum of basket without discount
        /// </summary>
        /// <param name="b">Basket Object</param>
        /// <returns> decimal sum</returns>
        decimal GetBasketSum(List<Basket> b);
        /// <summary>
        ///  Sum of basket with discount
        /// </summary>
        /// <param name="b">Basket Object</param>
        /// <returns> decimal sum</returns>
        decimal GetBasketSumDiscount(List<Basket> b);
        /// <summary>
        /// Remove all products from basket
        /// </summary>
        /// <param name="b">Basket Object</param>
        void ClearBasket(List<Basket> b);

    }
}
