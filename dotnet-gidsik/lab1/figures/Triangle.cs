using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figures
{
    public class Triangle : IHaveArea
    {
        public double Side_a { get; set; }
        public double Side_b { get; set; }
        public double Side_c { get; set; }

        public double SemiP { get; set; }

        public Triangle(double side_a, double side_b, double side_c)
        {
            Side_a = side_a;
            Side_b = side_b;
            Side_c = side_c;
            SemiP = (side_a + side_b + side_c) / 2;
        }

        public double get_space()
        {
            return Math.Sqrt(SemiP*(SemiP - Side_a)* (SemiP - Side_b)* (SemiP - Side_c));
        }
    }
}
