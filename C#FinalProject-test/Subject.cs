using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_FinalProject_test
{
    internal class Subject : ICloneable, IComparable<Subject>
    {
        int _subjectId;
        string _subjectName;
        string _subjectCode;

        public int SubjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }
        public string SubjectName
        {
            get { return _subjectName; }
            set { _subjectName = value; }
        }
        public string SubjectCode
        {
            get { return _subjectCode; }
            set { _subjectCode = value; }
        }

        public Subject() : this(0, "Unknown", "N/A") { }

        public Subject(int id, string name, string code)
        {
            _subjectId = id;
            _subjectName = name;
            _subjectCode = code;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Subject)) return false;
            Subject other = (Subject)obj;
            return _subjectId == other._subjectId && _subjectCode == other._subjectCode;
        }
        public override int GetHashCode()
        {
            return _subjectId.GetHashCode() ^ (_subjectCode?.GetHashCode() ?? 0);
        }
        public override string ToString()
        {
            return $"Subject: [{_subjectCode}] {_subjectName}";
        }

        public object Clone()
        {
            return new Subject(_subjectId, _subjectName, _subjectCode);
        }

        public int CompareTo(Subject other)
        {
            if (other == null) return 1;
            return string.Compare(_subjectName, other._subjectName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
