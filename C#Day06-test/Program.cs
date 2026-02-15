using System;
using System.Drawing;

namespace C_Day06_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //part01

            #region Problem02
            TypeA a = new TypeA(1, 2, 3);
            String S021 = a.ToString();
            Console.WriteLine(S021); 
            #endregion

            #region Problem03
            Employee emp = new Employee(7, "Ali", 7000);

            Console.WriteLine("your Employee information:");
            String S031 = emp.ToString();
            Console.WriteLine(S031);

            emp.Emp_Name = "Ahmed";
            emp.Emp_Salary = 10000;
            Console.WriteLine("your Employee information after updating:");
            String S032 = emp.ToString();
            Console.WriteLine(S032);

            #endregion

            #region Problem04
            Point02 p1 = new Point02(10);
            String S41 = p1.ToString();
            Point02 p2 = new Point02(10, 20);
            String S42 = p2.ToString();

            Console.WriteLine(S41);
            Console.WriteLine(S42);
            #endregion

            #region Problem05
            Point02 p3 = new Point02(10, 15);
            Point02 p4 = new Point02(20, 40);
            Point02 p5 = new Point02(1, 5);
            String S51 = p3.ToString();
            Console.WriteLine(S51);
            String S52 = p4.ToString();
            Console.WriteLine(S52);
            String S53 = p5.ToString();
            Console.WriteLine(S53);
            #endregion

            #region Problem06
            // using the two methods below EditPoint and EditEmployee

            Point01 p10 = new Point01(5, 5);

            Employee02 emp02 = new Employee02("Ahmed");

            EditPoint(p10);
            EditEmployee(emp02);
            Console.WriteLine(p10.ToString());
            Console.WriteLine(emp02.Name);

            /*
             * Question: How does memory allocation differ for structs and classes in C#? 
             * Answer:
             * Structs:
             *     are value types Stored on the Stack Memory is allocated and deallocated instantly based on scope
             * Classes:
             *     are reference types Stored on the Heap Memory is managed by the Garbage Collector
             *     allowing objects to live longer than the method that created them
             */
            #endregion


            //part02

            #region Part02

            /*
             * Q1: What is copy constructor? 
             * Answer:
             * A constructor that creates an object by copying variables from another object or that
             * copies the data of one object into another object is termed as the Copy Constructor
             * It is a parameterized constructor that contains a parameter of the same class type
             * The main use of copy constructor is to initialize a new instance to the values of an existing instance
             * "ref: GeeksforGeeks website"
             */

            /*
             * Q2: What is Indexer, when used, as business mention cases u have to utilize it? 
             * Answer:
             * Indexer is a highly specialized property which allows instances of a class (or struct)
             * to be indexed just like an array (properties can be static but indexers cannot).
             * Why to use indexers:
             *  1- instead of a new data structure, the class itself is a data structure
             *  2- simplified syntax - syntactic sugar
             * When to use:
             *  1- if your class needs array of its instances 
             *  2-if your class represents array of values directly related to your class 
             *  "ref: stackoverflow website"
             */

            /*
             * Q3: Summarize keywords we have learnt last lecture
             * Answer:
             * 1- Boxing and Unboxing
             *      Boxing: Converting a Value Type (stack) to a Reference Type (heap)
             *      Unboxing: Converting the Reference Type back to a Value Type
             * 2- Exceptions
             * Purpose: Handling runtime errors without crashing the application.
             * Mechanism:
             *      try: Protects code that might fail.
             *      catch: Handles specific errors.
             *      finally: Executes cleanup code regardless of success or failure.
             * 3- Nullability
             * Purpose: Safely handling missing data (null).
             * Nullable Types (?): Allows value types (int?) and reference types to be null.
             * Safety: Operators like ?? and ?. prevent NullReferenceException.
             * 4- Structs
             * is a value type that can contain data and methods, but cannot inherit from other structs or classes.
             */

            #endregion
        }

        static void EditPoint(Point01 pt)
        {
            pt.X = 1;
            pt.Y = 1;
        }

        static void EditEmployee(Employee02 e)
        {
            e.Name = "Ezzat";
        }
    }
}
