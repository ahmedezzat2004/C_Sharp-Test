using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day09_test
{
    internal class Helper<T>
    {
        public static void Swap(ref T X, ref T Y)
        {
            T Temp = X;
            X = Y;
            Y = Temp;
        }

        public static int SearchArr(T[] Arr, T Value)
        {
            for (int i = 0; i < Arr?.Length; i++)
            {
                if (Value.Equals(Arr[i]))
                    return i;
            }
            return -1;
        }

        public static void ReplaceArray(T[] Arr, T OldVal, T NewVal)
        {
            for (int i = 0; i < Arr?.Length; i++)
            {
                if (OldVal.Equals(Arr[i]))
                    Arr[i] = NewVal;
            }
        }

        public static T Max<T>(T A, T B) where T : IComparable
        {
            return A.CompareTo(B) >= 0 ? A : B;
        }
    }
}
