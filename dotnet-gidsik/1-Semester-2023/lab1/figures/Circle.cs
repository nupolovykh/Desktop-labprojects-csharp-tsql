using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figures
{
    public class Circle : IHaveArea
    {
        public int Radius { get; set; }
        public Circle(int radius)
        {
            Radius = radius;
        }

        public double get_space()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
