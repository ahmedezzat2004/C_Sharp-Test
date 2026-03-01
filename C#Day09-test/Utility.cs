using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day09_test
{
    internal class Utility
    {
        public static double RectanglePerimeter(double length, double width)
        {
            return 2 * (length + width);
        }

        public static double CelsiusToFahrenheit(double c)
        {
            return (c * 9.0 / 5.0) + 32;
        }

        public static double FahrenheitToCelsius(double f)
        {
            return (f - 32) * 5.0 / 9.0;
        }
    }
}
