using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace Calculator.UT
{
    [TestFixture]
    public class CalculatorUnitTests
    {
        [Test]
        public void Add_Add1And2_Returns3()
        {
            var uut = new Calculator();

            Assert.That(uut.Add(1,2), Is.EqualTo(3));
        }

        [Test]
        public void Add_Add0And2_Returns2()
        {
            var uut = new Calculator();

            Assert.That(uut.Add(0,2),Is.EqualTo(2));
        }

        [TestCase(1, 3, -2)]
        [TestCase(-1, -3, 2)]
        [TestCase(3, 3, 0)]
        [TestCase(8,4,4)]
        public void Subtract_SimpleCalculations(double a, double b, double expected)
        {
            var uut = new Calculator();

            Assert.That(uut.Subtract(a, b), Is.EqualTo(expected));
        }
    }
}
