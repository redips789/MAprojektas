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
    public interface Interface_Numerator
    {
        void Add_Simple_X_To_Summand(int polynomialDegree);
        void Add_PowerFunction_To_Summand(double a, double b, int n, int m);
        void Add_SinCosLn_To_Summand(double a, double b, int index);
        void Add_Exponential_To_Summand(double a, double b);
        void AddToSumTextBox(string message);
        void SetVisable(bool value);
        void Add_SumRaisedToPower_To_Summand(SumRaisedToPower sum);
    }
}
