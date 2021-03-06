﻿using System;
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


        [TestCase(2, 4, 6)]
        [TestCase(-2, 4, 2)]
        [TestCase(-2, -4, -6)]
        public void Add_SimpleCalculatons_NoThrow(double a, double b, double expected)
        {
            Assert.That(_uut.Add(a, b), Is.EqualTo(expected));
        }

        [TestCase(2, 4, -2)]
        [TestCase(-2, 4, -6)]
        [TestCase(-2, -4, 2)]
        [TestCase(6, 4, 2)]
        public void Subtract_SimpleCalculatons_NoThrow(double a, double b, double expected)
        {
            Assert.That(_uut.Subtract(a, b), Is.EqualTo(expected));
        }

        [TestCase(3, 4, 12)]
        [TestCase(3, -3, -9)]
        [TestCase(5, 0, 0)]
        public void Multiply_SimpleCalculatons_NoThrow(double a, double b, double expected)
        {
            Assert.That(_uut.Multiply(a, b), Is.EqualTo(expected));
        }

        [TestCase(3, 2, 9)]
        [TestCase(3, 3, 27)]
        [TestCase(5, 1, 5)]
        [TestCase(5, 0, 1)]
        public void Power_SimpleCalculatons_NoThrow(double a, double exp, double expected)
        {
            Assert.That(_uut.Power(a, exp), Is.EqualTo(expected));
        }

        [TestCase(2, -1, "You used a negative exponent")]
        public void Power_ExpBelowZero_ThrowsInvalidArgumentException(double a, double exp, string expected)
        {
            var ex = Assert.Catch<ArgumentException>(() => _uut.Power(a, exp));

            StringAssert.Contains(expected, ex.Message);
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

        [Test]
        public void Accumulator_AddAccumulator2Plus2_Return4()
        {
            // Arrange
            double c = _uut.Add(2, 2);

            // Act / Assert
            Assert.That(_uut.Accumulator, Is.EqualTo(4));
        }

        [Test]
        public void Accumulator_SubtractAccumulator4Minus2_Return2()
        {
            // Act
            double c = _uut.Subtract(4, 2);

            // Assert
            Assert.That(_uut.Accumulator, Is.EqualTo(2));
        }

        [Test]
        public void Accumulator_MultiplyAccumulator2Times3_Return6()
        {
            // Act
            double c = _uut.Multiply(2, 3);

            // Assert
            Assert.That(_uut.Accumulator, Is.EqualTo(6));
        }

        [Test]
        public void Accumulator_PowerAccumulator2Raised3_Return12()
        {
            // Act
            double c = _uut.Power(2, 3);

            // Assert
            Assert.That(_uut.Accumulator, Is.EqualTo(8));
        }

        [Test]
        public void Accumulator_DivideAccumulator4Divided2_Return2()
        {
            // Act
            double c = _uut.Divide(4, 2);

            // Assert
            Assert.That(_uut.Accumulator, Is.EqualTo(2));
        }

        [Test]
        public void Accumulator_FreshAccumulator_Returns0()
        {
            // Assert
            Assert.That(_uut.Accumulator, Is.Null);
        }

        [Test]
        public void Clear_AccuIsNull()
        {
            _uut.Clear();
            Assert.That(_uut.Accumulator, Is.Null);
        }

        [TestCase(1, "You need to use a standard expression from Calculator, before using shorthand calculations")]
        public void Add_Add1PlusNull_ThrowsArgumentException(double a, string expected)
        {
            var ex = Assert.Catch<ArgumentException>(() => _uut.Add(a));

            StringAssert.Contains(expected, ex.Message);
        }

        [TestCase(1, 1, 2)]
        public void Add_Add1PlusNull_Returns2(double a, double accu, double expected)
        {
            //Act
            _uut.Add(accu, 0);

            Assert.That(_uut.Add(a), Is.EqualTo(2));
        }

        [TestCase(1, "You need to use a standard expression from Calculator, before using shorthand calculations")]
        public void Sub_Sub1MinusNull_ThrowsArgumentException(double a, string expected)
        {
            var ex = Assert.Catch<ArgumentException>(() => _uut.Subtract(a));

            StringAssert.Contains(expected, ex.Message);
        }

        [TestCase(1, 1, 0)]
        public void Sub_Sub1Minusl_Returns0(double a, double accu, double expected)
        {
            //Act
            _uut.Add(accu, 0);

            Assert.That(_uut.Subtract(a), Is.EqualTo(expected));
        }

        [TestCase(1, "You need to use a standard expression from Calculator, before using shorthand calculations")]
        public void Multiply_Multiply1TimesNull_ThrowsArgumentException(double a, string expected)
        {
            var ex = Assert.Catch<ArgumentException>(() => _uut.Multiply(a));

            StringAssert.Contains(expected, ex.Message);
        }

        [TestCase(3, 3, 9)]
        public void Multiply_Multiply3Times3_Returns9(double a, double accu, double expected)
        {
            //Act
            _uut.Multiply(accu, 1);

            Assert.That(_uut.Multiply(a), Is.EqualTo(expected));
        }

        [TestCase(1, "You need to use a standard expression from Calculator, before using shorthand calculations")]
        public void Divide_DivideNullby1_ThrowsArgumentException(double a, string expected)
        {
            var ex = Assert.Catch<ArgumentException>(() => _uut.Divide(a));

            StringAssert.Contains(expected, ex.Message);
        }

        [TestCase(3, 3, 1)]
        public void Divide_Divide3by3_Returns1(double a, double accu, double expected)
        {
            //Act
            _uut.Divide(accu, 1);

            Assert.That(_uut.Divide(a), Is.EqualTo(expected));
        }

        [TestCase(1, "You need to use a standard expression from Calculator, before using shorthand calculations")]
        public void Power_PowerNullRaisedBy1_ThrowsArgumentException(double a, string expected)
        {
            var ex = Assert.Catch<ArgumentException>(() => _uut.Power(a));

            StringAssert.Contains(expected, ex.Message);
        }

        [TestCase(3, 3, 27)]
        public void Power_Power3RaisedBy3_Returns27(double a, double accu, double expected)
        {
            //Act
            _uut.Power(accu, 1);

            Assert.That(_uut.Power(a), Is.EqualTo(expected));
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