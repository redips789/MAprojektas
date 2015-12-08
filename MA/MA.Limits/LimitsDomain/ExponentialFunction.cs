using MA.Limits.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.Limits.LimitsDomain
{
    public class ExponentialFunction : IElementaryFunction
    {
        public double Aparam { get; set; }
        public double Bparam { get; set; }

        public IEnumerable<Summand> ToTaylorExpansion(int n)
        {
            if (MathHelper.IsZero(Aparam))
            {
                return new[]
                {
                    new Summand { Coefficient = Math.Exp(Bparam) }
                };
            }

            var expB = Math.Exp(Bparam);

            var returned = Enumerable.Range(0, n + 1)
                .Select(
                    i =>
                        new Summand
                        {
                            Coefficient = expB * MathHelper.FastPow(Aparam, i) / MathHelper.Factorial(i),
                            PolynomialDegree = i
                        })
                .Concat(new[] { new Summand { LittleODegree = n, Coefficient = 1.0 } });

            return returned;
        }


        public IElementaryFunction Clone()
        {
            return new ExponentialFunction { Aparam = Aparam, Bparam = Bparam };
        }

    }
}
