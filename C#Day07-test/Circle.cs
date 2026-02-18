using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day07_test
{
    internal class Circle : IShape {

        public int Radius;

        public Circle(int r)
        {
            Radius = r;
        }

        public double Area
        {
            get { return 3.14 * Radius * Radius; }
        }

        public void Draw()
        {
            Console.WriteLine("Draw the Circle that it is radius: " + Radius);
        }
        public void PrintDetails()
        {
            Console.WriteLine("This is a shape with an area of: " + Area);
        }
    }
}
