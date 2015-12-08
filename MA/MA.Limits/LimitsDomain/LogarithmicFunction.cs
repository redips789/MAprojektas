using MA.Limits.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.Limits.LimitsDomain
{
    public class LogarithmicFunction : IElementaryFunction
    {
        public double Aparam { get; set; }
        public double Bparam { get; set; }

        public IEnumerable<Summand> ToTaylorExpansion(int n)
        {
            if (Bparam <= 0 || MathHelper.IsZero(Bparam))
            {
                throw new LimitDoesNotExistException();
            }

            if (MathHelper.IsZero(Aparam))
            {
                return new[]
                {
                    new Summand { Coefficient = Math.Log(Bparam) }
                };
            }

            var lnB = Math.Log(Bparam);
            var aOverB = Aparam / Bparam;

            var returned = Enumerable.Range(0, n + 1)
                .Select(
                    i =>
                        new Summand
                        {
                            Coefficient = i == 0 ? lnB : (i % 2 == 1 ? 1 : -1) * MathHelper.FastPow(aOverB, i) / i,
                            PolynomialDegree = i
                        })
                .Concat(new[] { new Summand { LittleODegree = n, Coefficient = 1.0 } });

            return returned;

        }


        public IElementaryFunction Clone()
        {
            return new LogarithmicFunction { Aparam = Aparam, Bparam = Bparam };
        }

    }
}
