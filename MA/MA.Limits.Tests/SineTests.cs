using System;
using System.ComponentModel;
using System.Linq;
using FluentAssertions;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class SineTests
    {
        [TestMethod]
        public void ToTaylorExpansion_1()
        {
            var sine = new Sine { Aparam = 1, Bparam = 0 };

            var expansion = sine.ToTaylorExpansion(5).ToList();

            expansion.Should().HaveCount(4);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(1, 3, 5, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 5);
            expansion.Select(s => s.Coefficient).Should().ContainInOrder(1.0, -1.0 / 6, 1.0 / 120, 1.0);
        }

        [TestMethod]
        public void ToTaylorExpansion_2()
        {
            var sine = new Sine { Aparam = 2, Bparam = 0 };

            var expansion = sine.ToTaylorExpansion(5).ToList();

            expansion.Should().HaveCount(4);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(1, 3, 5, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 5);
            expansion.Select(s => s.Coefficient).Should().ContainInOrder(2.0, -8.0 / 6, 32.0 / 120, 1.0);
        }

        [TestMethod]
        public void ToTaylorExpansion_3()
        {
            var sine = new Sine { Aparam = 2, Bparam = 5 };

            var expansion = sine.ToTaylorExpansion(5).ToList();

            expansion.Should().HaveCount(7);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(0, 1, 2, 3, 4, 5, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 0, 0, 0, 5);
            expansion.Select(s => s.Coefficient)
                .Should()
                .ContainInOrder(
                    Math.Sin(5),
                    2 * Math.Cos(5),
                    -2 * Math.Sin(5),
                    -8.0 / 6 * Math.Cos(5),
                    16.0 / 24 * Math.Sin(5),
                    32.0 / 120 * Math.Cos(5),
                    1.0
                );
        }
    }
}
