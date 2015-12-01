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


        [TestMethod]
        // lim (((1 + x)^3) - ((1 + 3x)^1)) / (x + x^5) = 0
        public void CalculateLimit_AndReturnsCorrectLimit_2()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    SumsRaisedToPower = new List<SumRaisedToPower>
                    {
                        new SumRaisedToPower
                        {
                            Degree = 3,
                            Sum = new List<Summand>
                            {
                                new Summand { Coefficient = 1.0 },
                                new Summand { Coefficient = 1.0, PolynomialDegree = 1 }
                            }
                        }
                    }

                },
                new Summand
                {
                    Coefficient = -1.0,
                    SumsRaisedToPower = new List<SumRaisedToPower>
                    {
                        new SumRaisedToPower
                        {
                            Degree = 1,
                            Sum = new List<Summand>
                            {
                                new Summand { Coefficient = 1.0 },
                                new Summand { Coefficient = 3.0, PolynomialDegree = 1 }
                            }
                        }
                    }
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
                    Coefficient = 1.0,
                    PolynomialDegree = 5
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

        [TestMethod]
        // lim (x^3 * sin(x)) * (x^3 + (x^2 * sin(x))^2 )^2 = 0
        public void CalculateLimit_AndReturnsCorrectLimit_3()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 3,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 1 }
                    },
                    SumsRaisedToPower = new List<SumRaisedToPower>
                    {
                        new SumRaisedToPower
                        {
                            Degree = 2,
                            Sum = new List<Summand>
                            {
                                new Summand
                                {
                                    Coefficient = 1.0,
                                    PolynomialDegree = 3
                                },
                                new Summand
                                {
                                    Coefficient = 3.0,
                                    SumsRaisedToPower = new List<SumRaisedToPower>
                                    {
                                        new SumRaisedToPower
                                        {
                                            Degree = 2,
                                            Sum = new List<Summand>
                                            {
                                                new Summand
                                                {
                                                    Coefficient = 1,
                                                    PolynomialDegree = 1
                                                },
                                                new Summand
                                                {
                                                    Coefficient = 1,
                                                    Multiplicands = new List<IElementaryFunction>
                                                    {
                                                        new Sine { Aparam = 1 }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }

        [TestMethod]
        // lim (2 * x / x)  = 2
        public void CalculateLimit_AndReturnsCorrectLimit_4()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 2.0,
                    PolynomialDegree = 1
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(2.0);
        }

    }
}
