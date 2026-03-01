using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day09_test
{
    internal class GenericHelper
    {
        public static T[] ReverseArray<T>(T[] Arr)
        {
            T[] result = new T[Arr.Length];
            for (int i = 0; i < Arr.Length; i++)
                result[i] = Arr[Arr.Length - 1 - i];
            return result;
        }
        public static void SwapElements<T>(T[] Arr, int I, int J)
        {
            T Temp = Arr[I];
            Arr[I] = Arr[J];
            Arr[J] = Temp;
        }
        public static T FindMax<T>(T[] Arr) where T : IComparable
        {
            if (Arr == null || Arr.Length == 0)
                throw new Exception("Array is empty!");
            T Max = Arr[0];
            for (int i = 1; i < Arr.Length; i++)
                if (Arr[i].CompareTo(Max) > 0)
                    Max = Arr[i];
            return Max;
        }
    }
}
