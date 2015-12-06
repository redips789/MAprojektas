using System.Collections.Generic;

namespace MA.Limits.LimitsDomain
{
    public interface IElementaryFunction
    {
        double Aparam { get; set; }
        double Bparam { get; set; }
        IEnumerable<Summand> ToTaylorExpansion(int n);
        IElementaryFunction Clone();
    }
}
