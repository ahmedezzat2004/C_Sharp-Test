using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Day06_test
{
    internal struct Employee
    {
        private int EmpId;
        private string Name;

        private int Salary;

        public Employee(int _EmpId, string _Name, int _Salary)
        {
            EmpId = _EmpId;
            Name = _Name;
            Salary = _Salary;
        }

        public int Emp_Id
        {
            get { return EmpId; }
            set { EmpId = value; }
        }

        public string Emp_Name
        {
            get { return Name; }
            set { Name = value; }
        }

        public int Emp_Salary
        {
            get { return Salary; }
            set { Salary = value; }
        }

        public override string ToString()
        {
           return $"ID: {EmpId}, Name: {Name}, Salary: {Salary}";
        }

        /*
         * Question: Why is encapsulation critical in software design?
         * Answer:
         * Encapsulation is important because it provides a powerful way to store and hide and manipulate data 
         * while giving you increased control over it
         * Encapsulation is useful when dealing with secure data or methods because
         * it can restrict which functions or users have access to certain information
         */
    }
}
