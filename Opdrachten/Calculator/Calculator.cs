using System;

namespace Calculator
{
    public class Calculator
    {
        public string Evaluate(string expr)
        {
            if (expr == null)
            {
                return "Crazy input!";
            }

            expr = expr.Replace(" ", "");
            if (expr.Length == 0)
            {
                return "Crazy input!";
            }

            int parenCount = 0;
            foreach (char c in expr)
            {
                if (c == '(')
                {
                    parenCount++;
                }
                else if (c == ')')
                {
                    parenCount--;
                }

                if (parenCount < 0)
                {
                    return "Crazy input!";
                }
            }

            if (parenCount != 0)
            {
                return "Crazy input!";
            }

            while (expr.Length >= 2 && expr.StartsWith("(") && expr.EndsWith(")"))
            {
                int count = 0;
                bool canRemove = true;
                for (int i = 0; i < expr.Length; i++)
                {
                    if (expr[i] == '(')
                    {
                        count++;
                    }
                    else if (expr[i] == ')')
                    {
                        count--;
                    }

                    if (count == 0 && i < expr.Length - 1)
                    {
                        canRemove = false;
                        break;
                    }
                }

                if (!canRemove)
                {
                    break;
                }

                expr = expr.Substring(1, expr.Length - 2);
                if (expr.Length == 0)
                {
                    return "Crazy input!";
                }
            }

            int opPos = -1;
            {
                int count = 0;
                for (int i = expr.Length - 1; i >= 0; i--)
                {
                    char c = expr[i];
                    if (c == ')')
                    {
                        count++;
                    }
                    else if (c == '(')
                    {
                        count--;
                    }
                    else if (count == 0 && (c == '+' || c == '-'))
                    {
                        opPos = i;
                        break;
                    }
                }
            }

            if (opPos == -1)
            {
                int count = 0;
                for (int i = expr.Length - 1; i >= 0; i--)
                {
                    char c = expr[i];
                    if (c == ')')
                    {
                        count++;
                    }
                    else if (c == '(')
                    {
                        count--;
                    }
                    else if (count == 0 && (c == '*' || c == '/'))
                    {
                        opPos = i;
                        break;
                    }
                }
            }

            if (opPos == -1)
            {
                if (int.TryParse(expr, out int num))
                {
                    return num.ToString();
                }
                else
                {
                    return "Crazy input!";
                }
            }

            string leftExpr = expr.Substring(0, opPos);
            string rightExpr = expr.Substring(opPos + 1);
            if (leftExpr.Length == 0 || rightExpr.Length == 0)
            {
                return "Crazy input!";
            }

            string leftResult = this.Evaluate(leftExpr);
            if (leftResult == "Crazy input!")
            {
                return "Crazy input!";
            }

            string rightResult = this.Evaluate(rightExpr);
            if (rightResult == "Crazy input!")
            {
                return "Crazy input!";
            }

            bool okL = int.TryParse(leftResult, out int leftNum);
            bool okR = int.TryParse(rightResult, out int rightNum);
            if (!okL || !okR)
            {
                return "Crazy input!";
            }

            char op = expr[opPos];
            int result = 0;
            if (op == '+')
            {
                result = leftNum + rightNum;
            }
            else if (op == '-')
            {
                result = leftNum - rightNum;
            }
            else if (op == '*')
            {
                result = leftNum * rightNum;
            }
            else if (op == '/')
            {
                if (rightNum == 0)
                {
                    return "Crazy input!";
                }

                result = leftNum / rightNum;
            }
            else
            {
                return "Crazy input!";
            }

            return result.ToString();
        }
    }
}
