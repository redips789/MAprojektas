using MA.Limits.LimitsDomain;
using System.Collections.Generic;
using System.Linq;
using MA.Limits.Helpers;

namespace MA.Limits
{
    public static class LimitCalculator
    {

        public static LimitResult CalculateLimit(NormalizedFunction normalizedFunction, double argument)
        {
            var raisedNumerator = normalizedFunction.Numerator.SelectMany(RaiseSumsToPower);
            var raisedDenominator = normalizedFunction.Denominator.SelectMany(RaiseSumsToPower);

            if (!MathHelper.IsZero(argument))
            {
                raisedNumerator = TransformArgumentToZero(raisedNumerator, argument);
                raisedDenominator = TransformArgumentToZero(raisedDenominator, argument);
            }

            var expandedNumerator = PerformTaylorExpansion(raisedNumerator);
            var expandedDenominator = PerformTaylorExpansion(raisedDenominator);

            var numeratorMinPolynomialWithoutO = expandedNumerator.FirstOrDefault(s => s.LittleODegree == 0);
            var denominatorMinPolynomialWithoutO = expandedDenominator.FirstOrDefault(s => s.LittleODegree == 0);

            if (denominatorMinPolynomialWithoutO == null)
            {
                return new LimitResult
                {
                    LimitResultType = LimitResultType.DoesNotExist,
                }; 
            }

            if (numeratorMinPolynomialWithoutO == null)
            {
                return new LimitResult
                {
                    LimitResultType = LimitResultType.RealNumber,
                    Value = 0
                };
            }

            var degreeNumerator = numeratorMinPolynomialWithoutO.PolynomialDegree *
                      denominatorMinPolynomialWithoutO.PolynomialDegreeDenominator
                      -
                      denominatorMinPolynomialWithoutO.PolynomialDegree *
                      numeratorMinPolynomialWithoutO.PolynomialDegreeDenominator;
            var degreeDenominator = denominatorMinPolynomialWithoutO.PolynomialDegreeDenominator *
                                    numeratorMinPolynomialWithoutO.PolynomialDegreeDenominator;


            if (degreeNumerator == 0)
            {
                return new LimitResult
                {
                    LimitResultType = LimitResultType.RealNumber,
                    Value = numeratorMinPolynomialWithoutO.Coefficient / denominatorMinPolynomialWithoutO.Coefficient
                };
            }

            var gcd = MathHelper.GreatestCommonDivisor(degreeNumerator >= 0 ? degreeNumerator : -degreeNumerator,
                degreeDenominator);

            degreeNumerator /= gcd;
            degreeDenominator /= gcd;


            if (degreeNumerator > 0 && (degreeDenominator == 1 || degreeNumerator % 2 == 0))
            {
                return new LimitResult
                {
                    LimitResultType = LimitResultType.RealNumber,
                    Value = 0
                };
            }

            if (degreeNumerator > 0 && degreeNumerator % 2 == 1)
            {
                return new LimitResult
                {
                    LimitResultType = LimitResultType.DoesNotExist,
                };
            }

            degreeNumerator = -degreeNumerator;

            if (degreeNumerator % 2 == 1)
            {
                return new LimitResult { LimitResultType = LimitResultType.DoesNotExist };
            }

            if (numeratorMinPolynomialWithoutO.Coefficient * denominatorMinPolynomialWithoutO.Coefficient > 0)
            {
                return new LimitResult { LimitResultType = LimitResultType.PositiveInfinity };
            }

            return new LimitResult { LimitResultType = LimitResultType.NegativeInfinity };

        }

        private static IEnumerable<Summand> TransformArgumentToZero(IEnumerable<Summand> summands, double argument)
        {
            var summandsList = summands.ToList();

            var functions = summandsList.SelectMany(s => s.Multiplicands);
            foreach (var foo in functions)
            {
                foo.Bparam += foo.Aparam * argument;
            }

            var returned =
                summandsList.SelectMany(
                    s =>
                        DomainHelper.RaiseLineToPowerWithBinomialExpansion(1, argument, s.PolynomialDegree)
                            .Select(x => new Summand
                            {
                                PolynomialDegree = x.PolynomialDegree,
                                Coefficient = s.Coefficient * x.Coefficient,
                                Multiplicands = s.Multiplicands
                            }));

            return returned;
        }

        private static IEnumerable<Summand> RaiseSumsToPower(Summand summand)
        {
            var returned = new List<Summand> { summand };

            summand.SumsRaisedToPower.ForEach(
                sum => returned = DistributeIncludingElementaryFunctions(returned, RaiseSumToPower(sum)).ToList());

            return returned;
        }

        public static IEnumerable<Summand> RaiseSumToPower(SumRaisedToPower sumRaisedToPower)
        {
            var raisedInnerSums = sumRaisedToPower.Sum.SelectMany(RaiseSumsToPower);

            var returned = raisedInnerSums;

            for (int i = 2; i <= sumRaisedToPower.Degree; i++)
            {
                returned = DistributeIncludingElementaryFunctions(returned, raisedInnerSums);
            }

            return returned;

        }

