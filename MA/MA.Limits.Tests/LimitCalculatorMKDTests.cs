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
                        new PowerFunction { Aparam = 1, Bparam = 0, PowerNumerator = 1, PowerDenominator = 2}
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
            result.Value.Should().Be(2);
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

        [TestMethod]
        // (lim x->-1/3) (9*x^2 - 1) / (x + 1/3) = -6
        public void CalculateLimit_MKD_67_6()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 9,
                    PolynomialDegree = 2
                },
                new Summand
                {
                    Coefficient = -1
                },
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1,
                    PolynomialDegree = 1
                },
                new Summand
                {
                    Coefficient = 1.0/3
                },
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, -1.0/3);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(-6.0);
        }

        [TestMethod]
        // (lim x->-2/Pi) 1 - cos(Pi*x + 2) = 0
        public void CalculateLimit_MKD_67_16()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1
                },
                new Summand
                {
                    Coefficient = -1,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine { Aparam = Math.PI, Bparam = 2}
                    }
                },
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, -2 / Math.PI);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0);
        }


        [TestMethod]
        // (lim x->-Pi) cos(0.5*x) = 0
        public void CalculateLimit_MKD_68_25()
        {
            var numerator = new List<Summand>
            {

                new Summand
                {
                    Coefficient = 1,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine { Aparam = 0.5 }
                    }
                },
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, -Math.PI);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0);
        }

        //--------------------------------------------------------------------------------------------------------
        //NEW TASK
        //--------------------------------------------------------------------------------------------------------

        [TestMethod]
        // (lim x->-2) ((x - 6)^(1/3) + 2) / (x + 2) = 1/12
        public void CalculateLimit_MKD_68_8()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction { Aparam = 1.0, Bparam = -6, PowerNumerator = 1, PowerDenominator = 3 }
                    }
                },
                new Summand
                {
                    Coefficient = 2.0
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
                    Coefficient = 2.0,
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, -2.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(1.0/12.0);
        }


        [TestMethod]
        // (lim x->1) ((x - 1)^(1/2)) / ((x - 1)^(1/3) * (x + 1)^(1/3)) NOT EXISTS
        public void CalculateLimit_MKD_68_10()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction { Aparam = 1.0, Bparam = -1.0, PowerNumerator = 1, PowerDenominator = 2 }
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction {Aparam = 1.0, Bparam = -1.0, PowerNumerator = 1, PowerDenominator = 3},
                        new PowerFunction {Aparam = 1.0, Bparam = 1.0, PowerNumerator = 1, PowerDenominator = 3}
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 1.0);

            result.LimitResultType.Should().Be(LimitResultType.DoesNotExist);
        }


        [TestMethod]
        // (lim x->0) 
        public void CalculateLimit_MKD_68_14()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction { Aparam = 1.0, Bparam = 1.0, PowerNumerator = 1, PowerDenominator = 2 }
                    },
                    SumsRaisedToPower = new List<SumRaisedToPower>
                    {
                        new SumRaisedToPower
                        {
                            Degree = 1,
                            Sum = new List<Summand>
                            {
                                new Summand
                                {
                                    Coefficient = 1.0,
                                    Multiplicands = new List<IElementaryFunction>
                                    {
                                        new PowerFunction { Aparam = 1.0, Bparam = 1.0, PowerNumerator = 1, PowerDenominator = 2 },
                                    } 
                                },
                                new Summand
                                {
                                    Coefficient = -1.0,
                                    Multiplicands = new List<IElementaryFunction>
                                    {
                                        new PowerFunction { Aparam = -1.0, Bparam = 1.0, PowerNumerator = 1, PowerDenominator = 2 },
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
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction {Aparam = 1.0, Bparam = 0, PowerNumerator = 1, PowerDenominator = 5},
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.0);
        }

        [TestMethod]
        // (lim x->0) sin(4*x) / x
        public void CalculateLimit_MKD_69_26()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 4 }
                    }
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(4);
        }

        [TestMethod]
        // (lim x->0) (cos(3*x) - cos(7*x)) / x^2 = 20
        public void CalculateLimit_MKD_69_27()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine { Aparam = 3 }
                    }
                },
                new Summand
                {
                    Coefficient = -1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine { Aparam = 7 }
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 2
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(20);
        }


        [TestMethod]
        // (lim x->0) sin(x)/ln(1 + 2x) = 1/2
        public void CalculateLimit_MKD_69_30()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 1 }
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new LogarithmicFunction { Aparam = 2, Bparam = 1}
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.5);
        }

        [TestMethod]
        // tg(x) replaced with sin(x) / cos(x)
        // (lim x->0) (cos(x) * (e^(7x) - e^(2x))) / sin(x) = 5
        public void CalculateLimit_MKD_69_33()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine { Aparam = 1 }
                    },
                    SumsRaisedToPower = new List<SumRaisedToPower>
                    {
                        new SumRaisedToPower
                        {
                            Degree = 1,
                            Sum = new List<Summand>
                            {
                                new Summand
                                {
                                    Coefficient = 1,
                                    Multiplicands = new List<IElementaryFunction>
                                    {
                                        new ExponentialFunction { Aparam = 7 }
                                    }
                                },
                                new Summand
                                {
                                    Coefficient = -1,
                                    Multiplicands = new List<IElementaryFunction>
                                    {
                                        new ExponentialFunction { Aparam = 2 }
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
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 1 }
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(5);
        }

        [TestMethod]
        // (lim x->1) sin(7Pi*x)/sin(2Pi*x) = -7/2
        public void CalculateLimit_MKD_69_34()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 7 * Math.PI }
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 2 * Math.PI }
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 1);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(-3.5);
        }

    }
}
