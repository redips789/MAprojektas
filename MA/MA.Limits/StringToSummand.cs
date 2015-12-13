using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MA.Limits.LimitsDomain;
using System.Globalization;

namespace MA.Limits
{
    public static class StringToSummand
    {
        public static List<Summand> Parse(string stringToParse)
        {
            List<Summand> summandsList = new List<Summand>();
            var stringsSplittedToSummands = SplitToSummands(stringToParse);

            foreach (var s in stringsSplittedToSummands)
            {
                summandsList.Add(ConvertToSummand(s));
            }

            return summandsList;
        }

        private static Summand ConvertToSummand(string stringToParse)
        {
            Summand summand = new Summand();
            summand.Coefficient = FindCoefficient(stringToParse);
            summand.PolynomialDegree = FindPolynomialDegree(stringToParse);

            var elementaryFunctionList = FindElementaryFunction(stringToParse);

            foreach (var function in elementaryFunctionList)
            {
                summand.Multiplicands.Add(ConvertToElementaryFunction(function));
            }

            var sumsRaisedToPowerList = FindSumRaisedToPower(stringToParse);

            foreach (var sum in sumsRaisedToPowerList)
            {
                SumRaisedToPower sumRaisedToPower = new SumRaisedToPower();
                sumRaisedToPower.Degree = GetSumsRaisedToPowerDegree(sum);
                sumRaisedToPower.Sum = Parse(EliminateDegree(sum));
                summand.SumsRaisedToPower.Add(sumRaisedToPower);
            }

            return summand;
        }

        private static string EliminateDegree(string str)
        {
            int opened = 0;
            int position = 0;
            for (int i = 0; i < str.Count(); i++)
            {
                if (str[i] == '(') opened++;
                if (str[i] == ')') opened--;

                if (str[i] == '^' && opened == 0)
                {
                    position = i;
                }
            }

            if (position == 0) return str;
            else return str.Substring(1, position - 2);
        }

        private static int GetSumsRaisedToPowerDegree(string str)
        {
            StringBuilder sb = new StringBuilder();
            int degree = 0;
            int opened = 0;
            for (int i = 0; i < str.Count(); i++)
            {
                if (str[i] == '(') opened++;
                if (str[i] == ')') opened--;

                if (str[i] == '^' && opened == 0)
                {
                    for (int j = i + 1; j < str.Count(); j++)
                    {
                        var temp = str[j];
                        if (int.TryParse(str[j].ToString(), out degree) == true)
                        {
                            sb.Append(str[j]);
                        }
                        else break;
                    }
                }
            }

            if (sb.ToString().Count() > 0) degree = int.Parse(sb.ToString());
            else degree = 1;

            return degree;
        }

        private static LinkedList<String> FindSumRaisedToPower(string str)
        {
            LinkedList<String> sums = new LinkedList<string>();
            int open = 0;

            for (int i = 0; i < str.Count(); i++)
            {
                if (str[i] == '(') open++;
                if (str[i] == ')') open--;
                if (str[i] == '*' && open == 0)
                {
                    int pos = 0;
                    int length = 0;
                    int opened = 0;
                    StringBuilder sb = new StringBuilder();
                    for (int j = i + 1; j < str.Count(); j++)
                    {
                        length++;
                        if (str[j] == '(') opened++;
                        if (str[j] == ')') opened--;

                        if (str[j] == ')' && opened == 0)
                        {
                            if ((j + 1) == str.Count())
                            {
                                break;
                            }

                            if (str[j + 1] == '^')
                            {

                                for (int z = j + 2; z < str.Count(); z++)
                                {
                                    length++;
                                    if (int.TryParse(str[z].ToString(), out pos) == false)
                                    {
                                        break;
                                    }
                                    if ((z + 1) == str.Count()) length++;
                                }
                            }
                            break;
                        }

                    }
                    string strToAdd = str.Substring(i + 1, length);
                    if (strToAdd.Count() > 2) sums.AddLast(strToAdd);
                }
            }

            return sums;
        }