        private static IEnumerable<Summand> DistributeIncludingElementaryFunctions(IEnumerable<Summand> factor1, IEnumerable<Summand> factor2)
        {
            var distribution =
                factor1.SelectMany(
                    s1 => factor2.Select(
                        s2 =>
                            new Summand
                            {
                                Coefficient = s1.Coefficient * s2.Coefficient,
                                PolynomialDegree = s1.PolynomialDegree + s2.PolynomialDegree,
                                Multiplicands = s1.Multiplicands.Concat(s2.Multiplicands).Select(s => s.Clone()).ToList()
                            }));

            return distribution;
        }

        private static IEnumerable<Summand> PlugTaylorSeriesInSummands(IEnumerable<Summand> summands, int maxTaylorDegree)
        {
            var expanded = summands.SelectMany(s => ReplaceSummandWithExpansion(s, maxTaylorDegree));
            var simplified = Simplify(expanded);

            return simplified;
        }

        private static IEnumerable<Summand> ReplaceSummandWithExpansion(Summand summand, int maxTaylorDegree)
        {
            if (MathHelper.IsZero(summand.Coefficient))
            {
                return new List<Summand>();
            }

            if (summand.Multiplicands.Count == 0)
            {
                return new List<Summand> { summand };
            }

            var returnedList = summand.Multiplicands[0].ToTaylorExpansion(maxTaylorDegree);

            for (var i = 1; i < summand.Multiplicands.Count; i++)
            {
                var nextExpansion = summand.Multiplicands[i].ToTaylorExpansion(maxTaylorDegree);
                returnedList = Distribute(returnedList, nextExpansion);
            }

            var multiplied =
                    returnedList.Select(s =>
                    {
                        s.Coefficient *= summand.Coefficient;
                        s.PolynomialDegree += summand.PolynomialDegree * s.PolynomialDegreeDenominator;
                        var gcd = MathHelper.GreatestCommonDivisor(s.PolynomialDegree, s.PolynomialDegreeDenominator);
                        s.PolynomialDegree /= gcd;
                        s.PolynomialDegreeDenominator /= gcd;
                        return s;
                    });

            return multiplied.OrderBy(s => s.LittleODegree).ThenBy(s => s.PolynomialDegree / (double)s.PolynomialDegreeDenominator);
        }

        private static IEnumerable<Summand> Distribute(IEnumerable<Summand> factor1, IEnumerable<Summand> factor2)
        {
            var distribution =
                factor1.SelectMany(
                    s1 => factor2.Select(
                        s2 => SimpleSummandProduct(s1, s2)));

            var simplified = Simplify(distribution);

            return simplified;
        }

        private static Summand SimpleSummandProduct(Summand s1, Summand s2)
        {
            var denominator = s1.PolynomialDegreeDenominator * s2.PolynomialDegreeDenominator;
            var numerator = s1.PolynomialDegree * s2.PolynomialDegreeDenominator +
                            s2.PolynomialDegree * s1.PolynomialDegreeDenominator;
            var gcd = MathHelper.GreatestCommonDivisor(numerator, denominator);
            return new Summand
            {
                Coefficient = s1.Coefficient * s2.Coefficient,
                PolynomialDegree = numerator / gcd,
                PolynomialDegreeDenominator = denominator / gcd,
                LittleODegree = s1.LittleODegree + s2.LittleODegree
            };
        }

        private static IEnumerable<Summand> Simplify(IEnumerable<Summand> series)
        {
            var grouped =
                series.GroupBy(
                    x =>
                        new
                        {
                            x.PolynomialDegree, x.PolynomialDegreeDenominator, x.LittleODegree
                        },
                    s => s,
                    (key, group) =>
                        new Summand
                        {
                            PolynomialDegree = key.PolynomialDegree,
                            LittleODegree = key.LittleODegree,
                            PolynomialDegreeDenominator = key.PolynomialDegreeDenominator,
                            Coefficient = group.Sum(e => e.Coefficient)
                        });
            var simplified =
                grouped.Where(s => !MathHelper.IsZero(s.Coefficient));

            return simplified;
        }

        private static IEnumerable<Summand> PerformTaylorExpansion(IEnumerable<Summand> summands)
        {
            int minPolynomialDegree = summands.Min(x => x.PolynomialDegree);

            var taylorDegrees = Enumerable.Range(2, 24).Concat(new[] {50, 100}).ToList();

            foreach (var deg in taylorDegrees)
            {
                var expanded = PlugTaylorSeriesInSummands(summands, deg);
                if (expanded
                    .Where(x => x.LittleODegree == 0)
                    .Any(x => x.PolynomialDegree <= x.PolynomialDegreeDenominator * (minPolynomialDegree + deg)))
                {
                    return expanded;
                }
            }



            return Enumerable.Empty<Summand>();
        }

    }
}
