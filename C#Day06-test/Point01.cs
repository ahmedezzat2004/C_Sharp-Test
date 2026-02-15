using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day06_test
{
     
    internal struct Point01
    {
        public int X;
        public int Y;

        //  i get an error because struct cannot have a parameterless constructor in C# 9.0 so i commented it 
        /* 
         public Point01() { 
             X = 0;
             Y = 0;
         }
        */
        public Point01(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        /*
         * Question: Why can't a struct inherit from another struct or class in C#?
         * Answer:
         * because structs should be immutable allowing them to be inherited from another struct or class
         * would introduce complexity and potential issues with memory management
         */


    }
}