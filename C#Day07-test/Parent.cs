using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day07_test
{
    internal class Parent {

        public int X;
        public int Y;

        public Parent(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }

        public virtual int Product() {
            return X * Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
