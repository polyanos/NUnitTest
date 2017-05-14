using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTest
{
    [TestFixture]
    class NunitTests
    {
        private const string bm = "Basic Math";
        private const string fu = "Fubonacci";
        private const string di = "Discount";
        private const string dii = "Discount Intergration";

        private Calculator calc;
        private Discount discount;

        [OneTimeSetUp]
        public void TestSetup()
        {
            calc = new Calculator();
            discount = new Discount();
        }

        [OneTimeTearDown]
        public void TestTeardown()
        {
            calc = null;
            discount = null;
        }

        //Basic Math Functions
        [TestCase(3, 5, ExpectedResult = 8)]
        [TestCase(1, 4, ExpectedResult = 5)]
        [TestCase(30, 60, ExpectedResult = 90)]
        [Category(bm)]
        public int AddTest(int a, int b)
        {
            return calc.Add(a, b);
        }

        [TestCase(1, 9, ExpectedResult = -8)]
        [TestCase(25, 9, ExpectedResult = 16)]
        [TestCase(100, 100, ExpectedResult = 0)]
        [Category(bm)]
        public int SubstractTest(int a, int b)
        {
            return calc.Subtract(a, b);
        }

        //Fibonacci
        [TestCase(1, ExpectedResult = new int[] { 0 })]
        [TestCase(8, ExpectedResult = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 })]
        [Category(fu)]
        public int[] FibonacciSuccessTest(int length)
        {
            return calc.Fibonacci(length);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [Category(fu)]
        public void FibonacciThrowTest(int length)
        {
            Assert.Throws<ArgumentException>(() => calc.Fibonacci(length));
        }

        //Discount
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(100, ExpectedResult = 0)]
        [TestCase(999, ExpectedResult = 0)]
        [TestCase(1000, ExpectedResult = 15)]
        [TestCase(1001, ExpectedResult = 15)]
        [TestCase(4999, ExpectedResult = 15)]
        [TestCase(5000, ExpectedResult = 25)]
        [TestCase(5001, ExpectedResult = 25)]
        [TestCase(10000, ExpectedResult = 25)]
        [Category(di)]
        public int DiscountSuccessTest(int amount)
        {
            return discount.getDiscountPercentage(amount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        [Category(di)]
        public void DiscountArgumentFailTest(int amount)
        {
            Assert.Throws<ArgumentException>(() => discount.getDiscountPercentage(amount));
        }

        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(2500, 15, ExpectedResult = 2125)]
        [TestCase(50000, 5, ExpectedResult = 47500)]
        [Category(di)]
        public int DiscountedPriceSuccessTest(int amount, int discountPercentage)
        {
            return discount.calculateFinalPrice(amount, discountPercentage);
        }

        [TestCase(0, -1)]
        [TestCase(2523, -1)]
        [TestCase(0, 15)]
        [TestCase(-2000, 15)]
        [TestCase(2500, -15)]
        [TestCase(6500, 100)]
        [TestCase(5500, 101)]
        [Category(di)]
        public void DiscountPriceArgumentFailTest(int amount, int discountPercentage)
        {
            Assert.Throws<ArgumentException>(() => discount.calculateFinalPrice(amount, discountPercentage));
        }

        //Discount Intergration
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(100, ExpectedResult = 100)]
        [TestCase(999, ExpectedResult = 999)]
        [TestCase(1000, ExpectedResult = 850)]
        [TestCase(1001, ExpectedResult = 851)]
        [TestCase(4999, ExpectedResult = 4249)]
        [TestCase(5000, ExpectedResult = 3750)]
        [TestCase(5001, ExpectedResult = 3751)]
        [TestCase(6000, ExpectedResult = 4500)]
        [Category(dii)]
        public int DiscountIntergrationSuccessTest(int amount)
        {
            int percentage = discount.getDiscountPercentage(amount);
            return discount.calculateFinalPrice(amount, percentage);
        }
    }
}
