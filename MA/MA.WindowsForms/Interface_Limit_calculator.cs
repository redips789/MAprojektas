using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MA.Limits.Helpers;
using MA.Limits.LimitsDomain;
using MA.Limits;

namespace MA.WindowsForms
{
    public interface Interface_Limit_calculator
    {
        void SetVisable(bool value);
        void AddToNumeratorDe(Summand summ, bool index);
        void AddToNuDeText(string message, bool Index);
    }
}
