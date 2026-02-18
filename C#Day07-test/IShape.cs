using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day07_test
{
    internal interface IShape {
        
        double Area { get; }
        void Draw();
        public void PrintDetails()
        {
            Console.WriteLine("This is a shape with an area of: " + Area);
        }
    }
}
