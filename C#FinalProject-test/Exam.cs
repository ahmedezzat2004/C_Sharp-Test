using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_FinalProject_test
{
    internal enum ExamMode
    {
        Queued = 0,
        Starting = 1,
        Finished = 2
    }

    internal abstract class Exam : ICloneable, IComparable<Exam>
    {
        int _examId;
        TimeSpan _duration;
        int _numberOfQuestions;
        ExamMode _mode;
        Subject _subject;
        QuestionList _questions;

        Dictionary<int, Answer> _answerKey;

        public event ExamStartingHandler ExamStarting;

        public int ExamId
        {
            get { return _examId; }
            set { _examId = value; }
        }
        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public int NumberOfQuestions
        {
            get { return _numberOfQuestions; }
            set { _numberOfQuestions = value < 0 ? 0 : value; }
        }
        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public QuestionList Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
        public Dictionary<int, Answer> AnswerKey
        {
            get { return _answerKey; }
            set { _answerKey = value; }
        }
        
        public ExamMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                if (_mode == ExamMode.Starting)
                    OnExamStarting();
            }
        }
        
        protected Exam() : this(0, TimeSpan.Zero, null) { }

        protected Exam(int id, TimeSpan duration, Subject subject)
        {
            _examId = id;
            _duration = duration;
            _subject = subject;
            _mode = ExamMode.Queued;
            _questions = new QuestionList($"Exam_{id}_Questions.txt");
            _answerKey = new Dictionary<int, Answer>();
        }
        
        protected virtual void OnExamStarting()
        {
            ExamNotification args = new ExamNotification(_subject?.SubjectName ?? "Unknown", _mode);
            Console.WriteLine($"  [EVENT] {args}");
            ExamStarting?.Invoke(this, args);
        }
        
        public abstract void ShowExam();

        public void BuildAnswerKey()
        {
            _answerKey.Clear();
            foreach (Question q in _questions)
            {
                Answer correct = q.Answers?.GetCorrectAnswer();
                if (correct != null)
                    _answerKey[q.QuestionId] = correct;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Exam)) return false;
            Exam other = (Exam)obj;
            return _examId == other._examId;
        }
        public override int GetHashCode() { return _examId.GetHashCode(); }

        public override string ToString()
        {
            return $"Exam [{_examId}] | Subject: {_subject?.SubjectName} | Duration: {_duration:hh\\:mm} | Mode: {_mode} | Qs: {_questions?.Count}";
        }

        public abstract object Clone();

        public int CompareTo(Exam other)
        {
            if (other == null) return 1;
            return _duration.CompareTo(other._duration);
        }
    }

    internal class PracticeExam : Exam
    {
        public PracticeExam() : base() { }

        public PracticeExam(int id, TimeSpan duration, Subject subject)
            : base(id, duration, subject) { }

        public override void ShowExam()
        {
            Console.WriteLine($"  PRACTICE EXAM  –  {Subject?.SubjectName}");
            Console.WriteLine($"  Duration: {Duration:hh\\:mm} hrs   |   Questions: {Questions.Count}");

            foreach (Question q in Questions)
                q.DisplayWithAnswer();

            Console.WriteLine("  End of Practice Exam");
            Mode = ExamMode.Finished;
        }

        public override object Clone()
        {
            PracticeExam copy = new PracticeExam(ExamId, Duration, (Subject)Subject?.Clone());
            foreach (Question q in Questions)
                copy.Questions.Add((Question)q.Clone());
            copy.Mode = Mode;
            return copy;
        }
    }

    internal class FinalExam : Exam
    {
        public FinalExam() : base() { }

        public FinalExam(int id, TimeSpan duration, Subject subject)
            : base(id, duration, subject) { }

        public override void ShowExam()
        {
            Console.WriteLine($"  FINAL EXAM  –  {Subject?.SubjectName}");
            Console.WriteLine($"  Duration: {Duration:hh\\:mm} hrs   |   Questions: {Questions.Count}");

            foreach (Question q in Questions)
                q.Display();

            Console.WriteLine("  End of Final Exam – Good Luck!");
            Mode = ExamMode.Finished;
        }

        public override object Clone()
        {
            FinalExam copy = new FinalExam(ExamId, Duration, (Subject)Subject?.Clone());
            foreach (Question q in Questions)
                copy.Questions.Add((Question)q.Clone());
            copy.Mode = Mode;
            return copy;
        }
    }
}
