using System;
using System.Collections.Generic;
using System.Linq;
using MA.Limits.Helpers;

namespace MA.Limits.LimitsDomain
{
    public class PowerFunction : IElementaryFunction
    {
        public double Aparam { get; set; }
        public double Bparam { get; set; }
        public double Power { get; set; }

        public IEnumerable<Summand> ToTaylorExpansion(int n)
        {
            if (MathHelper.IsInteger(Power))
            {
                return DomainHelper.RaiseLineToPowerWithBinomialExpansion(Aparam, Bparam, (int)Math.Round(Power));
            }


            return Enumerable.Range(0, n + 1)
                              .SelectMany(i =>
                                  DomainHelper.RaiseLineToPowerWithBinomialExpansion(Aparam, Bparam - 1, i).Select(s => new Summand
                                  {
                                      PolynomialDegree = s.PolynomialDegree,
                                      Coefficient = s.Coefficient * Enumerable.Range(0, i).Select(x => (double)x).Aggregate(1.0, (product, next) => product * (Power - next)) / MathHelper.Factorial(i)
                                      //Coefficient = s.Coefficient * Product(i) / MathHelper.Factorial(i)
                                  }))
                              .Concat(new[] { new Summand { LittleODegree = n, Coefficient = 1.0 } });

        }

        private double Product(int i)
        {
            var result = Enumerable.Range(0, i)
                .Select(x => (double) x)
                .Aggregate(1.0, (product, next) => product*(Power - next));

            return result;
        }
    }
}
