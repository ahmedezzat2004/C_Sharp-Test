using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day07_test
{
    abstract class Shape {
        public virtual void Draw2()
        {
            Console.WriteLine("Drawing Shape");
        }

        public abstract double CalculateArea();
    }
}
