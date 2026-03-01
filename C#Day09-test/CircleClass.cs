using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day09_test
{
    internal class CircleClass
    {
        public double Radius { get; set; }
        public string Color { get; set; }

        // == on a class → reference compare by default  (no overload here on purpose)
        // override Equals → content compare
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CircleClass)) return false;
            CircleClass other = (CircleClass)obj;
            return Radius == other.Radius && Color == other.Color;
        }
        public override int GetHashCode()
        {
            return Radius.GetHashCode() ^ Color.GetHashCode();
        }
    }
}
