using System.Collections.Generic;
using FluentAssertions;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class LimitCalculatorTests
    {

        [TestMethod]
        // lim (sin(x) - x) / (sin(x) * x) = 0
        public void CalculateLimit_AndReturnsCorrectLimit_1()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine {Aparam = 1, Bparam = 0}
                    }
                },
                new Summand
                {
                    Coefficient = -1.0,
                    PolynomialDegree = 1
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 1,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine {Aparam = 1, Bparam = 0}
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }

    }
}
