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
            return Enumerable.Range(0, n + 1)
                              .Where(i => i % 2 == 1)
                              .SelectMany(i =>
                                  DomainHelper.RaiseLineToPowerWithBinomialExpansion(Aparam, Bparam, i).Select(s => new Summand
                                  {
                                      PolynomialDegree = s.PolynomialDegree,
                                      Coefficient = s.Coefficient * (i % 4 == 1 ? 1.0 : -1.0) / MathHelper.Factorial(i)
                                  }))
                              .Concat(new[] { new Summand { LittleODegree = n, Coefficient = 1.0 } });

        }
    }
}
