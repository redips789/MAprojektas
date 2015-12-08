using System;
using System.Linq;
using FluentAssertions;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class ExponentialFunctionTests
    {

        [TestMethod]
        public void ToTaylorExpansion_1()
        {
            var exp = new ExponentialFunction { Aparam = 0.5, Bparam = 3.0 };

            var expansion = exp.ToTaylorExpansion(5).ToList();

            expansion.Should().HaveCount(7);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 0.0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 0, 0, 0, 5);

            expansion[0].Coefficient.Should().BeApproximately(Math.Exp(3.0), 1e-10);
            expansion[1].Coefficient.Should().BeApproximately(0.5 * Math.Exp(3.0), 1e-10);
            expansion[2].Coefficient.Should().BeApproximately(0.25 / 2.0 * Math.Exp(3.0), 1e-10);
            expansion[3].Coefficient.Should().BeApproximately(0.125 / 6.0 * Math.Exp(3.0), 1e-10);
            expansion[4].Coefficient.Should().BeApproximately(0.0625 / 24.0 * Math.Exp(3.0), 1e-10);
            expansion[5].Coefficient.Should().BeApproximately(0.03125 / 120.0 * Math.Exp(3.0), 1e-10);
            expansion[6].Coefficient.Should().BeApproximately(1.0, 1e-10);

        }
    }
}
