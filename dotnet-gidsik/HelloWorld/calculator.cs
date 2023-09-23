using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Calculator{
    public static string Dijkstra(string s)
    {
        if (s.Length < 2) throw new ArgumentException("Error");
        int quotes = 0;
        char prev = ' ';
        string rigth_sights = "1234567890()-+/*";
        foreach (char it in s)
        {
            foreach (char it_ in rigth_sights)
            {
                if (it != it_) throw new ArgumentException("Error");
            }

            if(prev == '-' && char.IsDigit(it)) throw new ArgumentException("Error");

            if (it == '(') quotes++;
            else if (it == ')')
            {
                quotes--;
                if (quotes < 0) throw new ArgumentException("Error");
            }
            prev = it;
        }

        string the_return = "";
        Stack<char> stack = new Stack<char>();

        foreach (char it in s)
        {
            if (Char.IsDigit(it))
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

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
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
                        stack.Push(b / a);
                        break;
                    default:
                        throw new ArgumentException("Invalid operator");
                }
            }
        }

        return stack.Pop();
    }
}
