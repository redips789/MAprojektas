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

        public static double FastPow(double a, int n)
        {
            double result = 1;

            while (n > 0)
            {
                if ((n & 1) > 0)
                {
                    result *= a;
                }
                n >>= 1;
                a *= a;
            }

            return result;
        }

        public static double BinomialCoefficient(int n, int k)
        {
            double result = 1;
            for (var i = 1; i <= k; i++)
            {
                result *= n - (k - i);
                result /= i;
            }
            return Math.Round(result);
        }

        public static bool IsInteger(double x)
        {
            return AreApproximatelyEqual(x, Math.Round(x));
        }
    }
}
