using System;
using System.Collections.Generic;
using FluentAssertions;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    /// <summary>
    /// Summary description for PoviloUnitTest
    /// </summary>
    [TestClass]
    public class PoviloUnitTest
    {
        [TestMethod]
        // (lim x->0) sin(5x) / x = 5
        public void CalculatePoviloLimit1()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine {Aparam = 5, Bparam = 0}
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 1,
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(5.0);
        }

        [TestMethod]
        // (lim x->1) 5x-x^0.5 = 4
        public void CalculatePoviloLimit2()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = -1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction { Aparam = 1, Bparam = 0, PowerNumerator = 1, PowerDenominator = 2}
                    }
                },
                new Summand
                {
                    Coefficient = 5.0,
                    PolynomialDegree = 1,
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 1, 10);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(4);
        }

        [TestMethod]
        // (lim x->-1)(x^2+6x+5) / (x^3-1) = 0
        public void CalculatePoviloLimit3()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 2
                },
                new Summand
                {
                    Coefficient = 6.0,
                    PolynomialDegree = 1
                },
                new Summand
                {
                    Coefficient = 5.0
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 3
                },
                new Summand
                {
                    Coefficient = -1.0
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, -1.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }

        [TestMethod]
        // (lim x->1) sin(x-1) = 0
        public void CalculatePoviloLimit4()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                       new Sine {Aparam = 1, Bparam = -1 }
                    }
                }

            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Denominator = denominator,
                Numerator = numerator,
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 1);
            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }

        [TestMethod]
        // (lim x->-infinity) (x^2+x) = +infinity
        public void CalculatePoviloLimit5()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1,
                    PolynomialDegree = 2,
                },

                new Summand
                {
                    Coefficient = 1,
                    PolynomialDegree = 1,
                }
            };
            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Denominator = denominator,
                Numerator = numerator,
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 10);
            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(110.0);
        }

    }
}
