
using System.Collections.Generic;

public class Polynomial
{
    public char Variable { get; set; }

    protected List<string> monomials = new List<string>();
    protected List<string> monomials_afterSum = new List<string>();


    protected string WhiteSpaceTrim(string rawtext)
    {
        string newText = "";
        foreach (char ch in rawtext)
        {
            if (ch != ' ')
            {
                newText += ch;
            }
        }
        return newText;
    }


    protected void FindMonomials(string rawtext)
    {
        string monTemp = "";
        foreach (char ch in rawtext)
        {
            if (ch != '+' && ch != '-')
            {
                monTemp += ch;
            }
            else
            {
                monomials.Add(monTemp);
                monTemp = "";
                if (ch == '-') monTemp += ch;
            }
        }
        monomials.Add(monTemp);
    }


    protected void SumSimilar()
    {
        int cRes = 0;
        int maxDegree = 0;

        foreach (string monomial in monomials)
        {
            if (monomial.Contains(Variable) && monomial.Contains('^'))
            {
                int degreeTemp = 0;
                int.TryParse(monomial[monomial.Length - 1].ToString(), out degreeTemp);

                if (degreeTemp > maxDegree) maxDegree = degreeTemp;
            }
        }

        for (int i = maxDegree; i > 0; i--)
        {
            cRes = 0;
            foreach (string monomial in monomials)
            {
                if (monomial.Contains(Variable) && monomial.Contains('^'))
                {
                    int degreeTemp = 0;
                    int.TryParse(monomial[monomial.Length - 1].ToString(), out degreeTemp);

                    if (degreeTemp == i)
                    {
                        int cTemp = 0;
                        string monTemp = monomial.Remove(monomial.IndexOf(Variable), 1);
                        monTemp = monTemp.Remove(monTemp.IndexOf('^'));

                        int.TryParse(monTemp, out cTemp);
                        if (cTemp == 0)
                        {
                            if (monTemp.Contains('-')) cTemp = -1;
                            else cTemp = 1;
                        }
                        cRes += cTemp;
                    }
                }
            }

            switch (cRes)
            {
                case -1: monomials_afterSum.Add("-" + Variable + "^" + i.ToString()); break;
                case 0: break;
                case 1: monomials_afterSum.Add("" + Variable + "^" + i.ToString()); break;
                default: monomials_afterSum.Add(cRes.ToString() + Variable + "^" + i.ToString()); break;
            }
        }

        cRes = 0;
        foreach (string monomial in monomials)
        {
            if (monomial.Contains(Variable) && !monomial.Contains('^'))
            {
                int cTemp = 0;
                string monTemp = monomial.Remove(monomial.IndexOf(Variable), 1);

                int.TryParse(monTemp, out cTemp);
                if (cTemp == 0)
                {
                    if (monTemp.Contains('-')) cTemp = -1;
                    else cTemp = 1;
                }
                cRes += cTemp;
            }
        }

        switch (cRes)
        {
            case -1: monomials_afterSum.Add("-" + Variable); break;
            case 0: break;
            case 1: monomials_afterSum.Add("" + Variable); break;
            default: monomials_afterSum.Add(cRes.ToString() + Variable); break;
        }

        cRes = 0;
        foreach (string monomial in monomials)
        {
            bool isNumber = true;
            if (monomial.Contains(Variable)) isNumber = false;

            if (isNumber)
            {
                int cTemp = 0;
                if (monomial.Contains('^'))
                {
                    cTemp = 1;
                    int degreeTemp = 0;
                    int.TryParse(monomial[monomial.Length - 1].ToString(), out degreeTemp);

                    string monTemp = monomial.Remove(monomial.IndexOf('^'));

                    int.TryParse(monTemp, out cTemp);

                    for (int i = 0; i < degreeTemp - 1; i++) cTemp *= cTemp;

                    if (monomial.Contains('-')) cTemp *= -1;
                }
                else int.TryParse(monomial, out cTemp);
                cRes += cTemp;
            }
        }
        if (cRes != 0) monomials_afterSum.Add(cRes.ToString());
    }


    public Polynomial(string formulaInString, char usedVariable)
    {
        this.Variable = usedVariable;
        FindMonomials(WhiteSpaceTrim(formulaInString.ToLower()));
        SumSimilar();
    }

