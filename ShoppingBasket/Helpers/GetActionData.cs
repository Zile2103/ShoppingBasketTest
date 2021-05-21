using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.Helpers
{
    public class GetActionData
    {

       /// <summary>
       /// Returns all information about prices and numbers of Products in discount
       /// </summary>
       /// <param name="b">Basket Object</param>
       /// <returns>All basket info</returns>
        public static List<Basket> GetBasketInfo(List<Basket> b)
        {
            List<Basket> basketInfo = new List<Basket>();
            List<QuantityOfProducts> q = GetProductsAction(b);


            foreach (Basket i in b)
            {

                Basket bb = new Basket();
                switch (i.Id)
                {
                    case "B":
                        QuantityOfProducts qp = q.Where(x => x.Id == "B").FirstOrDefault();
                        bb.Id = i.Id;
                        bb.ProductName = i.ProductName;
                        bb.Price = i.Price;
                        bb.Quantity = qp.Quantity;
                        bb.SumWithDiscount = i.Price * qp.Quantity;
                        bb.Sum = i.Price * qp.Quantity;
                        bb.NumberOfActionProducts = 0;

                        basketInfo.Add(bb);
                        break;

                    case "M":
                        QuantityOfProducts qp1 = q.Where(x => x.Id == "M").FirstOrDefault();
                        bb.Id = i.Id;
                        bb.ProductName = i.ProductName;
                        bb.Price = i.Price;
                        bb.Quantity = qp1.Quantity;
                        bb.SumWithDiscount = i.Price * qp1.NonActionQuantity;
                        bb.Sum = i.Price * qp1.Quantity;
                        bb.NumberOfActionProducts = qp1.ActionQuantity;

                        basketInfo.Add(bb);
                        break;

                    case "BR":
                        QuantityOfProducts qp2 = q.Where(x => x.Id == "BR").FirstOrDefault();
                        bb.Id = i.Id;
                        bb.ProductName = i.ProductName;
                        bb.Price = i.Price;
                        bb.Quantity = qp2.Quantity;
                        bb.SumWithDiscount = i.Price / 2 * qp2.ActionQuantity + qp2.NonActionQuantity * i.Price;
                        bb.Sum = i.Price * qp2.Quantity;
                        bb.NumberOfActionProducts = qp2.ActionQuantity;
                        basketInfo.Add(bb);
                        break;
                }
            }


            return basketInfo;
        }

        /// <summary>
        /// Returns all information necessary for calculating discount
       /// </summary>
       /// <param name="b"></param>
       /// <returns>List of quantity</returns>
        public static List<QuantityOfProducts> GetProductsAction(List<Basket> b)
        {
            //Kolicine na akciji
            int bredActionNumber = 0;
            int milkActionNumber = 0;
            //Kolicine po punoj ceni. Margarin nema akciju
            int butterNumber = 0;
            int bredFullPrice = 0;
            int milkFullPrice = 0;                      

            //Izvlacimo kolicine Proizvoda iz korpe, UKUPNE KOLICINE za svaki proizvod

            int numberOfButter = b.Where(x => x.Id == "B").Select(x => x.Quantity).FirstOrDefault();
            int numberOfMilk = b.Where(x => x.Id == "M").Select (x => x.Quantity).FirstOrDefault();
            int numberOfBred = b.Where(x => x.Id == "BR").Select(x => x.Quantity).FirstOrDefault();

            
            butterNumber = numberOfButter;
            //Provera da li je paran broj uzetih margarina. Ako nije, oduzima se 1 i deli sa 2 da dobijemo max broj hleba na akciji.
            //Ako je broj uzetog hleba veci od maxNumberBredActio, popust ide na maxNumberBredActio a ostatak ide po punoj ceni.
            //Ako je broj uzetog hleba manji od maxNumberBredActio, onda je popust na celu uzetu kolicinu
            int a = numberOfButter % 2;
            //Provera da li ima ostatka pri deljenu sa 4. ako ima, ostatak se oduzima od ukupne kolicine mleka i preostalo se deli na 4 da dobijemo besplatnu kolicinu
            //Mleko koje je uzeto van akcije freeMilk * 3 + numberOfMilk
            int x = numberOfMilk % 4;



            int maxNumberBredActio = 0;
            


            if (numberOfButter > 1)
            {
               
                if (a < 1)
                {
                    maxNumberBredActio = numberOfButter / 2;
                }
                else
                {
                    maxNumberBredActio = (numberOfButter - 1) / 2;
                }
               
            }
            else
            {
                bredFullPrice = numberOfBred;
            }

            if (numberOfMilk > 3)
            {


                if (x > 0)
                {
                    milkActionNumber = (numberOfMilk - x) / 4;
                }
                else
                {
                    milkActionNumber = numberOfMilk / 4;
                }

                milkFullPrice = milkActionNumber * 3 + x;
            }
            else
            {
                milkFullPrice = numberOfMilk;
            }
            
            if (numberOfButter >= 2)
            {
                if (numberOfBred >= maxNumberBredActio)
                {
                    bredActionNumber = maxNumberBredActio;
                }
                else
                {
                    bredActionNumber = numberOfBred;
                }

                bredFullPrice = numberOfBred - bredActionNumber;
            }

            List<QuantityOfProducts> listOfQ = new List<QuantityOfProducts>();
           
            QuantityOfProducts q = new QuantityOfProducts {
                Id = "B",
                Quantity = numberOfButter,
                ActionQuantity = 0,
                NonActionQuantity = numberOfButter
            };
            QuantityOfProducts q1 = new QuantityOfProducts
            {
                Id = "M",
                Quantity = numberOfMilk,
                ActionQuantity = milkActionNumber,
                NonActionQuantity = milkFullPrice
            };
            QuantityOfProducts q2 = new QuantityOfProducts
            {
                Id = "BR",
                Quantity = numberOfBred,
                ActionQuantity = bredActionNumber,
                NonActionQuantity = bredFullPrice
            };

            listOfQ.Add(q);
            listOfQ.Add(q1);
            listOfQ.Add(q2);

            return listOfQ;            
        }              

    }
}
