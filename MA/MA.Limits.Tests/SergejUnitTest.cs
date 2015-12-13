using System;
using System.Collections.Generic;
using FluentAssertions;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MA.Limits.Tests
{
    /// <summary>
    /// Summary description for SergejUnitTest
    /// </summary>
    [TestClass]
    public class SergejUnitTest
    {
        public SergejUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        //x->0 (1+x*sinx-cos2x)/sin^2(x)
        public void Kuznecov_15_2()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient=1.0
                },

                new Summand
                {
                  Coefficient=1.0,
                  Multiplicands = new List<IElementaryFunction>
                  {
                      new Sine { Aparam = 1.0, Bparam=0}
                  },
                  PolynomialDegree = 1
                },

                new Summand
                {
                    Coefficient = -1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Cosine { Aparam = 2.0, Bparam = 0}
                    }
                }
            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1,
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
                                    Multiplicands = new List<IElementaryFunction>
                                    {
                                        new Sine {Aparam = 1.0, Bparam = 0}
                                    }
                                }
                            }

                        }

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
            result.Value.Should().Be(3.0);
        }
        [TestMethod]
        // x->-1 (x^3+1)/sin(x+1)
        public void Kuznecov_15_3()
        {
            var numerator = new List<Summand>
            {
                new Summand
                {
                    Coefficient = 1.0,
                    PolynomialDegree = 3
                },
                new Summand
                {
                    Coefficient = 1.0,

                },

            };

            var denominator = new List<Summand>
            {
                new Summand
                {
                    Coefficient=1.0,
                    Multiplicands = new List<IElementaryFunction>
                    {
                        new Sine { Aparam = 1.0, Bparam = 1.0}
                    }
                }
            };

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = numerator,
                Denominator = denominator
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, -1);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(3.0);
        }


        [TestMethod]
        public void CalculateLimit_MKD_67_1_StringParse()
        {
            string numeratorString = "((5*x^2)-4*x-1)";
            string denominatorString = "(x-1)";

       //     var a = StringToSummand.FindPolynomialDegree("(5*x^2)");

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = StringToSummand.Parse(numeratorString),
                Denominator = StringToSummand.Parse(denominatorString)
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 1);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(6.0);
        }

        [TestMethod]
        public void CalculateLimit_MKD_69_33_StringParse()
        {
            string numeratorString = "(cos(x)*(e^(7x)-e^(2x)))";
            string denominatorString = "sin(x)";

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = StringToSummand.Parse(numeratorString),
                Denominator = StringToSummand.Parse(denominatorString)
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(5);
        }

        [TestMethod]
        public void CalculateLimit_MKD_69_30_StringParse()
        {
            string numeratorString = "sin(x)";
            string denominatorString = "ln(1+2*x)";
            var normalizedFunction = new NormalizedFunction
            {
                Numerator = StringToSummand.Parse(numeratorString),
                Denominator = StringToSummand.Parse(denominatorString),
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0.0);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0.5);
        }

        [TestMethod]
        public void CalculateLimit_AndReturnsCorrectLimit_9_StringParse()
        {
            string numeratorString = "x^(1/5)";
            string denominatorString = "x^(1/3)";

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = StringToSummand.Parse(numeratorString),
                Denominator = StringToSummand.Parse(denominatorString),
            };


            var result = LimitCalculator.CalculateLimit(normalizedFunction, 0);

            result.LimitResultType.Should().Be(LimitResultType.PositiveInfinity);
        }

        [TestMethod]
        public void CalculateLimit_MKD_67_16_StringParse()
        {
            string numeratorString = "1-cos(Pi*x+2)";
            string denominatorString = "1";

            var normalizedFunction = new NormalizedFunction
            {
                Numerator = StringToSummand.Parse(numeratorString),
                Denominator = StringToSummand.Parse(denominatorString),
            };

            var result = LimitCalculator.CalculateLimit(normalizedFunction, -2 / Math.PI);

            result.LimitResultType.Should().Be(LimitResultType.RealNumber);
            result.Value.Should().Be(0);
        }
    }
}
