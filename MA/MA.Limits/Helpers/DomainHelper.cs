using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MA.Limits.LimitsDomain;

namespace MA.Limits.Helpers
{
    public static class DomainHelper
    {
        // (a * x + b) ^ n
        public static IEnumerable<Summand> RaiseLineToPowerWithBinomialExpansion(double a, double b, int n)
        {
            if (MathHelper.AreApproximatelyEqual(b, 0))
            {
                return new List<Summand>
                {
                    new Summand
                    {
                        PolynomialDegree = n,
                        Coefficient = MathHelper.FastPow(a, n)
                    }
                };
            }

            var returned = Enumerable.Range(0, n + 1).Select(k => new Summand
            {
                PolynomialDegree = k,
                Coefficient = MathHelper.BinomialCoefficient(n, k) * MathHelper.FastPow(a, k) * MathHelper.FastPow(b, n - k)
            });

            return returned;
        }
    }
}
