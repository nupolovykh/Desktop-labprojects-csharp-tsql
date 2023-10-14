using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

public static class Calculator{

    public static void Tests(string s){
        if (s.Length < 3) throw new ArgumentException("Error");

        HashSet<char> set = new HashSet<char>();
        string rigth_sights = "1234567890()-+/*";
        foreach(char it in rigth_sights) set.Add(it);

        char last = s[s.Length - 1];
        if(last == '*' || last == '/' || last == '-' || last == '+') throw new ArgumentException("Error");
        last = s[0];
        if(last == '*' || last == '/' || last == '-' || last == '+') throw new ArgumentException("Error");

        int quotes = 0, figures = 0;
        char prev = ' ';
        foreach (char it in s)
        {
            if(!set.Contains(it)) throw new ArgumentException("Error");

            if (it == '(') quotes++;
            else if (it == ')')
            {
                quotes--;
                if (prev == '*' || prev == '/' || prev == '-' || prev == '+') throw new ArgumentException("Error");
                if (quotes == 0)  figures = 0;
            }
            else if(it == '*' || it == '/' || it == '-' || it == '+') if(prev == '*' || prev == '/' || prev == '-' || prev == '+') throw new ArgumentException("Error");
            else if(quotes > 0 && char.IsDigit(it) && !char.IsDigit(prev)) figures++;
            else if(prev == '(' && (it == '*' || it == '/' || it == '-' || it == '+')) throw new ArgumentException("Error");
            prev = it;
        }
    }
    public static string Dijkstra(string s)
    {
        string the_return = "";
        Stack<char> stack = new Stack<char>();

        foreach (char it in s)
        {
            if (char.IsDigit(it))
            {
                the_return += it;
            }
            else
            {
                if (it == ')')
                {
                    the_return += ' ';
                    while (stack.Peek() != '(')
                    {
                        the_return += stack.Pop();
                        the_return += ' ';
                    }
                    stack.Pop();
                }
                else
                {
                    if ((it == '/' || it == '*') && stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/'))
                    {
                        while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/'))
                        {
                            the_return += stack.Pop();
                            the_return += ' ';
                        }
                    }
                    if ((it == '+' || it == '-') && stack.Count > 0 && stack.Peek() != '(')
                    {
                        if (it != '(' && the_return[the_return.Length - 1] != ' ')
                        {
                            the_return += ' ';
                        }
                        while (stack.Count > 0 && stack.Peek() != '(')
                        {
                            the_return += stack.Pop();
                            the_return += ' ';
                        }
                    }
                    if (it != '(' && the_return[the_return.Length - 1] != ' ')
                    {
                        the_return += ' ';
                    }
                    stack.Push(it);
                }
            }
        }

        if (the_return[the_return.Length - 1] != ' ') the_return += ' ';

        while (stack.Count > 0)
        {
            the_return += stack.Pop();
            the_return += ' ';
        }

        the_return = the_return.TrimEnd();
        return the_return;
    }

    public static double Decode(string s)
    {
        Stack<double> stack = new Stack<double>();
        string current_number = "";
        bool one_digit = true;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                one_digit = false;
                if (!string.IsNullOrEmpty(current_number))
                {
                    stack.Push(double.Parse(current_number));
                    current_number = "";
                    continue;
                }
                continue;
            }
            if (char.IsDigit(s[i])) 
            {
                current_number += s[i];
            }
            else
            {
                one_digit = false;
                if (s[i] == '-' && (i < s.Length - 1))
                {
                    if (s[i + 1] != ' ')
                    {
                        current_number += s[i];
                        continue;
                    }
                }
                double a = stack.Pop();
                double b = stack.Pop();
                
                switch (s[i])
                {
                    case '+':
                        stack.Push(b + a);
                        break;
                    case '-':
                        stack.Push(b - a);
                        break;
                    case '*':
                        stack.Push(b * a);
                        break;
                    case '/':
                        if(a == 0) throw new ArgumentException("Error");
                        stack.Push(b / a);
                        break;
                    default:
                        throw new ArgumentException("Error");
                }
            }
        }

        return one_digit ? double.Parse(current_number) : stack.Pop();
    }

    public static double CalculatorMethod(string expression)
    {
        return Decode(Dijkstra(expression));
    }
}
