using System;
using System.Linq;
using FluentAssertions;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class CosineTests
    {

        [TestMethod]
        public void ToTaylorExpansion_1()
        {
            var cosine = new Cosine { Aparam = 2, Bparam = 5 };

            var expansion = cosine.ToTaylorExpansion(5).ToList();

            expansion.Should().HaveCount(7);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(0, 1, 2, 3, 4, 5, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 0, 0, 0, 5);
            expansion.Select(s => s.Coefficient)
                .Should()
                .ContainInOrder(
                    Math.Cos(5),
                    -2 * Math.Sin(5),
                    -2 * Math.Cos(5),
                    8.0 / 6 * Math.Sin(5),
                    16.0 / 24 * Math.Cos(5),
                    -32.0 / 120 * Math.Sin(5),
                    1.0
                );
        }
    }
}
