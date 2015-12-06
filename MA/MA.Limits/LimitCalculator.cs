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
            return CalculateLimit(normalizedFunction, argument, 7);
        }

        public static LimitResult CalculateLimit(NormalizedFunction normalizedFunction, double argument, int maxTaylorDegree)
        {
            var raisedNumerator = normalizedFunction.Numerator.SelectMany(RaiseSumsToPower);
            var raisedDenominator = normalizedFunction.Denominator.SelectMany(RaiseSumsToPower);

            if (!MathHelper.AreApproximatelyEqual(argument, 0))
            {
                raisedNumerator = TransformArgumentToZero(raisedNumerator, argument);
                raisedDenominator = TransformArgumentToZero(raisedDenominator, argument);
            }

            var expandedNumerator = PlugTaylorSeriesInSummands(raisedNumerator, maxTaylorDegree);
            var expandedDenominator = PlugTaylorSeriesInSummands(raisedDenominator, maxTaylorDegree);

            var numeratorMinPolynomialWithoutO = expandedNumerator.First(s => s.LittleODegree == 0);
            var denominatorMinPolynomialWithoutO = expandedDenominator.First(s => s.LittleODegree == 0);

            if (MathHelper.AreApproximatelyEqual(numeratorMinPolynomialWithoutO.PolynomialDegree,
                denominatorMinPolynomialWithoutO.PolynomialDegree))
            {
                return new LimitResult
                {
                    LimitResultType = LimitResultType.RealNumber,
                    Value = numeratorMinPolynomialWithoutO.Coefficient / denominatorMinPolynomialWithoutO.Coefficient
                };
            }

            if (numeratorMinPolynomialWithoutO.PolynomialDegree > denominatorMinPolynomialWithoutO.PolynomialDegree)
            {
                return new LimitResult
                {
                    LimitResultType = LimitResultType.RealNumber,
                    Value = 0
                };
            }

            if (((int)denominatorMinPolynomialWithoutO.PolynomialDegree - (int)denominatorMinPolynomialWithoutO.PolynomialDegree)
                % 2 == 1)
            {
                return new LimitResult { LimitResultType = LimitResultType.DoesNotExist };
            }

            if (numeratorMinPolynomialWithoutO.Coefficient * denominatorMinPolynomialWithoutO.Coefficient > 0)
            {
                return new LimitResult { LimitResultType = LimitResultType.PositiveInfinity };
            }

            return new LimitResult { LimitResultType = LimitResultType.NegativeInfinity };

        }

        public static IEnumerable<Summand> TransformArgumentToZero(IEnumerable<Summand> summands, double argument)
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
                        DomainHelper.RaiseLineToPowerWithBinomialExpansion(1, argument, (int)s.PolynomialDegree)
                            .Select(x => new Summand
                            {
                                PolynomialDegree = x.PolynomialDegree,
                                Coefficient = s.Coefficient*x.Coefficient,
                                Multiplicands = s.Multiplicands
                            }));

            return returned;
        }

        public static IEnumerable<Summand> RaiseSumsToPower(Summand summand)
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

        public static IEnumerable<Summand> DistributeIncludingElementaryFunctions(IEnumerable<Summand> factor1, IEnumerable<Summand> factor2)
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

        public static IEnumerable<Summand> PlugTaylorSeriesInSummands(IEnumerable<Summand> summands, int maxTaylorDegree)
        {
            var expanded = summands.SelectMany(s => ReplaceSummandWithExpansion(s, maxTaylorDegree));
            var simplified = Simplify(expanded);

            return simplified;
        }

        public static IEnumerable<Summand> ReplaceSummandWithExpansion(Summand summand, int maxTaylorDegree)
        {
            if (MathHelper.AreApproximatelyEqual(summand.Coefficient, 0))
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
                        s.PolynomialDegree += summand.PolynomialDegree;
                        return s;
                    });

            return multiplied.OrderBy(s => s.LittleODegree).ThenBy(s => s.PolynomialDegree);
        }

        public static IEnumerable<Summand> Distribute(IEnumerable<Summand> factor1, IEnumerable<Summand> factor2)
        {
            var distribution =
                factor1.SelectMany(
                    s1 => factor2.Select(
                        s2 =>
                            new Summand
                            {
                                Coefficient = s1.Coefficient * s2.Coefficient,
                                PolynomialDegree = s1.PolynomialDegree + s2.PolynomialDegree,
                                LittleODegree = s1.LittleODegree + s2.LittleODegree
                            }));

            var simplified = Simplify(distribution);

            return simplified;
        }

        public static IEnumerable<Summand> Simplify(IEnumerable<Summand> series)
        {
            var grouped =
                series.GroupBy(x => new Summand(){ PolynomialDegree = x.PolynomialDegree, LittleODegree = x.LittleODegree },
                    s => s,
                    (key, group) =>
                        new Summand
                        {
                            PolynomialDegree = key.PolynomialDegree,
                            LittleODegree = key.LittleODegree,
                            Coefficient = group.Sum(e => e.Coefficient)
                        },
                        new ClosenessComparer());
            var simplified =
                grouped.Where(s => !MathHelper.AreApproximatelyEqual(s.Coefficient, 0));

            return simplified;
        }

    }
}
