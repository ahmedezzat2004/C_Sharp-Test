using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day07_test
{
    internal class Rectangle : Shape , IShape {

        public int Height;
        public int Width;
        
        public Rectangle(int _Height, int _Width)
        {
            Height = _Height;
            Width = _Width;
        }

        public double Area
        {
            get { return Width * Height;}
        }

        public void Draw()
        {
            Console.WriteLine("Draw the Rectangle that it is width : " + Width + " and it is height : " + Height);
        }

        public override void Draw2()
        {
            Console.WriteLine("Drawing a Rectangle");
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
}