        public static double[] FindParameters(string str)
        {
            double a = 0;
            double b = 0;
            int xpos = -1;

            for (int i = 0; i < str.Count(); i++)
            {
                if (str[i] == 'x') xpos = i;
            }

            int temp = 0;
            bool dot = false;
            bool negative = false;
            StringBuilder sb = new StringBuilder();
            bool piExist = false;
            for (int i = xpos - 1; i >= 0; i--)
            {
                if (str[i] == 'i' && str[i - 1] == 'P')
                {
                    piExist = true;
                    a = 1;

                }

                if (str[i] == '+')
                {
                    a = 1;
                    break;
                }

                if (str[i] == '.' && dot == false)
                {
                    dot = true;
                    sb.Append(str[i]);
                }
                else if (str[i] == '-' && negative == false)
                {
                    negative = true;
                    break;
                }
                else if (int.TryParse(str[i].ToString(), out temp) == true)
                {
                    sb.Append(str[i]);
                }
                else if (str[i] == '*' || (str[i] == 'i' && str[i - 1] == 'P') || (str[i] == 'P' && str[i + 1] == 'i'))
                {

                }
                else break;
            }

            string toParse = Reverse(sb.ToString());
            if (toParse.Count() > 0)
            {
                a = double.Parse(toParse,CultureInfo.InvariantCulture);
            }

            if (xpos == 0 || (xpos == 1 && negative == true && str[0] == '-'))
            {
                a = 1;
            }


            if (negative == true)
            {
                a = a * -1;
                negative = false;
            }

            if (piExist == true)
            {
                a = a * Math.PI;
            }

            sb.Clear();
            for (int i = 0; i < str.Count(); i++)
            {
                if (isInteger(str[i]) == true || str[i] == '.')
                {
                    sb.Append(str[i]);
                }
                else if (str[i] == '-' && negative == false)
                {
                    negative = true;
                }
                else if ((str[i] == '-' && negative == true) || str[i] == ')' || (str[i] == '+' && sb.ToString().Count() > 0))
                {
                    break;
                }
                else
                {
                    negative = false;
                    sb.Clear();
                }
            }

            string s = sb.ToString();
            if (s.Count() > 0)
            {
                b = double.Parse(sb.ToString(), CultureInfo.InvariantCulture);
            }


            if (negative == true)
            {
                b = b * -1;
                negative = false;
            }

            double[] array = { a, b };
            return array;

        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static bool isInteger(char s)
        {
            int a = 0;
            if (int.TryParse(s.ToString(), out a) == true)
            {
                return true;
            }
            else return false;
        }

        public static IElementaryFunction ConvertToElementaryFunction(string str)
        {
            IElementaryFunction function = null;
            double[] arr = null;


            if (str.Contains("sin"))
            {
                function = new Sine();
                arr = FindParameters(str.Substring(4, str.Count() - 4));
                function.Aparam = arr[0];
                function.Bparam = arr[1];
            }
            else if (str.Contains("cos"))
            {
                function = new Cosine();
                arr = FindParameters(str.Substring(4, str.Count() - 4));
                function.Aparam = arr[0];
                function.Bparam = arr[1];
            }
            else if (str.Contains("ln"))
            {
                function = new LogarithmicFunction();
                arr = FindParameters(str.Substring(3, str.Count() - 3));
                function.Aparam = arr[0];
                function.Bparam = arr[1];
            }
            else if (str.Contains("e^"))
            {
                function = new ExponentialFunction();
                arr = FindParameters(str.Substring(3, str.Count() - 3));
                function.Aparam = arr[0];
                function.Bparam = arr[1];
            }
            else if (str.Contains(")^(") || str.Contains("x^(") || str.Contains(")^"))
            {
                function = new PowerFunction();


                int powerPosition = 0;

                for (int i = 0; i < str.Count(); i++)
                {
                    if (str[i] == '^')
                    {
                        powerPosition = i;
                        StringBuilder num = new StringBuilder();
                        StringBuilder den = new StringBuilder();
                        bool slash = false;
                        for (int j = i + 1; j < str.Count(); j++)
                        {
                            if (str[j] != '/' && str[j] != '(' && str[j] != ')')
                            {
                                if (slash == false)
                                {
                                    num.Append(str[j]);
                                }
                                else den.Append(str[j]);

                            }
                            else if (str[j] == '/')
                            {
                                slash = true;
                            }
                        }

                        if (slash == false)
                        {
                            ((PowerFunction)function).PowerDenominator = 1;
                        }
                        else
                        {
                            ((PowerFunction)function).PowerDenominator = int.Parse(den.ToString());
                        }

                        ((PowerFunction)function).PowerNumerator = int.Parse(num.ToString());

                    }
                }

                int beginPosition = 0;

                if (str[0] == '(')
                {
                    beginPosition = 1;
                }

                arr = FindParameters(str.Substring(beginPosition, powerPosition - beginPosition));
                function.Aparam = arr[0];
                function.Bparam = arr[1];
            }

            return function;

        }

        public static LinkedList<String> FindElementaryFunction(string str)
        {
            int openned = 0;
            LinkedList<string> funcList = new LinkedList<string>();

            for (int i = 0; i < str.Count(); i++)
            {
                if (str[i] == '(') openned++;

                if (str[i] == ')') openned--;

                if ((i + 2) < (str.Count() - 1) && openned == 0 && ((str[i] == 's' && str[i + 1] == 'i' && str[i + 2] == 'n')
                                || (str[i] == 'c' && str[i + 1] == 'o' && str[i + 2] == 's')
                                || (str[i] == 'l' && str[i + 1] == 'n')
                                || (str[i] == 'e' && str[i + 1] == '^')))
                {

                    int lenght = 0;
                    for (int j = i; j < str.Count(); j++)
                    {
                        lenght++;
                        if (str[j] == ')')
                        {
                            break;
                        }

                    }

                    funcList.AddLast(str.Substring(i, lenght));
                }

                else if ((i + 1) < (str.Count() - 1) && openned == 0)
                {
                    int startPosition=0;
                    int lenght = 0;

                    if (str[i] == ')' && str[i + 1] == '^' && str[i + 2] == '(')
                    {
                        lenght = 0;
                        for (int j = i - 1; j >= 0; j--)
                        {
                            lenght++;
                            if (str[j] == '(')
                            {
                                break;
                            }

                        }

                        startPosition = i - lenght;

                        for (i = i + 3; i < str.Count(); i++)
                        {
                            if (isInteger(str[i]) == true || str[i] == ')' || str[i] == '/')
                            {
                                lenght++;
                            }
                            else break;
                        }

                        lenght += 3;
                        funcList.AddLast(str.Substring(startPosition, lenght));
                    }
                    else if (str[i] == 'x' && str[i + 1] == '^' && str[i + 2] == '(')
                    {
                        lenght = 0;
                        for (int j = i - 1; j >= 0; j--)
                        {

                            if (isInteger(str[j]) == true || str[j] == '*')
                            {
                                lenght++;
                            }
                            else break;

                        }

                        startPosition = i - lenght;

                        for (i = i + 3; i < str.Count(); i++)
                        {
                            if (isInteger(str[i]) == true || str[i] == ')' ||str[i]=='/')
                            {
                                lenght++;
                            }
                            else break;
                        }

                        lenght += 3;
                        funcList.AddLast(str.Substring(startPosition, lenght));
                    }
                    else if (str[i] == ')' && str[i + 1] == '^' && isInteger(str[i + 2]) == true)
                    {
                        lenght = 0;
                        for (int j = i - 1; j >= 0; j--)
                        {
                            lenght++;
                            if (str[j] == '(')
                            {
                                break;
                            }

                        }

                        startPosition = i - lenght;

                        for (i = i + 2; i < str.Count(); i++)
                        {
                            if (isInteger(str[i]) == true)
                            {
                                lenght++;
                            }
                            else break;
                        }

                        lenght += 2;
                        funcList.AddLast(str.Substring(startPosition, lenght));
                    }

                    
                }


            }

            return funcList;

        }

        private static bool check(string str, int index)
        {
            switch(str[index])
            {
                case 'x':
                    for (int i = 0; i < str.Count()-2; i++)
                    {
                        if ((str[i] == ')' && str[i + 1] == '^') || (str[i]=='x' && str[i+1]=='^' && str[i+2]=='('))
                        {
                            return true;
                        }
                    }

                    return false;

                case '^':
                    if (str[index + 1] == '(' && str[index - 1] == ')' || (str[index+1]=='(' && str[index-1]=='x'))
                        return true;
                    else return false;
                default:
                    return false;
            }


        }


        public static int FindPolynomialDegree(string str)
        {
            int degree = 1;
            int a = 0;
            bool existNonFigure = false;
            int opened = 0;

            if (str[0] == '(' && str[str.Count() - 1] == ')')
            {
                bool openedBracket=false;
                bool parenthesized = true;
                for (int i = 0; i < str.Count(); i++)
                {
                    if (str[i] == '(')
                    {
                        openedBracket = true;
                    }
                    else if (str[i] == ')' && openedBracket == true)
                    {
                        openedBracket = false;
                    }

                    else if (str[i] == ')' && openedBracket == false)
                    {
                        parenthesized = false;
                        break;
                    }
                }

                if (parenthesized)
                {
                    opened = -1;
                }
                    
            }

            for (int i = 0; i < str.Count(); i++)
            {
                if (str[i] == '(') opened++;

                if (str[i] == ')') opened--;

                if (str[i] == '^' && opened == 0 && str[i - 1] != 'e' && check(str,i)==false)
                {
                    degree = (int)FindCoefficient(str.Substring(i + 1));
                    existNonFigure = true;
                }

                if (str[i] == 'x' && opened == 0 && check(str,i)==false)
                {
                    existNonFigure = true;
                }
            }

            if (existNonFigure == false) degree = 0;

            return degree;
        }

        private static double FindCoefficient(string str)
        {
            StringBuilder db = new StringBuilder();
            bool negative = false;
            bool dot = false;
            int index = 0;

            if (str[0] == '(') index = 1;
            else index = 0;

            for (int i = index; i < str.Count(); i++)
            {
                int a = 0;

                if (str[i] == '.' && dot == false)
                {
                    db.Append(str[i]);
                    dot = true;
                }

                else if (str[i] == '-' && negative == false)
                {
                    negative = true;
                }

                else if (int.TryParse(str[i].ToString(), out a) == true)
                {
                    db.Append(str[i]);
                }

                else break;

            }

            double fig = 1;

            if (db.ToString().Count() > 0)
            {
                fig = double.Parse(db.ToString(), CultureInfo.InvariantCulture);
            }

            if (negative == true)
            {
                fig = fig * -1;
            }

            return fig;
        }

        private static LinkedList<String> SplitToSummands(string str)
        {
            LinkedList<int> positions = new LinkedList<int>();
            LinkedList<string> ListOfSummands = new LinkedList<string>();
            int opened = 1;
            int summands = 0;
            int startPosition = 0;
            int length = 0;
            bool isParenthesized = false;
            bool insideFunction = false;

            if (str[0] == '(' && str[str.Count() - 1] == ')')
            {
                startPosition = 1;
                length = -1;
                isParenthesized = true;
                opened = 0;
            }

            for (int i = 0; i < str.Count(); i++)
            {
                if (str[i] == '(') opened++;
                if (str[i] == ')')
                {
                    if (insideFunction == true)
                    {
                        insideFunction = false;
                    }
                    opened--;
                }

                if ((i + 2) != str.Count() && ((str[i] == 's' && str[i + 1] == 'i' && str[i + 2] == 'n')
                || (str[i] == 'c' && str[i + 1] == 'o' && str[i + 2] == 's')
                || (str[i] == 'l' && str[i + 1] == 'n')
                || (str[i] == 'e' && str[i + 1] == '^')))
                {
                    insideFunction = true;
                }

                if ((i+2)<str.Count() && (str[i] =='+' || str[i] == '-'))
                {
                    for (int j = i+1; j < str.Count()-2; j++)
                    {
                        if (str[j] == ')' && str[j + 1] == '^')
                        {
                            insideFunction = true;
                        }
                    }
                }

                if ((str[i] == '+' || str[i] == '-') && opened == 1 && insideFunction == false && length>0)
                {
                    ListOfSummands.AddLast(str.Substring(startPosition, length));
                    startPosition = i;
                    summands++;
                    length = 0;
                }

                if ((i + 1) == str.Count())
                {
                    if (isParenthesized == false) length++;

                    ListOfSummands.AddLast(str.Substring(startPosition, length));
                    summands++;
                }
                length++;
            }

            return ListOfSummands;
        }

    }
}
