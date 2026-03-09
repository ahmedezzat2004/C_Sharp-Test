using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_FinalProject_test
{
    internal class Student : ICloneable, IComparable<Student>
    {
        int _studentId;
        string _name;
        Subject _subject;

        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public Student() : this(0, "Unknown", null) { }

        public Student(int id, string name, Subject subject)
        {
            _studentId = id;
            _name = name;
            _subject = subject;
        }

        public void OnExamStarting(object sender, ExamNotification e)
        {
            Console.WriteLine($"  [NOTIFICATION] Student '{_name}' notified --> Exam for '{e.SubjectName}' is now STARTING! Good luck!");
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Student)) return false;
            Student other = (Student)obj;
            return _studentId == other._studentId && _name == other._name;
        }
        public override int GetHashCode() { return _studentId.GetHashCode(); }

        public override string ToString()
        {
            return $"Student: [{_studentId}] {_name} | Subject: {_subject?.SubjectName ?? "N/A"}";
        }

        public object Clone()
        {
            return new Student(_studentId, _name, (Subject)_subject?.Clone());
        }

        public int CompareTo(Student other)
        {
            if (other == null) 
                return 1;
            return string.Compare(_name, other._name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
