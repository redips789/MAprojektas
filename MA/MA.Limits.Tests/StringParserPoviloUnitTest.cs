using System;
using System.Collections.Generic;
using System.Linq;
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
    public class StringParserPoviloUnitTest
    {
        [TestMethod]
        public void StringParse1()
        {
            string numeratorStr = "sin(5*x)";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr);
            numerator.Count.Should().Be(1);
            numerator.ToArray().First().Coefficient.Should().Be(1);
            numerator.ToArray().First().PolynomialDegree.Should().Be(0);
            numerator.ToArray().First().Multiplicands.ToArray().Length.Should().Be(1);
            numerator.ToArray().First().Multiplicands.ToArray().First().Aparam.Should().Be(5);
        }

        [TestMethod]
        public void StringParse2()
        {
            string numeratorStr = "5*x-x^(1/2)";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr);
            numerator.Count.Should().Be(2);
            numerator[0].Coefficient.Should().Be(5);
            numerator[0].PolynomialDegree.Should().Be(1);
            numerator[1].Coefficient.Should().Be(-1);
            numerator[1].Multiplicands.Count.Should().Be(1);
            numerator[1].Multiplicands[0].Aparam.Should().Be(1);
            numerator[1].Multiplicands[0].Bparam.Should().Be(0);
            numerator[1].Multiplicands[0].Should()
                .Match<PowerFunction>(x => x.PowerDenominator == 2 && x.PowerNumerator == 1);
        }

        [TestMethod]
        public void StringParse3()
        {
            string numeratorStr = "x^2+6*x+5";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr);
            numerator.Count.Should().Be(3);
            numerator[0].Coefficient.Should().Be(1);
            numerator[0].PolynomialDegree.Should().Be(2);
            numerator[1].Coefficient.Should().Be(6); //Ant sito failina
            numerator[1].PolynomialDegree.Should().Be(1);
            numerator[2].Coefficient.Should().Be(1);
            numerator[2].PolynomialDegree.Should().Be(0);
        }

        [TestMethod]
        public void StringParse4()
        {
            string numeratorStr = "x^3-1";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr);
            numerator[0].Coefficient.Should().Be(1);
            numerator[0].PolynomialDegree.Should().Be(3);
            numerator[1].Coefficient.Should().Be(-1);
            numerator[1].PolynomialDegree.Should().Be(0);
        }

        public void StringParse5()
        {
            string numeratorStr = "x^3-1";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr);
            numerator[0].Coefficient.Should().Be(1);
            numerator[0].PolynomialDegree.Should().Be(3);
            numerator[1].Coefficient.Should().Be(-1);
            numerator[1].PolynomialDegree.Should().Be(0);
        }
        
        [TestMethod]
        public void StringParse6()
        {
            string numeratorStr = "sin(x-1)";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr);
            numerator[0].Coefficient.Should().Be(1);
            numerator[0].Multiplicands.Count.Should().Be(1);
            numerator[0].Multiplicands[0].Aparam.Should().Be(1);
            numerator[0].Multiplicands[0].Bparam.Should().Be(-1);
        }

        [TestMethod]
        public void StringParse7()
        {
            string numeratorStr = "5*x^2-4*x-1";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr); //meta exception
            numerator[0].Coefficient.Should().Be(5);
            numerator[0].PolynomialDegree.Should().Be(2);
            numerator[1].Coefficient.Should().Be(-4);
            numerator[1].PolynomialDegree.Should().Be(1);
            numerator[2].Coefficient.Should().Be(-1);
        }
        [TestMethod]
        public void StringParse8()
        {
            string numeratorStr = "x^(1/2)";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr); //meta exception
            numerator[0].Coefficient.Should().Be(1);
            numerator[0].Multiplicands[0].Should().Match<PowerFunction>(x => x.PowerDenominator==2 && x.PowerNumerator == 1);
        }

        [TestMethod]
        public void StringParse9() //exception
        {
            string numeratorStr = "9*x^2 - 1";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr); //meta exception
            numerator[0].Coefficient.Should().Be(9);
            numerator[0].PolynomialDegree.Should().Be(2);
            numerator[1].Coefficient.Should().Be(-1);
        }

        [TestMethod]
        public void StringParse10() //exception
        {
            string numeratorStr = "(x-6)^(1/3)+2";
            List<Summand> numerator = StringToSummand.Parse(numeratorStr); //meta exception
            numerator[0].Coefficient.Should().Be(9);
            numerator[0].PolynomialDegree.Should().Be(2);
            numerator[1].Coefficient.Should().Be(-1);
        }
    }
}
