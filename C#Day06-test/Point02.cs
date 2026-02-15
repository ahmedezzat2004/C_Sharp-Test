using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day06_test
{
    internal struct Point02{
        int X;
        int Y;

        public Point02(int _X) { 
            X = _X;
            Y = 0;
        }
        
        public Point02(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }

        #region Problem05
        // Problem05 : modified ToString method :
        public override string ToString()
        {
            return $"the Coordinates is: ({X}, {Y})";
        }

        /*
         * Question: How does overriding methods like ToString() improve code readability?
         * Answer:
         * by providing a custom implementation of the ToString() method
         * you can make it easier for developers to understand the purpose and behavior of your code
         */ 
        #endregion

        /*
         * Question: what is constructors in structs? 
         * Answer:
         * methods are called automatically used to initialize the fields of a struct when it is created
         */
    }
}
