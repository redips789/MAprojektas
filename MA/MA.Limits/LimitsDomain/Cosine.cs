using MA.Limits.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.Limits.LimitsDomain
{
    public class Cosine : IElementaryFunction
    {
        public double Aparam { get; set; }
        public double Bparam { get; set; }

        public IEnumerable<Summand> ToTaylorExpansion(int n)
        {
            if (MathHelper.IsZero(Aparam))
            {
                return new[]
                {
                    new Summand { Coefficient = Math.Cos(Bparam) }
                };
            }

            var sinB = Math.Sin(Bparam);
            var cosB = Math.Cos(Bparam);

            var isSinBZero = MathHelper.IsZero(sinB);
            var isCosBZero = MathHelper.IsZero(cosB);


            var returned = Enumerable.Range(0, n + 1)
                .Where(i => (!isCosBZero && i % 2 == 0) || (!isSinBZero && i % 2 == 1))
                .Select(
                    i =>
                        new Summand
                        {
                            Coefficient = (i % 2 == 0 ? cosB : sinB) * (i % 4 == 0 || i % 4 == 3 ? 1 : -1) * MathHelper.FastPow(Aparam, i) / MathHelper.Factorial(i),
                            PolynomialDegree = i
                        })
                .Concat(new[] { new Summand { LittleODegree = n, Coefficient = 1.0 } });

            return returned;
        }


        public IElementaryFunction Clone()
        {
            return new Cosine { Aparam = Aparam, Bparam = Bparam };
        }

    }
}
