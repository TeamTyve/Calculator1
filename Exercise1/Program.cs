using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    //Exercise 1: Implement class Calculator
    class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
     
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Power(double x, double exp)
        {
            return Math.Pow(x, exp);
        }
    }

    //Exercise 2: Test the class - Explaining is in OneNote
    class Program
    {
        static void Main(string[] args)
        {
            Calculator newCalculator = new Calculator();

            double sum = newCalculator.Add(2, 5);
            Console.WriteLine(sum);                     //7

            double sum1 = newCalculator.Add('b', 3);    
            Console.WriteLine(sum1);                    //error - Forkert -> Bliver 101 da den tager ASCII værdien for b = 98


            double sum2 = newCalculator.Add(-4, 3);
            Console.WriteLine(sum2);                    //-1

            double sum3 = newCalculator.Add(-3, -6);
            Console.WriteLine(sum3);                    //-9

            double sum4 = newCalculator.Add(1111111111, 1);
            Console.WriteLine(sum4);                    //1111111112

        }
    }

 
}


