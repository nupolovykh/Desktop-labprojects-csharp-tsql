using figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class ListArea
    {
        public static double CountListArea(List<IHaveArea> list)
        {
            double sum = 0;
            foreach(IHaveArea it in list)
            {
                sum += it.get_space();
            }
            return sum;
        }
    }
}