    public Polynomial(List<string> monomials, char usedVariable)
    {
        this.Variable = usedVariable;
        this.monomials = monomials;
        SumSimilar();
    }


    public string TextView_Original()
    {
        string result = "";
        if (monomials_afterSum.Count > 0)
        {
            foreach (string monomial in monomials)
            {
                if (monomial.Contains('-'))
                {
                    result += " - " + monomial.Substring(1);
                }
                else
                {
                    if (monomials.IndexOf(monomial) == 0) result += monomial;
                    else result += " + " + monomial;
                }
            }
        }
        else result = "0";
        
        return result;
    }

    public string TextView_AfterSum()
    {
        string result = "";
        if (monomials_afterSum.Count > 0)
        {
            foreach (string monomial in monomials_afterSum)
            {
                if (monomial.Contains('-'))
                {
                    result += " - " + monomial.Substring(1);
                }
                else
                {
                    if (monomials_afterSum.IndexOf(monomial) == 0) result += monomial;
                    else result += " + " + monomial;
                }
            }
        }
        else result = "0";

        return result;
    }


    protected static void Subtract(List<string> monomials, out List<string> monomials_AfterSubtract, char Variable)
    {
        int cRes = 0;
        int cTemp1 = 0;
        int cTemp2 = 0;
        int counter = 0;
        int maxDegree = 0;

        monomials_AfterSubtract = new List<string>();

        foreach (string monomial in monomials)
        {
            if (monomial.Contains(Variable) && monomial.Contains('^'))
            {
                int degreeTemp = 0;
                int.TryParse(monomial[monomial.Length - 1].ToString(), out degreeTemp);

                if (degreeTemp > maxDegree) maxDegree = degreeTemp;
            }
        }

        for (int i = maxDegree; i > 0; i--)
        {
            cTemp1 = 0;
            cTemp2 = 0;
            counter = 0;
            foreach (string monomial in monomials)
            {
                if (monomial.Contains(Variable) && monomial.Contains('^'))
                {
                    int degreeTemp = 0;
                    int.TryParse(monomial[monomial.Length - 1].ToString(), out degreeTemp);

                    if (degreeTemp == i)
                    {
                        counter++;
                        int cTemp = 0;
                        string monTemp = monomial.Remove(monomial.IndexOf(Variable), 1);
                        monTemp = monTemp.Remove(monTemp.IndexOf('^'));

                        int.TryParse(monTemp, out cTemp);
                        if (cTemp == 0)
                        {
                            if (monTemp.Contains('-')) cTemp = -1;
                            else cTemp = 1;
                        }

                        if (counter == 1) cTemp1 = cTemp;
                        else cTemp2 = cTemp;
                    }
                }
            }
            cRes = cTemp1 - cTemp2;

            switch (cRes)
            {
                case -1: monomials_AfterSubtract.Add("-" + Variable + "^" + i.ToString()); break;
                case 0: break;
                case 1: monomials_AfterSubtract.Add("" + Variable + "^" + i.ToString()); break;
                default: monomials_AfterSubtract.Add(cRes.ToString() + Variable + "^" + i.ToString()); break;
            }
        }

        cTemp1 = 0;
        cTemp2 = 0;
        counter = 0;
        foreach (string monomial in monomials)
        {
            if (monomial.Contains(Variable) && !monomial.Contains('^'))
            {
                counter++;
                int cTemp = 0;
                string monTemp = monomial.Remove(monomial.IndexOf(Variable), 1);

                int.TryParse(monTemp, out cTemp);
                if (cTemp == 0)
                {
                    if (monTemp.Contains('-')) cTemp = -1;
                    else cTemp = 1;
                }

                if (counter == 1) cTemp1 = cTemp;
                else cTemp2 = cTemp;
            }
        }
        cRes = cTemp1 - cTemp2;

        switch (cRes)
        {
            case -1: monomials_AfterSubtract.Add("-" + Variable); break;
            case 0: break;
            case 1: monomials_AfterSubtract.Add("" + Variable); break;
            default: monomials_AfterSubtract.Add(cRes.ToString() + Variable); break;
        }

        cTemp1 = 0;
        cTemp2 = 0;
        counter = 0;
        foreach (string monomial in monomials)
        {
            bool isNumber = true;
            if (monomial.Contains(Variable)) isNumber = false;

            if (isNumber)
            {
                counter++;
                int cTemp = 0;
                int.TryParse(monomial, out cTemp);

                if (counter == 1) cTemp1 = cTemp;
                else cTemp2 = cTemp;
            }
        }
        cRes = cTemp1 - cTemp2;

        if (cRes != 0) monomials_AfterSubtract.Add(cRes.ToString());
    }


