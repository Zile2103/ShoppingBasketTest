using ShoppingBasket.Functionalities;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithBasket wwb = new WorkWithBasket();
            List<Basket> listBasket = new List<Basket>();
            IEnumerable<Product> listProdukt = wwb.AddProducts();
            List<Basket> ViewBasket = new List<Basket>();

            //Prikaz proizvoda
            foreach (Product p in listProdukt)
            {
                Console.WriteLine(p.Id + " " + p.ProductName + " " + p.Price);
            }
            Console.WriteLine();
            Console.WriteLine("Unesite kolicinu Margarina: ");
            int kolicinaMargarina = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Unesite kolicinu Mleka: ");
            int kolicinaMleka = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Unesite kolicinu Hleba: ");
            int kolicinaHleba = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            //Punjenje korpe
            foreach (Product i in listProdukt)
            {
                switch (i.Id)
                {
                    case "B":
                        Basket br = new Basket { Id = i.Id, ProductName = i.ProductName, Price = i.Price, Quantity = kolicinaMargarina };
                        listBasket.Add(br);
                        break;
                    case "M":
                        Basket br1 = new Basket { Id = i.Id, ProductName = i.ProductName, Price = i.Price, Quantity = kolicinaMleka };
                        listBasket.Add(br1);
                        break;
                    case "BR":
                        Basket br2 = new Basket { Id = i.Id, ProductName = i.ProductName, Price = i.Price, Quantity = kolicinaHleba };
                        listBasket.Add(br2);
                        break;
                }
            }

            ViewBasket = wwb.GetBasketProducts(listBasket);
            //Prikaz korpe
            Console.WriteLine("Proizvodi u korpi:");
            Console.WriteLine();
            foreach (Basket i in ViewBasket)
            {
                Console.WriteLine("Proizvod: " + i.ProductName + " " + "Cena: " + i.Price + " " + "Kolicina: " + i.Quantity + " " + "Kolicina na akciji: " + i.NumberOfActionProducts + " " + "Cena sa popustom: " + i.SumWithDiscount + " " + "Cena bez popusta: " + i.Sum);
            }

            decimal cenaSaPopustom = wwb.GetBasketSumDiscount(listBasket);
            decimal cenaBezPopusta = wwb.GetBasketSum(listBasket);
            Console.WriteLine();
            Console.WriteLine("Ukupna Cena Korpe bez popusta: " + cenaBezPopusta);
            Console.WriteLine();
            Console.WriteLine("Ukupna Cena Korpe sa popustom: " + cenaSaPopustom);
            Console.WriteLine();
            Console.WriteLine("Ostvaren popust: " + (cenaBezPopusta - cenaSaPopustom));


        }
    }
}
