using System;

namespace MA.Limits.Helpers
{
    public static class MathHelper
    {
        public static long Factorial(int n)
        {
            long ret = 1;
            for (int i = 2; i <= n; i++)
            {
                ret *= i;
            }
            return ret;
        }

        public static bool AreApproximatelyEqual(double value1, double value2)
        {
            return AreApproximatelyEqual(value1, value2, 1.0e-10);
        }

        public static bool AreApproximatelyEqual(double value1, double value2, double maxDifference)
        {
            return Math.Abs(value1 - value2) < maxDifference;
        }
    }
}
