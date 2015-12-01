using System.Collections.Generic;

namespace MA.Limits.LimitsDomain
{
    public class Summand
    {
        public double Coefficient { get; set; }
        public int PolynomialDegree { get; set; }
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
