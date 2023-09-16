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
            List<char> vec = new List<char>();

            foreach (char c in charArray)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    if (c == '{') vec.Add('}');
                    else if (c == '[') vec.Add(']');
                    else vec.Add(')');
                }
                else
                {
                    if (vec[vec.Count - 1] != c)
                    {
                        return false;
                    }
                    else
                    {
                        vec.RemoveAt(vec.Count - 1);
                    }
                }
            }
            return true;
        }
    }
}
