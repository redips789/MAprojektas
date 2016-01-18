using System;
using System.Collections.Generic;
using FluentAssertions;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class LimitCalculatorTests
    {

        [TestMethod]
        // (lim x->0) (sin(x) - x) / (sin(x) * x) = 0
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }


        [TestMethod]
        // (lim x->0) (((1 + x)^3) - ((1 + 3x)^1)) / (x + x^5) = 0
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }

        [TestMethod]
        // (lim x->0) (x^3 * sin(x)) * (x^3 + (x^2 * sin(x))^2 )^2 = 0
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }

        [TestMethod]
        // (lim x->0) (2 * x / x)  = 2
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(2.0);
        }

        [TestMethod]
        // (lim x->0) sin (x + 3) = sin(3) ~ 0.141120008059867
        public void CalculateLimit_AndReturnsCorrectLimit_5()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine()
                        {
                            Aparam = 1.0,
                            Bparam = 3
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            MathHelper.AreApproximatelyEqual(result.Value, 0.141, 0.005).Should().BeTrue();
        }


        [TestMethod]
        // (lim x->0) 1/x
        public void CalculateLimit_AndReturnsCorrectLimit_6()
        {
            var numerator = new List<Summand>
            {
                new Summand()
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    PolynomialDegree = 1
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.DoesNotExist);
        }

        [TestMethod]
        // (lim x->0) 1/-(x^2)
        public void CalculateLimit_AndReturnsCorrectLimit_7()
        {
            var numerator = new List<Summand>
            {
                new Summand()
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = -1,
                    PolynomialDegree = 2
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.NegativeInfinity);
        }

        [TestMethod]
        // (lim x->0) 1/sin(x)
        public void CalculateLimit_AndReturnsCorrectLimit_8()
        {
            var numerator = new List<Summand>
            {
                new Summand()
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine {Aparam = 1}
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.DoesNotExist);
        }

        [TestMethod]
        // (lim x->0) (x^(1/5)) / (x^(1/3)) = +INF
        public void CalculateLimit_AndReturnsCorrectLimit_9()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction() {Aparam = 1, PowerNumerator = 1, PowerDenominator = 5}
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction {Aparam = 1, PowerNumerator = 1, PowerDenominator = 3}
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.PositiveInfinity);
        }

        [TestMethod]
        // (lim x->0) (ln(3*x + 5) - ln(5) - 3/5/1*x + 9/25/2*(x^2)) / (x^3) = 27/125/3
        public void CalculateLimit_AndReturnsCorrectLimit_10()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new LogarithmicFunction {Aparam = 3, Bparam = 5}
                    }
                },
                new Summand
                {
                    Coefficient = -Math.Log(5)
                },
                new Summand
                {
                    Coefficient = -3.0/5,
                    PolynomialDegree = 1
                },
                new Summand
                {
                    Coefficient = 9.0/25/2,
                    PolynomialDegree = 2
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    PolynomialDegree = 3
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(27.0/125/3);
        }

        [TestMethod]
        // (lim x->0) (x*sin(x) - x*sin(x)) / 1 = 0
        public void CalculateLimit_AndReturnsCorrectLimit_11()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    PolynomialDegree = 1,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 1 }
                    }
                },
                new Summand
                {
                    Coefficient = -1,
                    PolynomialDegree = 1,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 1 }
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand()
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0);
        }


    }
}
