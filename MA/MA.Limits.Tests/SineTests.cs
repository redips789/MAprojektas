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

            expansion.Count.Should().Be(4);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(1, 3, 5, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 5);
            expansion.Select(s => s.Coefficient).Should().ContainInOrder(1.0, -1.0 / 6, 1.0 / 120, 1.0);
        }

        [TestMethod]
        public void ToTaylorExpansion_2()
        {
            var sine = new Sine { Aparam = 2, Bparam = 0 };

            var expansion = sine.ToTaylorExpansion(5).ToList();

            expansion.Count.Should().Be(4);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(1, 3, 5, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 5);
            expansion.Select(s => s.Coefficient).Should().ContainInOrder(2.0, -8.0 / 6, 32.0 / 120, 1.0);
        }

        [TestMethod]
        public void ToTaylorExpansion_3()
        {
            var sine = new Sine { Aparam = 2, Bparam = 5 };

            var expansion = sine.ToTaylorExpansion(5).ToList();

            // sin(2*x + 5) = 5 + 2*x - (125 + 150*x + 60*x^2 + 8*x^3)/6 + (3125 + 6250*x + 5000*x^2 + 2000*x^3 + 400*x^4 + 32*x^5)/120 + o(x^5)
            expansion.Count.Should().Be(13);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(0, 1, 0, 1, 2, 3, 0, 1, 2, 3, 4, 5, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5);
            expansion.Select(s => s.Coefficient)
                .Should()
                .ContainInOrder(
                    5.0, 2.0, 
                    -125.0/6, -150.0/6, -60.0/6, -8.0/6,
                    3125.0 / 120, 6250.0 / 120, 5000.0 / 120, 2000.0 / 120, 400.0 / 120, 32.0 / 120, 
                    1.0);
        }
    }
}
