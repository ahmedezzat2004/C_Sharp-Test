using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_FinalProject_test
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        int _questionId;
        string _header;
        string _body;
        int _marks;
        AnswerList _answers;

        public int QuestionId
        {
            get { return _questionId; }
            set { _questionId = value; }
        }
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        public int Marks
        {
            get { return _marks; }
            set { _marks = value < 1 ? 1 : value; }
        }
        public AnswerList Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        protected Question() : this(0, "N/A", "N/A", 1) { }

        protected Question(int id, string header, string body, int marks)
        {
            _questionId = id;
            _header = header;
            _body = body;
            _marks = marks < 1 ? 1 : marks;
            _answers = new AnswerList();
        }

        public abstract void Display();

        public virtual void DisplayWithAnswer()
        {
            Display();
            Answer correct = _answers?.GetCorrectAnswer();
            if (correct != null)
                Console.WriteLine($"  *** Correct Answer: {correct.Body} ***");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Question)) return false;
            Question other = (Question)obj;
            return _questionId == other._questionId && _body == other._body;
        }
        public override int GetHashCode() { return _questionId.GetHashCode(); }

        public override string ToString()
        {
            return $"[Q{_questionId}] ({GetType().Name}) [{_marks} pts] {_header} : {_body}";
        }

        public abstract object Clone();

        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            return _marks.CompareTo(other._marks);
        }
    }

    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion() : base() { }

        public TrueFalseQuestion(int id, string header, string body, int marks, bool correctAnswer)
            : base(id, header, body, marks)
        {
            Answers.Add(new Answer(1, "True", correctAnswer == true));
            Answers.Add(new Answer(2, "False", correctAnswer == false));
        }

        public override void Display()
        {
            Console.WriteLine($"\n  Q{QuestionId} [True/False – {Marks} pts] {Header}");
            Console.WriteLine($"  {Body}");
            Console.WriteLine("    (1) True");
            Console.WriteLine("    (2) False");
        }

        public override object Clone()
        {
            TrueFalseQuestion copy = new TrueFalseQuestion();
            copy.QuestionId = QuestionId;
            copy.Header = Header;
            copy.Body = Body;
            copy.Marks = Marks;
            copy.Answers = (AnswerList)Answers.Clone();
            return copy;
        }
    }

    internal class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion() : base() { }

        public ChooseOneQuestion(int id, string header, string body, int marks, AnswerList answers)
            : base(id, header, body, marks)
        {
            Answers = answers ?? new AnswerList();
        }

        public override void Display()
        {
            Console.WriteLine($"\n  Q{QuestionId} [Choose One – {Marks} pts] {Header}");
            Console.WriteLine($"  {Body}");
            foreach (Answer a in Answers)
                Console.WriteLine($"    {a}");
        }

        public override object Clone()
        {
            ChooseOneQuestion copy = new ChooseOneQuestion();
            copy.QuestionId = QuestionId;
            copy.Header = Header;
            copy.Body = Body;
            copy.Marks = Marks;
            copy.Answers = (AnswerList)Answers.Clone();
            return copy;
        }
    }

    internal class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion() : base() { }

        public ChooseAllQuestion(int id, string header, string body, int marks, AnswerList answers)
            : base(id, header, body, marks)
        {
            Answers = answers ?? new AnswerList();
        }

        public override void Display()
        {
            Console.WriteLine($"\n  Q{QuestionId} [Choose All That Apply – {Marks} pts] {Header}");
            Console.WriteLine($"  {Body}");
            foreach (Answer a in Answers)
                Console.WriteLine($"    {a}");
        }

        public override void DisplayWithAnswer()
        {
            Display();
            List<Answer> correct = Answers?.GetAllCorrectAnswers();
            if (correct != null && correct.Count > 0)
            {
                Console.Write("  *** Correct Answers: ");
                Console.WriteLine(string.Join(", ", correct.Select(a => a.Body)) + " ***");
            }
        }

        public override object Clone()
        {
            ChooseAllQuestion copy = new ChooseAllQuestion();
            copy.QuestionId = QuestionId;
            copy.Header = Header;
            copy.Body = Body;
            copy.Marks = Marks;
            copy.Answers = (AnswerList)Answers.Clone();
            return copy;
        }
    }

    internal class QuestionList : List<Question>
    {
        string _logFilePath;

        public string LogFilePath
        {
            get { return _logFilePath; }
        }

        public QuestionList() : this($"QuestionLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt") { }

        public QuestionList(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public new void Add(Question question)
        {
            base.Add(question);
            LogQuestion(question);
        }

        private void LogQuestion(Question question)
        {
            try
            {
                using (TextWriter writer = new StreamWriter(_logFilePath, append: true, encoding: Encoding.UTF8))
                {
                    writer.WriteLine($"--------------------------------------------");
                    writer.WriteLine($"Logged At  : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine($"Question   : {question}");
                    writer.WriteLine($"Type       : {question.GetType().Name}");
                    writer.WriteLine($"Answers    :");
                    if (question.Answers != null)
                        foreach (Answer a in question.Answers)
                            writer.WriteLine($"             {a} {(a.IsCorrect ? "[CORRECT]" : "")}");
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  [Warning] Could not log question to file: {ex.Message}");
            }
        }

        public void DisplayAll()
        {
            foreach (Question q in this)
                q.Display();
        }
    }
}
