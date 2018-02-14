using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double? Accumulator { get; private set; } = 0;


        public double Add(double a, double b)
        {
            Accumulator = a + b;
            return (double)Accumulator;
        }

        public double Subtract(double a, double b)
        {
            Accumulator = a - b;

            return (double) Accumulator;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = a * b;
            return (double) Accumulator;
        }

        public double Power(double x, double exp)
        {
            if (exp < 0)
            {
                Accumulator = null;
                throw new ArgumentException("You used a negative exponent");
            }
            Accumulator = Math.Pow(x, exp);
            return (double) Accumulator;
        }

        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                Accumulator = null;
                throw new DivideByZeroException("You divided by zero");
            }

            Accumulator = dividend / divisor;

            return (double) Accumulator;
        }

        public void Clear()
        {
            Accumulator = null;
        }
    }
}
