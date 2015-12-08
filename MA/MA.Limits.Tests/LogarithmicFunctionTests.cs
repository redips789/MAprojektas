using System;
using System.Linq;
using FluentAssertions;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class LogarithmicFunctionTests
    {

        [TestMethod]
        public void ToTaylorExpansion_1()
        {
            var ln = new LogarithmicFunction { Aparam = 2, Bparam = 5 };

            var expansion = ln.ToTaylorExpansion(5).ToList();

            expansion.Should().HaveCount(7);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 0.0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 0, 0, 0, 5);


            expansion[0].Coefficient.Should().BeApproximately(Math.Log(5), 1e-10);
            expansion[1].Coefficient.Should().BeApproximately(0.4, 1e-10);
            expansion[2].Coefficient.Should().BeApproximately(-0.16 / 2, 1e-10);
            expansion[3].Coefficient.Should().BeApproximately(0.064 / 3, 1e-10);
            expansion[4].Coefficient.Should().BeApproximately(-0.0256 / 4, 1e-10);
            expansion[5].Coefficient.Should().BeApproximately(0.01024 / 5, 1e-10);            
            expansion[6].Coefficient.Should().BeApproximately(1.0, 1e-10);

        }
    }
}
