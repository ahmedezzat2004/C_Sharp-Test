using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day07_test
{
    internal class Child : Parent {

        public int Z;
        public Child(int _X, int _Y, int _Z) : base(_X, _Y)
        {
            Z = _Z;
        }

        //note: uncomment the method you want to use and comment the other one to see the difference

        //public override int Product()
        //{
        //    return X * Y * Z;
        //}
        public override int Product()
        {
            return X * Y * Z;
        }

        public override string ToString()
        {
            return $"X : ({X}, {Y}, {Z})";
        }
    }
}
