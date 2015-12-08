using System;
using MA.Limits.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace MA.Limits.LimitsDomain
{
    public class Sine : IElementaryFunction
    {
        public double Aparam { get; set; }
        public double Bparam { get; set; }

        public IEnumerable<Summand> ToTaylorExpansion(int n)
        {
            if (MathHelper.IsZero(Aparam))
            {
                return new[]
                {
                    new Summand { Coefficient = Math.Sin(Bparam) }
                };
            }

            var sinB = Math.Sin(Bparam);
            var cosB = Math.Cos(Bparam);

            var isSinBZero = MathHelper.IsZero(sinB);
            var isCosBZero = MathHelper.IsZero(cosB);


            var returned = Enumerable.Range(0, n + 1)
                .Where(i => (!isSinBZero && i % 2 == 0) || (!isCosBZero && i % 2 == 1))
                .Select(
                    i =>
                        new Summand
                        {
                            Coefficient = (i % 2 == 0 ? sinB : cosB) * (i % 4 <= 1 ? 1 : -1) * MathHelper.FastPow(Aparam, i) / MathHelper.Factorial(i),
                            PolynomialDegree = i
                        })
                .Concat(new[] { new Summand { LittleODegree = n, Coefficient = 1.0 } });

            return returned;

            //return Enumerable.Range(0, n + 1)
            //                  .Where(i => i % 2 == 1)
            //                  .SelectMany(i =>
            //                      DomainHelper.RaiseLineToPowerWithBinomialExpansion(Aparam, Bparam, i).Select(s => new Summand
            //                      {
            //                          PolynomialDegree = s.PolynomialDegree,
            //                          Coefficient = s.Coefficient * (i % 4 == 1 ? 1.0 : -1.0) / MathHelper.Factorial(i)
            //                      }))
            //                  .Concat(new[] { new Summand { LittleODegree = n, Coefficient = 1.0 } });

        }


        public IElementaryFunction Clone()
        {
            return new Sine { Aparam = Aparam, Bparam = Bparam };
        }
    }
}
