using System;
using System.Text;

namespace C_Day03_test
{
    internal class Program
    {
        public class P4
        {
            public int number;
        }

        static void Main(string[] args)
        {
            #region problem01
            Console.WriteLine("enter a value : ");

            string input = Console.ReadLine();
            try
            {
                int x = int.Parse(input);
                Console.WriteLine(x);
                int y = Convert.ToInt32(input);
                Console.WriteLine(y);
                Console.WriteLine("success");
            }
            catch (Exception z)
            {
                Console.WriteLine("faild, " + z.Message);
            }

            /*
            question: what is the difference between int.parse and convert.toint32 when handling null inputs?
            answer:
             both int.parse and convert.toint32 are used to turn strings into integers
             but there is a deffrence when come to a null value input :
             for int.parse it will throws an argumentnullexception and the system will crash
             on the otherhand convert.toint32 the output will be 0 and the sustem will not crash
             */
            #endregion

            #region problem02
            Console.WriteLine("enter a value: ");
            string input3 = Console.ReadLine();

            if (int.TryParse(input3, out int m))
            {
                Console.WriteLine("valid value: " + m);
            }
            else
            {
                Console.WriteLine("this value not valid");
            }
            /*
            question: why is tryparse recommended over parse in user-facing applications? 
            answer:
            as we say in problem01 if the value is not an integer the system will crash and 
            will throw an exiption massege this where we use try parse 
            it just rutern a true (if it is a valid ) or false (if it is not valid)
            so when using tryparse we reduce the probility for the system to crash
             */
            #endregion

            #region problem03
            object o;

            o = 7;
            Console.WriteLine(o.GetHashCode());

            o = "ahmed";
            Console.WriteLine(o.GetHashCode());

            /*
            question: explain the real purpose of the gethashcode() method?
            answer:
            the gethashcode method provides a hash code for algorithms that need quick checks of object equality
            a hash code is a numeric value that is used to insert and identify an object in a hash-based collection
            "it is like the finger print for this object"
             */
            #endregion

            #region Problem04
            // using p4 class 
            P4 S = new P4();
            S.number = 10;
            P4 S2 = S;
            S2.number = 20;
            Console.WriteLine(S.number);
            /*
            Question: What is the significance of reference equality in .NET?
            Answer:
            reference equality is important for two main reasons: efficiency and consistency
            Efficiency: Instead of copying a massive amount of data .NET just copies the address of that data
            consistency: Since multiple variables point to the same object 
            changing the data in one place updates it everywhere at once
             */
            #endregion

            #region Problem05
            string str = "hello";
            Console.WriteLine("Before mod: " + str.GetHashCode());

            str = str + " hi willy";
            Console.WriteLine("After mod: " + str.GetHashCode());
            /*
            Question: Why string is immutable in C# ?
            Answer:
            in the previous code C# did not edit the same location of str instead it just created anew location why :
            Designers of .Net decided to implement immutable text strings
            They have multiple reasons for this architecture
            If programmers have multiple string variables with the same value then it will avoid allocating memory for the same string value multiple times
            It will allocate memory to a string once and all the variables will point to the same memory block
            "ref c# corner website "
             */
            #endregion

            #region Problem06
            StringBuilder sb = new StringBuilder("Hello, ");
            Console.WriteLine("Before mod: " + sb.GetHashCode());

            sb.Append("Hi weilly");
            Console.WriteLine("After mod: " + sb.GetHashCode());

            /*
            Question: How does StringBuilder address the inefficiencies of string concatenation?
            Answer in three steps :
            1- muttable :
            where Standard strings are immutable Every time you add a letter .NET delete the old string and builds a new one 
            StringBuilder stays alive and just edits its own internal memory
            2- using buffer:
            Instead of taking up exactly enough space for your text StringBuilder grabs a large memory space than it needs.
            You can keep adding text into that empty space without asking Windows for more memory
            3- Less Work for the "Janitor"
            Because it isn't constantly creating and throwing away string objects
            the Garbage Collector doesn't have to work as hard. This keeps your app running smoothly
             */

            /*
            Question: Why is StringBuilder faster for large-scale string modifications?
            Answer:
            as we said the Strings are immutable and this will alot of memory space when we want to update our string this will slow the procces
            on the otherHand the StringBuilder and StringBuffer classes are implemented as a mutable sequence of characters 
            This means that as you append new Strings or characters onto a StringBuilder 
            it simply updates its internal array to reflect the changes you've made
            This means that new memory is only allocated when the string grows past the buffer already existing in a StringBuilder
            "ref : stackOverFlow website"
             */
            #endregion

            #region Problem07

            Console.WriteLine("enter a number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("enter a second number: ");
            int num2 = int.Parse(Console.ReadLine());

            int sum = num1 + num2;

            Console.WriteLine("Sum is " + num1 + " + " + num2 + " = " + sum);

            Console.WriteLine(string.Format("Sum is {0} + {1} = {2}", num1, num2, sum));

            Console.WriteLine($"Sum is {num1} + {num2} = {sum}");
            /*
            Question: Which string formatting method is most used and why?
            Answer:
            $ is the better choise and the common used, why :
            the + operator Creates many temporary string objects in the Heap memory which can be slow
            String.format and $ are better for memory optmization whoever the $ easier to read and write than string.format 
             */
            #endregion

            #region Problem08
            StringBuilder SB = new StringBuilder("Ahmed");
            SB.Append(" ,how are you ");
            Console.WriteLine("after Appending: " + SB);
            SB.Replace("Ahmed", "Ali");
            Console.WriteLine("after replacing: " + SB);
            SB.Insert(0, "Hi ");
            Console.WriteLine("after inserting: " + SB);
            SB.Remove(0, 2);
            Console.WriteLine("after deleting: " + SB);

            /*
            Question: Explain how StringBuilder is designed to handle frequent modifications compared to strings?
            Answer:
            we said in problem06 that 
            strings are immutable so we can not edit the existing string becuse c# will delete it and will creat a new one  this cost alot of memory 
            and StringBuilder class implemented as a mutable sequence of characters This means that as you append new Strings or characters onto a StringBuilder 
            it simply updates its internal array to reflect the changes you've made and this will not cost anew memory to be created 
            and this is becuse of the extra space that stringbuldier take it
             */
            #endregion

            #region Part02-Questions
            /*
                Q2- What’s Enum data type, when is it used? And name three common built_in enums used frequently?
                Answer:
                Enums are powerful data types in C# that allow you to define a set of named constants
                They are often used to represent a fixed number of possible values that a variable can take on.
                three common built_in enums used frequently:
                1- System.DayOfWeek : This is used whenever you need to handle dates and calendar logic
                Instead of remembering that 0 is Sunday, you can use the named constant.
                2- System.ConsoleColor : If you are writing console applications
                this enum defines the colors available for the background and foreground of the terminal text.
                3- System.Net.HttpStatusCode : This is widely used in web development and API integration to represent the status of an HTTP request.
                "ref : C# corner website "
                 */

            /*
            Q3- what are scenarios to use  string Vs StringBuilder?
            Answer:
            If a string is going to remain constant throughout the program
            then use the String class object because a String object is immutable 
            if there is a posipility to change the string or edit it use Stringbuilder
            If you don't want thread-safety than you can also go with StringBuilder class as it is not synchronized
            "ref : geeksforgeeks  website "
             */
            #endregion
        }
    }
}
