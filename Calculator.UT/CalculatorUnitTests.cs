using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorUnitTest
    {


        [Test]
        public void Add_Add2And4_Returns6()
        {
            var utt = new Calculator();

            Assert.That(utt.Add(2, 4), Is.EqualTo(6));
        }

        [Test]
        public void Add_AddMinus2And4_Returns2()
        {
            var utt = new Calculator();

            Assert.That(utt.Add(-2, 4), Is.EqualTo(2)); //2
        }

        [Test]
        public void Subtract_Subtract6And4_Returns2()
        {
            var utt = new Calculator();

            Assert.That(utt.Subtract(6, 4), Is.EqualTo(2));
        }

        [Test]
        public void Multiply_Multiply3And4_Returns12()
        {
            var utt = new Calculator();

            Assert.That(utt.Multiply(3, 4), Is.EqualTo(12));
        }

        [Test]
        public void Power_Power3raised4_Returns81()
        {
            var utt = new Calculator();

            Assert.That(utt.Power(3, 4), Is.EqualTo(81));
        }

        // Testcase
        [Test, TestCaseSource(typeof(CalculatorTestClass), nameof(CalculatorTestClass.Add_SimpleCalculations))]
        public double Add_Add_SimpleCalculations(double a, double b)
        {
            var utt = new Calculator();

            return utt.Add(a, b);
        }

        // Testcase (a + b, expected = c)
        [TestCase(2, 4, 6)]
        [TestCase(3, 5, 8)]
        [TestCase(-1, -1, -2)]
        public void Add_Add_SimpleCalculations_Alternative(double a, double b, double expected)
        {
            var utt = new Calculator();

            Assert.That(utt.Add(a, b), Is.EqualTo(expected));

        }
    }

    public class CalculatorTestClass
    {
        public static IEnumerable Add_SimpleCalculations
        {
            get
            {
                yield return new TestCaseData(2, 4).Returns(6);
                yield return new TestCaseData(3, 5).Returns(8);
                yield return new TestCaseData(-1, -1).Returns(-2);

            }
        }
    }
}
