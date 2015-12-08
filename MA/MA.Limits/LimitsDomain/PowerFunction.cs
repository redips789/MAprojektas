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
        public int PowerNumerator { get; set; }
        public int PowerDenominator { get; set; }

        public IEnumerable<Summand> ToTaylorExpansion(int n)
        {
            var power = ((double)PowerNumerator) / PowerDenominator;

            if (MathHelper.IsInteger(power))
            {
                return DomainHelper.RaiseLineToPowerWithBinomialExpansion(Aparam, Bparam, (int)Math.Round(power));
            }

            if (MathHelper.IsZero(Bparam))
            {
                var aPowered = MathHelper.Power(Aparam, PowerNumerator, PowerDenominator);

                if (double.IsNaN(aPowered))
                {
                    throw new LimitDoesNotExistException();
                }

                return new List<Summand> { new Summand { Coefficient = Math.Pow(aPowered, power), PolynomialDegree = power } };
            }


            var bPowered = MathHelper.Power(Bparam, PowerNumerator, PowerDenominator);

            if (double.IsNaN(bPowered))
            {
                throw new LimitDoesNotExistException();
            }

            return Enumerable.Range(0, n + 1)
                              .Select(i =>
                                  //DomainHelper.RaiseLineToPowerWithBinomialExpansion(Aparam, Bparam - 1, i).Select(s => new Summand
                                  //{
                                  //    PolynomialDegree = s.PolynomialDegree,
                                  //    //Coefficient = s.Coefficient * Enumerable.Range(0, i).Select(x => (double)x).Aggregate(1.0, (product, next) => product * (Power - next)) / MathHelper.Factorial(i)
                                  //    Coefficient = s.Coefficient * Product(i) / MathHelper.Factorial(i)
                                  //}))
                                  new Summand
                                  {
                                    PolynomialDegree = i,
                                    Coefficient = bPowered * Product(i, power) * MathHelper.FastPow(Aparam / Bparam, i) / MathHelper.Factorial(i)
                                  })
                              .Concat(new[] { new Summand { LittleODegree = n, Coefficient = 1.0 } });

        }

        private double Product(int i, double power)
        {
            var result = Enumerable.Range(0, i)
                .Select(x => (double) x)
                .Aggregate(1.0, (product, next) => product * (power - next));

            return result;
        }




        public IElementaryFunction Clone()
        {
            return new PowerFunction
            {
                Aparam = Aparam,
                Bparam = Bparam,
                PowerNumerator = PowerNumerator,
                PowerDenominator = PowerDenominator
            };
        }
    }
}
