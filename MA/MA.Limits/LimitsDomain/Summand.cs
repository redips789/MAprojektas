using System;
using System.Collections.Generic;
using MA.Limits.Helpers;

namespace MA.Limits.LimitsDomain
{
    public class Summand
    {
        public double Coefficient { get; set; }

        private double _polynomialDegree;
        public double PolynomialDegree
        {
            get { return _polynomialDegree; }
            set { _polynomialDegree = MathHelper.IsInteger(value) ? (int) Math.Round(value) : value; }
        }
        public int LittleODegree { get; set; }
        
        public List<IElementaryFunction> Multiplicands { get; set; }

        public List<SumRaisedToPower> SumsRaisedToPower { get; set; }

        public Summand()
        {
            Multiplicands = new List<IElementaryFunction>();
            SumsRaisedToPower = new List<SumRaisedToPower>();
        }
    }
}
