using System;
using System.Linq;
using FluentAssertions;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class PowerFunctionTests
    {
        [TestMethod]
        public void ToTaylorExpansion_1()
        {
            var power = new PowerFunction {Aparam = 2, Bparam = 3, PowerNumerator = 3, PowerDenominator = 1};
            var expansion = power.ToTaylorExpansion(7).ToList();

            expansion.Should().HaveCount(4);

            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(0, 1, 2, 3);
            expansion.Select(s => s.LittleODegree).Should().OnlyContain(x => x == 0);
            expansion.Select(s => s.Coefficient).Should().ContainInOrder(27.0, 54.0, 36.0, 8.0);
        }

        [TestMethod]
        public void ToTaylorExpansion_2()
        {
            var power = new PowerFunction { Aparam = 2, Bparam = 3, PowerNumerator = 1, PowerDenominator = 2 };
            var expansion = power.ToTaylorExpansion(2).ToList();

            expansion.Should().HaveCount(4);

            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(0, 1, 2, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 2);
            expansion.Select(s => s.Coefficient).Should().ContainInOrder(Math.Pow(3, 0.5), Math.Pow(3, 0.5) * 1.0 / 3.0, Math.Pow(3, 0.5) * -1.0 / 18.0, 1.0);
        }
    }
}
