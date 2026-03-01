using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day09_test
{
    internal class Person
    {
        string _name;
        int _age;
        string _department;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public override string ToString()
        {
            return $"Name : {_name} | Age : {_age} | Department : {_department}";
        }
    }
}
