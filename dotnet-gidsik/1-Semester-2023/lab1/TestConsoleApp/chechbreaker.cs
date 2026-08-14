using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{

    public class chechbreaker
    {
        public static bool Check(string tempt)
        {
            char[] charArray = tempt.ToCharArray();
            Stack<char> vec = new Stack<char>();

            foreach (char c in charArray)
            {
                if (c == ' ') continue;
                if (c == '{' || c == '[' || c == '(')
                {
                    if (c == '{') vec.Push('}');
                    else if (c == '[') vec.Push(']');
                    else vec.Push(')');
                }
                else
                {
                    if (vec.Count() == 0) return false;

                    if (vec.Peek() != c) return false;
                    else vec.Pop();
                }
            }
            return vec.Count == 0 ? true : false;
        }
    }
}
