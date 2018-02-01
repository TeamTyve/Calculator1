using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double Accumulator { get; private set; } = 0;


        public double Add(double a, double b)
        {
            Accumulator = a + b;
            return Accumulator;

        }

        public double Subtract(double a, double b)
        {
            Accumulator = a - b;

            return Accumulator;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = a - b;
            return Accumulator;
        }

        public double Power(double x, double exp)
        {
            if (exp < 0)
            {
                throw new InvalidOperationException("You used a negative exponent");
            }
            Accumulator = Math.Pow(x, exp);
            return Accumulator;
        }

        public double Divide(double dividend, double divisor)
        {
            if (dividend == 0 || divisor == 0)
            {
                throw new DivideByZeroException("You divided by zero");
            }

            Accumulator = dividend / divisor;

            return Accumulator;
        }

        public void Clear()
        {
            Accumulator = 0;
        }
    }
}
