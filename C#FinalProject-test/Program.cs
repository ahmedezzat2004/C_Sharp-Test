using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace C_FinalProject_test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Subject csharpSubject = new Subject(1, "C# Programming", "CS101");
            Subject mathSubject = new Subject(2, "Mathematics", "MATH201");

            Console.WriteLine($"Subjects created:");
            Console.WriteLine($"  {csharpSubject}");
            Console.WriteLine($"  {mathSubject}");

            Student s1 = new Student(1, "Ahmed", csharpSubject);
            Student s2 = new Student(2, "Sara", csharpSubject);
            Student s3 = new Student(3, "Kareem", csharpSubject);
            Student s4 = new Student(4, "Mona", mathSubject);

            Console.WriteLine($"\nStudents enrolled:");
            Console.WriteLine($"  {s1}");
            Console.WriteLine($"  {s2}");
            Console.WriteLine($"  {s3}");
            Console.WriteLine($"  {s4}");

            TrueFalseQuestion q1 = new TrueFalseQuestion(
                id: 1,
                header: "OOP Basics",
                body: "In C#, a class can inherit from multiple classes directly.",
                marks: 2,
                correctAnswer: false
            );

            AnswerList mcqAnswers1 = new AnswerList
            {
                new Answer(1, "int",    false),
                new Answer(2, "string", false),
                new Answer(3, "object", true),
                new Answer(4, "var",    false),
            };
            ChooseOneQuestion q2 = new ChooseOneQuestion(
                id: 2,
                header: "Type System",
                body: "Which type is the base of ALL types in C#?",
                marks: 3,
                answers: mcqAnswers1
            );

            AnswerList mcqAnswers2 = new AnswerList
            {
                new Answer(1, "Encapsulation",  true),
                new Answer(2, "Polymorphism",   true),
                new Answer(3, "Compilation",    false),
                new Answer(4, "Inheritance",    true),
            };
            ChooseAllQuestion q3 = new ChooseAllQuestion(
                id: 3,
                header: "OOP Pillars",
                body: "Which of the following are pillars of OOP? (Choose all that apply)",
                marks: 4,
                answers: mcqAnswers2
            );

            TrueFalseQuestion q4 = new TrueFalseQuestion(
                id: 4,
                header: "Generics",
                body: "Generics in C# only work with value types.",
                marks: 2,
                correctAnswer: false
            );

            PracticeExam practiceExam = new PracticeExam(
                id: 101,
                duration: new TimeSpan(1, 30, 0),
                subject: csharpSubject
            );

            practiceExam.ExamStarting += s1.OnExamStarting;
            practiceExam.ExamStarting += s2.OnExamStarting;
            practiceExam.ExamStarting += s3.OnExamStarting;

            practiceExam.Questions.Add(q1);
            practiceExam.Questions.Add(q2);
            practiceExam.Questions.Add(q3);
            practiceExam.Questions.Add(q4);
            practiceExam.BuildAnswerKey();

            TrueFalseQuestion mq1 = new TrueFalseQuestion(
                id: 1,
                header: "Algebra",
                body: "The square root of 144 is 12.",
                marks: 2,
                correctAnswer: true
            );

            AnswerList mathMcq = new AnswerList
            {
                new Answer(1, "3.14",  true),
                new Answer(2, "2.71",  false),
                new Answer(3, "1.41",  false),
                new Answer(4, "1.73",  false),
            };
            ChooseOneQuestion mq2 = new ChooseOneQuestion(
                id: 2,
                header: "Constants",
                body: "What is the approximate value of Pi (π)?",
                marks: 3,
                answers: mathMcq
            );

            FinalExam finalExam = new FinalExam(
                id: 202,
                duration: new TimeSpan(2, 0, 0),
                subject: mathSubject
            );

            finalExam.ExamStarting += s4.OnExamStarting;

            finalExam.Questions.Add(mq1);
            finalExam.Questions.Add(mq2);
            finalExam.BuildAnswerKey();

            Console.WriteLine($"Exams ready:");
            Console.WriteLine($"  {practiceExam}");
            Console.WriteLine($"  {finalExam}");

            Console.WriteLine("Setting Practice Exam to STARTING mode ");
            practiceExam.Mode = ExamMode.Starting;

            Console.WriteLine("Setting Final Exam to STARTING mode ");
            finalExam.Mode = ExamMode.Starting;

            Console.WriteLine("  Select Exam Type to Run:");
            Console.WriteLine("  1. Practice Exam (C# Programming)");
            Console.WriteLine("  2. Final Exam    (Mathematics)");
            Console.Write("  Enter your choice (1 or 2): ");

            string input = Console.ReadLine();
            Exam selectedExam = null;

            if (input == "1")
                selectedExam = practiceExam;
            else if (input == "2")
                selectedExam = finalExam;
            else
            {
                Console.WriteLine("  Invalid choice. Defaulting to Practice Exam.");
                selectedExam = practiceExam;
            }

            selectedExam.ShowExam();

            PracticeExam clonedExam = (PracticeExam)practiceExam.Clone();
            Console.WriteLine($"  Original : {practiceExam}");
            Console.WriteLine($"  Clone    : {clonedExam}");
            Console.WriteLine($"  Equals (same id) : {practiceExam.Equals(clonedExam)}");

            Console.WriteLine("Sorting exams by duration");
            List<Exam> examList = new List<Exam> { finalExam, practiceExam };
            examList.Sort();
            Console.WriteLine("Sorted by duration:");
            foreach (Exam e in examList)
                Console.WriteLine($"    {e}");

            Subject subjectClone = (Subject)csharpSubject.Clone();
            Console.WriteLine($"  Original : {csharpSubject}");
            Console.WriteLine($"  Clone    : {subjectClone}");
            Console.WriteLine($"  Equals   : {csharpSubject.Equals(subjectClone)}");

            Console.WriteLine($"    {practiceExam.Questions.LogFilePath}");
            Console.WriteLine($"    {finalExam.Questions.LogFilePath}");

            Console.WriteLine(" Program finished.");

        }
    }
}
