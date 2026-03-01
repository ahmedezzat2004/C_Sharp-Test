using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day09_test
{
    internal class Department
    {
        int _deptId;
        string _deptName;

        public int DeptId 
        {
            get { return _deptId; } 
            set { _deptId = value; } 
        }
        public string DeptName 
        { 
            get { return _deptName; } 
            set { _deptName = value; } 
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Department)) return false;
            Department other = (Department)obj;
            return _deptId == other._deptId && _deptName == other._deptName;
        }
        public override int GetHashCode() { return _deptId.GetHashCode(); }

        public override string ToString()
        {
            return $"Name: {_deptName} , ID: {_deptId} ";
        }
    }
}
