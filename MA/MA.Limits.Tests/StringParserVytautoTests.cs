using FluentAssertions;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.Limits.Tests
{
    [TestClass]
    public class StringParserVytautoTests
    {

        [TestMethod]
        public void Parse_1()
        {
            string str = "cos(x)*(e^(3+7x)-2e^(2x))";

            var result = StringToSummand.Parse(str);

            result.Should().HaveCount(1);
            result[0].PolynomialDegree.Should().Be(0);
            result[0].Coefficient.Should().Be(1.0);
            result[0].Multiplicands.Should().HaveCount(1);
            result[0].Multiplicands[0].Should()
                .Match<Cosine>(
                    x =>
                        MathHelper.AreApproximatelyEqual(x.Aparam, 1.0) &&
                        MathHelper.AreApproximatelyEqual(x.Bparam, 0.0));
            
            result[0].SumsRaisedToPower.Should().HaveCount(1);
            result[0].SumsRaisedToPower[0].Degree.Should().Be(1);
            var sum = result[0].SumsRaisedToPower[0].Sum;
            sum.Should().HaveCount(2);

            sum[0].PolynomialDegree.Should().Be(0);
            sum[0].Coefficient.Should().Be(1.0);
            sum[0].Multiplicands.Should().HaveCount(1);
            sum[0].Multiplicands[0].Should()
                .Match<ExponentialFunction>(
                    x =>
                        MathHelper.AreApproximatelyEqual(x.Aparam, 7.0) &&
                        MathHelper.AreApproximatelyEqual(x.Bparam, 3.0));


            sum[1].PolynomialDegree.Should().Be(0);
            sum[1].Coefficient.Should().Be(-2);
            sum[1].Multiplicands.Should().HaveCount(1);
            sum[1].Multiplicands[0].Should()
                .Match<ExponentialFunction>(
                    x =>
                        MathHelper.AreApproximatelyEqual(x.Aparam, 2.0) &&
                        MathHelper.AreApproximatelyEqual(x.Bparam, 0.0));

        }

    }
}
