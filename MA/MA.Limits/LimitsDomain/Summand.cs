using System;
using System.Collections.Generic;
using MA.Limits.Helpers;

namespace MA.Limits.LimitsDomain
{
    public class Summand
    {
        public double Coefficient { get; set; }

        public int PolynomialDegree { get; set; }


        /// <summary>
        /// for internal usage only!!!
        /// </summary>
        public int PolynomialDegreeDenominator { get; set; }

        /// <summary>
        /// for internal usage only!!!
        /// </summary>
        public int LittleODegree { get; set; }
        
        public List<IElementaryFunction> Multiplicands { get; set; }

        public List<SumRaisedToPower> SumsRaisedToPower { get; set; }

        public Summand()
        {
            Multiplicands = new List<IElementaryFunction>();
            SumsRaisedToPower = new List<SumRaisedToPower>();
            Coefficient = 1.0;
            PolynomialDegreeDenominator = 1;
        }
    }
}
