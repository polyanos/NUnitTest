using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    class Discount
    {
        public int getDiscountPercentage(int amount)
        {
            int discount = 0;
            if (amount < 1)
            {
                throw new ArgumentException("Amount cannot be lower than one cent");
            }

            if (amount >= 1000 && amount < 5000)
            {
                discount = 15;
            }
            else if (amount >= 5000)
            {
                discount = 25;
            }

            return discount;
        }

        public int calculateFinalPrice(int amount, int discountPercentage)
        {
            if (discountPercentage > 99 || discountPercentage < 0)
            {
                throw new ArgumentException("Discount percentage cannot be higher than 99 or lower than 0");
            }
            if (amount < 1)
            {
                throw new ArgumentException("Amount cannot be lower than 1 cent");
            }

            return (int)Math.Round(amount * (100 - discountPercentage) / 100.0, 0);
        }
    }
}
