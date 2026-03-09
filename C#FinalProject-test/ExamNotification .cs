using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_FinalProject_test
{
    internal delegate void ExamStartingHandler(object sender, ExamNotification e);

    internal class ExamNotification : EventArgs
    {
        public string SubjectName { get; set; }
        public ExamMode Mode { get; set; }
        public DateTime TimeStamp { get; set; }

        public ExamNotification(string subjectName, ExamMode mode)
        {
            SubjectName = subjectName;
            Mode = mode;
            TimeStamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{TimeStamp:HH:mm:ss}] Exam for '{SubjectName}' changed to mode: {Mode}";
        }
    }
}
