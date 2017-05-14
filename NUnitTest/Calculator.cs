using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int[] Fibonacci(int length)
        {
            if(length < 1)
            {
                throw new ArgumentException("Length must be bigger than zero (0)");
            }

            var result = new int[length];
            int current = 0;
            int next = 1;
            int temp = 0;
            int i = 0;
            while(i < length)
            {
                result[i] = current;
                temp = next;
                next = current + next;
                current = temp;
                i++;
            }

            return result;
        }
    }
}
