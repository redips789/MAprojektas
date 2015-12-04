using System;
using System.Collections.Generic;
using FluentAssertions;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    
    /// <summary>
    /// Tests adapted from:
    /// E. Misevicius, D. Kamuntavicius, S. Norvidas
    /// Matematines analizes pratybu uzduotys
    /// 
    /// Naming conventions:
    /// CalculateLimit_MKD_[page number]_[problem number]
    /// </summary>
    [TestClass]
    public class LimitCalculatorMKDTests
    {

        [TestMethod]
        // (lim x->1) (5*x^2 - 4*x - 1) / (x - 1) = 6
        public void CalculateLimit_MKD_67_1()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 5.0,
                    PolynomialDegree = 2
                },
                new Summand
                {
                    Coefficient = -4.0,
                    PolynomialDegree = 1
                },
                new Summand
                {
                    Coefficient = -1.0
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 1
                },
                new Summand
                {
                    Coefficient = -1.0,
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 1);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(6.0);
        }

        [TestMethod]
        // (lim x->2) 1 / x  = 0.5
        public void CalculateLimit_MKD_67_2()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 1
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 2);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.5);
        }

        [TestMethod]
        // (lim x->4) x^0.5 = 2
        public void CalculateLimit_MKD_67_3()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction { Aparam = 1, Bparam = 0, Power = 0.5}
                    }
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 4, 3);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(Math.Sqrt(2));
        }


        [TestMethod]
        // (lim x->1) sin(x - 1) = 0
        public void CalculateLimit_MKD_67_4()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 1.0, Bparam = -1.0}
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 1);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }

    }
}
