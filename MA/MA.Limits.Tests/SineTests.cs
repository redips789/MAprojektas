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
        public void ToTaylorExpansion()
        {
            var sine = new Sine { Aparam = 1, Bparam = 0 };

            var expansion = sine.ToTaylorExpansion(5).ToList();

            expansion.Count.Should().Be(4);
            expansion.Select(s => s.PolynomialDegree).Should().ContainInOrder(1, 3, 5, 0);
            expansion.Select(s => s.LittleODegree).Should().ContainInOrder(0, 0, 0, 5);
            expansion.Select(s => s.Coefficient).Should().ContainInOrder(1.0, -1.0/6, 1.0/120, 1.0);
        }
    }
}
