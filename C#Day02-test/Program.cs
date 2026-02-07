using System;

namespace C_Day02_test
{
    public class Student
    {
        public string Name;
    }

    internal class Program
    {

        // Question: What is the shortcut to comment and uncomment a selected block of code in Visual Studio?
        //answer:
        /*
        ctrl + k -c : to comment

        ctrl + k -u : to uncomment
        */

        // single line comment

        /*
        multi line comment
        */

        static void Main(string[] args)
        {
            #region problem01
            //Problem: Add both single - line and multi-line comments in the following code segment explaining its purpose:
            int x = 10;
            //create a new varible x and assign the value 10 to it
            int y = 20;
            // create a new varible y and assign the value 20 to it
            int sum = x + y;
            // create a new varible sum to calculate the sum of x and y  
            Console.WriteLine(sum);
            /*
                here i gave the program an order to print the value stored in sum 
                which is x + y 
                and the output well be 30  
             */
            #endregion

            #region problem02
            // Problem: Identify and fix the errors in this code snippet: 
            // 1- int x = "10";
            // we can not use the "" when creating an int variable the corriction as follow:
            int X = 10;
            // 2- console.WriteLine(x + y);
            /*
             * y is not intialised we should create it 
             * since the c# is key sisiteve then console is writing with capital C as follow:
            */
            int Y = 10;
            Console.WriteLine(X + Y);
            #endregion

            #region problem03
            /* Problem: Declare variables using proper naming conventions to store:
                    Your full name.
                    Your age. 
                    Your monthly salary.
                    Whether you are a student.
              */

            string fullName;
            int age;
            decimal monthlySalary;
            bool student;
            #endregion

            #region problem04

            // Problem: Write a program to demonstrate that changing the value of a reference type affects all references pointing to that object.

            // using class Student in the begining of the code 
            Student studentA = new Student();
            studentA.Name = "Ahmed";

            Student studentB = studentA;

            Console.WriteLine("before the change : StudentA = " + studentA.Name + " and studentB = " + studentB.Name);

            studentB.Name = "ibrahim";

            Console.WriteLine("After the change : student A = " + studentA.Name + " and studentB = " + studentB.Name);
            #endregion

            #region problem05
            /*
                Problem: Create a program that calculates the following using variables x = 15 and y = 4: 
                 Sum
                 Difference
                 Product
                 Division result
                 Remainder
                */
            // i will use deffirent variable u , v insted of x ,y :
            int u = 15;
            int v = 4;
            // sum 
            int Sum = u + v;
            Console.WriteLine(Sum);
            //Difference
            int dif = u - v;
            Console.WriteLine(dif);
            //product
            int pro = u * v;
            Console.WriteLine(pro);
            //Division
            double div = u / v;
            Console.WriteLine(div);
            // remainder
            int rem = u % v;
            Console.WriteLine(rem);

            #endregion

            #region problem06
            // Problem: Write a program that checks if a given number is both:  Greater than 10 and Even.  
            Console.Write("Enter a number: ");

            int S = Convert.ToInt32(Console.ReadLine()); ;

            if (S > 10 && S % 2 == 0)
            {
                Console.WriteLine("valid input");
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            #endregion

            #region problem07
            /*
                Problem: Implement a program that takes a double input from the user and casts it to an int. 
                Use both implicit and explicit casting, then print the results.
                */

            double D = 10.7;

            // EXPLICIT CASTING
            int I = (int)D;

            // IMPLICIT CASTING
            double implicitD = I;

            Console.WriteLine("Original Double: " + D);
            Console.WriteLine("Explicit Int: " + I);
            Console.WriteLine("Implicit Double: " + implicitD);

            #endregion

            #region problem08
            //Problem: Write a program that demonstrates the difference between prefix and postfix increment operators using a variable x.
            int z = 10;
            //Postfix Example:
            Console.WriteLine(z++);
            // will print 10
            Console.WriteLine(z);
            // will print 11
            //Prefix Example:
            Console.WriteLine(++z);
            // will print 12
            Console.WriteLine(z);
            // will print 12 
            #endregion



        }
    }
}
