using FluentAssertions;
using ShoppingBasket.Helpers;
using ShoppingBasket.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestBasket
{
    public class TestBasket
    {

        [Theory]
        [ClassData(typeof(TestData))]
        public void TestTheoryClassQuantity(List<Basket> _basket, IEnumerable<QuantityOfProducts> _expected)
        {
            IEnumerable<QuantityOfProducts> result = GetActionData.GetProductsAction(_basket);

            result.Should().BeEquivalentTo(_expected);
        }

        public class TestData : IEnumerable<object[]>
        {

            static IEnumerable<Basket> Fill()
            {
                List<Basket> listBasket = new List<Basket>();
                Basket b = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 2 };
                Basket b1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 2 };
                Basket b2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 2 };

                listBasket.Add(b);
                listBasket.Add(b1);
                listBasket.Add(b2);
                return listBasket;

            }
            static IEnumerable<QuantityOfProducts> FillQ()
            {
                List<QuantityOfProducts> lq = new List<QuantityOfProducts>();
                QuantityOfProducts q = new QuantityOfProducts { Id = "B", ActionQuantity = 0, NonActionQuantity = 2, Quantity = 2 };
                QuantityOfProducts q1 = new QuantityOfProducts { Id = "M", ActionQuantity = 0, NonActionQuantity = 2, Quantity = 2 };
                QuantityOfProducts q2 = new QuantityOfProducts { Id = "BR", ActionQuantity = 1, NonActionQuantity = 1, Quantity = 2 };

                lq.Add(q);
                lq.Add(q1);
                lq.Add(q2);

                return lq;
            }
            static IEnumerable<Basket> Fill2()
            {
                List<Basket> listBasket = new List<Basket>();
                Basket b = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 5 };
                Basket b1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 7 };
                Basket b2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 15 };

                listBasket.Add(b);
                listBasket.Add(b1);
                listBasket.Add(b2);
                return listBasket;

            }
            static IEnumerable<QuantityOfProducts> FillQ2()
            {
                List<QuantityOfProducts> lq = new List<QuantityOfProducts>();
                QuantityOfProducts q = new QuantityOfProducts { Id = "B", ActionQuantity = 0, NonActionQuantity = 5, Quantity = 5 };
                QuantityOfProducts q1 = new QuantityOfProducts { Id = "M", ActionQuantity = 1, NonActionQuantity = 6, Quantity = 7 };
                QuantityOfProducts q2 = new QuantityOfProducts { Id = "BR", ActionQuantity = 2, NonActionQuantity = 13, Quantity = 15 };

                lq.Add(q);
                lq.Add(q1);
                lq.Add(q2);

                return lq;
            }
            static IEnumerable<Basket> Fill3()
            {
                List<Basket> listBasket = new List<Basket>();
                Basket b = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 120 };
                Basket b1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 135 };
                Basket b2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 38 };

                listBasket.Add(b);
                listBasket.Add(b1);
                listBasket.Add(b2);
                return listBasket;

            }

            static IEnumerable<QuantityOfProducts> FillQ3()
            {
                List<QuantityOfProducts> lq = new List<QuantityOfProducts>();
                QuantityOfProducts q = new QuantityOfProducts { Id = "B", ActionQuantity = 0, NonActionQuantity = 120, Quantity = 120 };
                QuantityOfProducts q1 = new QuantityOfProducts { Id = "M", ActionQuantity = 33, NonActionQuantity = 102, Quantity = 135 };
                QuantityOfProducts q2 = new QuantityOfProducts { Id = "BR", ActionQuantity = 38, NonActionQuantity = 0, Quantity = 38 };

                lq.Add(q);
                lq.Add(q1);
                lq.Add(q2);

                return lq;
            }


            public IEnumerator<object[]> GetEnumerator()
            {




                yield return new object[] { Fill(), FillQ() };
                yield return new object[] { Fill2(), FillQ2() };
                yield return new object[] { Fill3(), FillQ3() };

            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }

    public class TestSum
    {

        [Theory]
        [ClassData(typeof(TestData))]
        public void TestTheoryClassSum(List<Basket> _basket, IEnumerable<Basket> _expected)
        {
            IEnumerable<Basket> result = GetActionData.GetBasketInfo(_basket);

            result.Should().BeEquivalentTo(_expected);
        }

        public class TestData : IEnumerable<object[]>
        {

            static IEnumerable<Basket> Fill()
            {
                List<Basket> listBasket = new List<Basket>();
                Basket b = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 2 };
                Basket b1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 2 };
                Basket b2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 2 };

                listBasket.Add(b);
                listBasket.Add(b1);
                listBasket.Add(b2);
                return listBasket;

            }
            static IEnumerable<Basket> FillQ()
            {
                List<Basket> lq = new List<Basket>();
                Basket q = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 2, SumWithDiscount = 1.6M, Sum = 1.6M, NumberOfActionProducts = 0 };
                Basket q1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 2, SumWithDiscount = 2.3M, Sum = 2.3M, NumberOfActionProducts = 0 };
                Basket q2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 2, SumWithDiscount = 1.5M, Sum = 2.00M, NumberOfActionProducts = 1 };

                lq.Add(q);
                lq.Add(q1);
                lq.Add(q2);

                return lq;
            }
            static IEnumerable<Basket> Fill2()
            {
                List<Basket> listBasket = new List<Basket>();
                Basket b = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 5 };
                Basket b1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 7 };
                Basket b2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 15 };

                listBasket.Add(b);
                listBasket.Add(b1);
                listBasket.Add(b2);
                return listBasket;

            }
            static IEnumerable<Basket> FillQ2()
            {
                List<Basket> lq = new List<Basket>();
                Basket q = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 5, SumWithDiscount = 4.00M, Sum = 4.00M, NumberOfActionProducts = 0 };
                Basket q1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 7, SumWithDiscount = 6.9M, Sum = 8.05M, NumberOfActionProducts = 1 };
                Basket q2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 15, SumWithDiscount = 14.00M, Sum = 15.00M, NumberOfActionProducts = 2 };

                lq.Add(q);
                lq.Add(q1);
                lq.Add(q2);

                return lq;
            }
            static IEnumerable<Basket> Fill3()
            {
                List<Basket> listBasket = new List<Basket>();
                Basket b = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 120 };
                Basket b1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 135 };
                Basket b2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 118 };

                listBasket.Add(b);
                listBasket.Add(b1);
                listBasket.Add(b2);
                return listBasket;

            }

            static IEnumerable<Basket> FillQ3()
            {
                List<Basket> lq = new List<Basket>();
                Basket q = new Basket { Id = "B", ProductName = "Butter", Price = 0.8M, Quantity = 120, SumWithDiscount = 96.00M, Sum = 96.00M, NumberOfActionProducts = 0 };
                Basket q1 = new Basket { Id = "M", ProductName = "Milk", Price = 1.15M, Quantity = 135, SumWithDiscount = 117.3M, Sum = 155.25M, NumberOfActionProducts = 33 };
                Basket q2 = new Basket { Id = "BR", ProductName = "Bread", Price = 1.00M, Quantity = 118, SumWithDiscount = 88.00M, Sum = 118.00M, NumberOfActionProducts = 60 };

                lq.Add(q);
                lq.Add(q1);
                lq.Add(q2);

                return lq;
            }


            public IEnumerator<object[]> GetEnumerator()
            {




                yield return new object[] { Fill(), FillQ() };
                yield return new object[] { Fill2(), FillQ2() };
                yield return new object[] { Fill3(), FillQ3() };

            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
