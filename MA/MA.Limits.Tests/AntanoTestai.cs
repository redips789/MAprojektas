using System;
using System.Collections.Generic;
using FluentAssertions;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class AntanoTestai
    {
        [TestMethod]
        // (lim x->0) sin(4x) / x = 4
        public void Calculate_Antano_Limit_1()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine {Aparam = 4, Bparam = 0}
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
            result.Value.Should().Be(4.0);
        }

        [TestMethod]
        // (lim x->1) 3x-x^0.5 = 2
        public void Calculate_Antano_Limit_2()
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
                    Coefficient = 3.0,
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 1);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(2);
        }

        [TestMethod]
        // (lim x->-1)(x^2+6x+5) / (x^2-1) = -2
        public void Calculate_Antano_Limit_3()
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
                    PolynomialDegree = 2
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
            result.Value.Should().Be(-2.0);
        }

        [TestMethod]
        // (lim x->0)(x) / ((4-x)^1/2)-2 = -4
        public void Calculate_Antano_Limit_4()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    PolynomialDegree = 1,
                    Coefficient = 1.0
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new PowerFunction { Aparam = -1, Bparam = 4, PowerNumerator = 1, PowerDenominator = 2}
                    }
                },
                new Summand
                {
                    Coefficient = -2.0
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(-4.0);
        }

        [TestMethod]
        // (lim x->0) sin(7PI) / sin(2PI) = -3.5
        public void Calculate_Antano_Limit_5_sin_pi()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine {Aparam = 7*Math.PI, Bparam = 0}
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
                        new Sine {Aparam = 2*Math.PI, Bparam = 0}
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

        [TestMethod]
        // (lim x->0) cos(3x) - cos(7x) / x^2 = 20
        public void Calculate_Antano_Limit_6_cos()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine {Aparam = 3, Bparam = 0}
                    }
                },
                new Summand
                {
                    Coefficient = -1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine {Aparam = 7, Bparam = 0}
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(20.0);
        }

        [TestMethod]
        // (lim x->10) sin(x) - sin(10) / x-10 = cos(10)
        public void Calculate_Antano_Limit_7_sin()
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
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine {Aparam = 0, Bparam = 10}
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
                    Coefficient = -10.0

                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 10);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(Math.Cos(10));
        }

        [TestMethod]
        // (lim x->11) ln(x) - ln(11) / x-11 = 1/11
        public void Calculate_Antano_Limit_8_ln()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new LogarithmicFunction {Aparam = 1, Bparam = 0}
                    }
                },
                new Summand
                {
                    Coefficient = -1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new LogarithmicFunction {Aparam = 0, Bparam = 11}
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
                    Coefficient = -11.0

                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 11);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(1.0/11.0);
        }

        [TestMethod]
        // (lim x->0) x / 2^x = 0
        public void Calculate_Antano_Limit_9_EX()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 1

                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new ExponentialFunction {Aparam = 2, Bparam = 0},
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
            result.Value.Should().Be(0);
        }

        [TestMethod]
        // (lim x->0) cos(x) - 1 / x^2 = -1/2
        public void Calculate_Antano_Limit_10_cos()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine {Aparam = 1, Bparam = 0}
                    }
                },
                new Summand
                {
                    Coefficient = -1.0,
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

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(-0.5);
        }

        [TestMethod]
        // (lim x->0) sinx-x / x*sinx = 0
        public void Calculate_Antano_Limit_11_sin()
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
            result.Value.Should().Be(0);
        }

        [TestMethod]
        // (lim x->PI/2) 1-sinx / cosx^2 = 1/2
        public void Calculate_Antano_Limit_12_sin()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = -1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine {Aparam = 1, Bparam = 0}
                    }
                },
                new Summand
                {
                    Coefficient = 1.0,
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine {Aparam = 1, Bparam = 0},
                        new Cosine {Aparam = 1, Bparam = 0}
                    }

                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, Math.PI/2);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.5);
        }

    }
}