    protected static void Multiply(List<string> monomials1, List<string> monomials2, out List<string> monomials_AfterSubtract, char Variable)
    {
        monomials_AfterSubtract = new List<string>();

        foreach (string mon1 in monomials1)
        {
            int c1Temp = 0;
            int c2Temp = 0;
            int degree1 = 0;
            int degree2 = 0;

            if (mon1.Contains(Variable) && mon1.Contains('^'))
            {
                int.TryParse(mon1[mon1.Length - 1].ToString(), out degree1);

                string monTemp = mon1.Remove(mon1.IndexOf(Variable), 1);
                monTemp = monTemp.Remove(monTemp.IndexOf('^'));

                int.TryParse(monTemp, out c1Temp);
                if (c1Temp == 0)
                {
                    if (monTemp.Contains('-')) c1Temp = -1;
                    else c1Temp = 1;
                }
            }
            else if (mon1.Contains(Variable) && !mon1.Contains('^'))
            {
                degree1 = 1;
                string monTemp = mon1.Remove(mon1.IndexOf(Variable), 1);
                int.TryParse(monTemp, out c1Temp);
                if (c1Temp == 0)
                {
                    if (monTemp.Contains('-')) c1Temp = -1;
                    else c1Temp = 1;
                }
            }
            else
            {
                degree1 = 0;
                int.TryParse(mon1, out c1Temp);
            }

            foreach (string mon2 in monomials2)
            {
                if (mon2.Contains(Variable) && mon2.Contains('^'))
                {
                    int.TryParse(mon2[mon2.Length - 1].ToString(), out degree2);

                    string monTemp = mon2.Remove(mon2.IndexOf(Variable), 1);
                    monTemp = monTemp.Remove(monTemp.IndexOf('^'));

                    int.TryParse(monTemp, out c2Temp);
                    if (c2Temp == 0)
                    {
                        if (monTemp.Contains('-')) c2Temp = -1;
                        else c2Temp = 1;
                    }
                }
                else if (mon2.Contains(Variable) && !mon2.Contains('^'))
                {
                    degree2 = 1;
                    string monTemp = mon2.Remove(mon2.IndexOf(Variable), 1);
                    int.TryParse(monTemp, out c2Temp);
                    if (c2Temp == 0)
                    {
                        if (monTemp.Contains('-')) c2Temp = -1;
                        else c2Temp = 1;
                    }
                }
                else
                {
                    degree2 = 0;
                    int.TryParse(mon2, out c2Temp);
                }


                int cRes = c1Temp * c2Temp;
                int degree = degree1 + degree2;
                if (degree > 1) monomials_AfterSubtract.Add(cRes.ToString() + Variable + '^' + degree);
                else if (degree == 1) monomials_AfterSubtract.Add(cRes.ToString() + Variable);
                else monomials_AfterSubtract.Add(cRes.ToString());
            }
        }
    }


    public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
    {
        List<string> monomialsNew = new List<string>();

        foreach (string monomial in pol1.monomials_afterSum)
        {
            monomialsNew.Add(monomial);
        }
        foreach (string monomial in pol2.monomials_afterSum)
        {
            monomialsNew.Add(monomial);
        }

        return new Polynomial(monomialsNew, pol1.Variable);
    }


    public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
    {
        List<string> monomialsNew = new List<string>();
        List<string> result;

        foreach (string monomial in pol1.monomials_afterSum)
        {
            monomialsNew.Add(monomial);
        }
        foreach (string monomial in pol2.monomials_afterSum)
        {
            monomialsNew.Add(monomial);
        }

        Subtract(monomialsNew, out result, pol1.Variable);

        return new Polynomial(result, pol1.Variable);
    }


    public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
    {
        List<string> monomialsNew = new List<string>();
        List<string> result;

        Multiply(pol1.monomials_afterSum, pol2.monomials_afterSum, out result, pol1.Variable);

        return new Polynomial(result, pol1.Variable);
    }
}
