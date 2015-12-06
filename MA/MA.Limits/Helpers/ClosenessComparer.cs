using System.Collections;
using System.Collections.Generic;
using MA.Limits.LimitsDomain;

namespace MA.Limits.Helpers
{
    public class ClosenessComparer : IEqualityComparer<Summand>
    {
        public bool Equals(Summand x, Summand y)
        {
            return x.LittleODegree == y.LittleODegree &&
                   MathHelper.AreApproximatelyEqual(x.PolynomialDegree, y.PolynomialDegree);
        }

        public int GetHashCode(Summand obj)
        {
            return 0;
        }
    }
}
