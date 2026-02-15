using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day06_test
{
    internal class TypeA
    {
        private int F;
        internal int G;
        public int H;

        public TypeA(int _F, int _G, int _H)
        {
            F = _F;
            G = _G;
            H = _H;
        }

        public override string ToString()
        {
            return $"F: {F}, G: {G}, H: {H}";
        }

        /*
         * Question: How do access modifiers impact the scope and visibility of a class member? 
         * Answer:
         * 1-public: accessible Anywhere 
         * 2-protected: accessible from within the class itself and any classes that inherit from it
         * 3-internal: accessible only within the same project
         * 4-private: accessible only within the class itself
         * 5-protected internal: accessible from within the same project and from any classes that inherit from it
         * 6-private protected: accessible from within the same class and from any classes that inherit from it
         *   but only if they are in the same project
         */
    }
}
