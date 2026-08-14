using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figures
{
    public class Rectangle : IHaveArea
    {
        public int Side_a { get; set; }
        public int Side_b { get; set; }
        public Rectangle(int side_a, int side_b)
        {
            Side_a = side_a;
            Side_b = side_b;
        }
        public double get_space()
        {
            return Side_a * Side_b;
        }
    }
}
