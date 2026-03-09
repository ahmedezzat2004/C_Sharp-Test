using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_FinalProject_test
{
    internal class Answer : ICloneable
    {
        int _answerId;
        string _body;
        bool _isCorrect;

        public int AnswerId
        {
            get { return _answerId; }
            set { _answerId = value; }
        }
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }

        public Answer() : this(0, "N/A", false) { }

        public Answer(int id, string body, bool isCorrect)
        {
            _answerId = id;
            _body = body;
            _isCorrect = isCorrect;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Answer)) return false;
            Answer other = (Answer)obj;
            return _answerId == other._answerId && _body == other._body;
        }
        public override int GetHashCode() { return _answerId.GetHashCode(); }

        public override string ToString()
        {
            return $"({_answerId}) {_body}";
        }

        public object Clone()
        {
            return new Answer(_answerId, _body, _isCorrect);
        }
    }

    internal class AnswerList : List<Answer>, ICloneable
    {
        public Answer GetCorrectAnswer()
        {
            return this.Find(a => a.IsCorrect);
        }

        public List<Answer> GetAllCorrectAnswers()
        {
            return this.FindAll(a => a.IsCorrect);
        }

        public object Clone()
        {
            AnswerList copy = new AnswerList();
            foreach (Answer a in this)
                copy.Add((Answer)a.Clone());
            return copy;
        }
    }
}
