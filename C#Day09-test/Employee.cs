using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Day09_test
{
    internal class Employee : Person
    {
        int _empId;
        double _salary;
        Department _dept;
        
        public int EmpId { get { return _empId; } set { _empId = value; } }
        public double Salary { get { return _salary; } set { _salary = value < 5000 ? 5000 : value; } }
        public Department Dept { get { return _dept; } set { _dept = value; } }
        
        public Employee(int id, string name, double salary, string dept)
        {
            _empId = id;
            Name = name;
            Salary = salary;
            _dept = new Department { DeptId = 0, DeptName = dept };
        }
        public Employee() { }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Employee)) return false;
            Employee other = (Employee)obj;
            return _empId == other._empId && Name == other.Name;
        }
        public override int GetHashCode() { return _empId.GetHashCode(); }

        public override string ToString()
        {
            return $"EmpId : {_empId} | Name : {Name} | Salary : {Salary} | Dept : {_dept?.DeptName}";
        }
    }
}
