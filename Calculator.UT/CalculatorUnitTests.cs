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
        private Calculator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Calculator();
        }


        [Test]
        public void Add_Add2And4_Returns6()
        {

            Assert.That(_uut.Add(2, 4), Is.EqualTo(6));
        }

        [Test]
        public void Add_AddMinus2And4_Returns2()
        {
            _uut = new Calculator();

            Assert.That(_uut.Add(-2, 4), Is.EqualTo(2)); //2
        }

        [Test]
        public void Subtract_Subtract6And4_Returns2()
        {
            _uut = new Calculator();

            Assert.That(_uut.Subtract(6, 4), Is.EqualTo(2));
        }

        [Test]
        public void Multiply_Multiply3And4_Returns12()
        {
            _uut = new Calculator();

            Assert.That(_uut.Multiply(3, 4), Is.EqualTo(12));
        }

        [Test]
        public void Power_Power3raised4_Returns81()
        {
            _uut = new Calculator();

            Assert.That(_uut.Power(3, 4), Is.EqualTo(81));
        }

        // Testcase
        [Test, TestCaseSource(typeof(CalculatorTestClass), nameof(CalculatorTestClass.Add_SimpleCalculations))]
        public double Add_Add_SimpleCalculations(double a, double b)
        {
            _uut = new Calculator();

            return _uut.Add(a, b);
        }

        // Testcase (a + b, expected = c)
        [TestCase(2, 4, 6)]
        [TestCase(3, 5, 8)]
        [TestCase(-1, -1, -2)]
        public void Add_Add_SimpleCalculations_Alternative(double a, double b, double expected)
        {
            _uut = new Calculator();

            Assert.That(_uut.Add(a, b), Is.EqualTo(expected));

        }

<<<<<<< HEAD
        [TestCase(0, 1, "You divided by zero")]
        [TestCase(1, 0, "You divided by zero")]
        [TestCase(0, 0, "You divided by zero")]
        public void Division_Div0by0_Throws_DivideByZeroException(double divinend, double divisor, string expected)
        {
            var ex = Assert.Catch<DivideByZeroException>(() => _uut.Divide(divinend, divisor));

            StringAssert.Contains(expected, ex.Message);
        }

        [TestCase(2, 2, 1)]
        [TestCase(4, 2, 2)]
        [TestCase(1, 2, 0.5)]
        public void Division_Div_Simplecalculations(double divinend, double divisor, double expected)
        {
            Assert.That(_uut.Divide(divinend, divisor), Is.EqualTo(expected));
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