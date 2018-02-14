using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double? Accumulator { get; private set; } = null;


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


        // Overloads
        public double Add(double addend)
        {
            if (Accumulator == null)
            {
                throw new ArgumentException("You need to use a standard expression from Calculator, before using shorthand calculations");
            }
            return Add((double) Accumulator, addend);
        }

        public double Subtract(double subtractor)
        {
            if (Accumulator == null)
            {
                throw new ArgumentException("You need to use a standard expression from Calculator, before using shorthand calculations");
            }
            return Subtract((double)Accumulator, subtractor);
        }

        public double Multiply(double multiplier)
        {
            if (Accumulator == null)
            {
                throw new ArgumentException("You need to use a standard expression from Calculator, before using shorthand calculations");
            }
            return Multiply((double)Accumulator, multiplier);
        }

        public double Divide(double divisor)
        {
            if (Accumulator == null)
            {
                throw new ArgumentException("You need to use a standard expression from Calculator, before using shorthand calculations");
            }

            return Divide((double)Accumulator, divisor);
        }

        public double Power(double exponent)
        {
            if (Accumulator == null)
            {
                throw new ArgumentException("You need to use a standard expression from Calculator, before using shorthand calculations");
            }

            return Power((double)Accumulator, exponent);
        }
    }
}
