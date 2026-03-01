using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Day09_test
{
    internal class Child : Parent
    {
        public string Name { get; set; }
        public sealed override double Salary { get; set; }

        public void DisplaySalary()
        {
            Console.WriteLine($"Employee : {Name} , Salary : {Salary}");
        }
    }
}
