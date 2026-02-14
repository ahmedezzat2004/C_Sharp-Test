using System;

namespace C_Day05_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // part01

            #region Problem01
            try
            {
                Console.WriteLine("Enter number :");
                int num11 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter another number :");
                int num12 = int.Parse(Console.ReadLine());
                int result = num11 / num12;
                Console.WriteLine("result: " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: cannot divide by zero. " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: invalid input format. " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation completed.");
            }

            /*
             * Question: What is the purpose of the finally block? 
             * Answer:
             * the finally keyword is an important component of exception handling 
             * It makes sure that specific cleanup code is always executed,whether an exception is thrown or not 
             * it exists to guarantee that certain actions are performed, regardless of the outcome of the try block
             * This makes it ideal for releasing resources such as file handles, database connections, or network streams.
             * "ref: geeksforgeeks website"
             */
            #endregion

            #region Problem03
            int? num31 = null;
            int num32 = num31 ?? 0;
            if (num31.HasValue)
                Console.WriteLine("your number is: " + num31.Value);
            else
                Console.WriteLine("you did not enter a number so we assigned it to 0: " + num32);

            /*
             * Question: What exception occurs when trying to access Value on a null Nullable<T>?
             * Answer:
             * if you try to access the Value property of a null Nullable<T> instance
             * it will throw an InvalidOperationException
             */
            #endregion

            #region Problem04
            int[] arr41 = { 1, 2, 3, 4, 5 };

            try
            {
                Console.WriteLine("trying to access index 5...");

                int num41 = arr41[5];
                Console.WriteLine("the number at index 5: " + num41);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: you tried to access an index that does not exist!, system Message: " + ex.Message);
            }

            /*
             * Question: Why is it necessary to check array bounds before accessing elements?
             * Answer:
             * because accessing an index that is out of bounds will throw an IndexOutOfRangeException
             * which can crash the program if not handled properly
             * "ref: stackoverflow website"
             */
            #endregion

            #region Problem05
            int[,] arr51 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };

            for (int i = 0; i < 3; i++)
            {
                int RowSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    RowSum += arr51[i, j];
                }
                Console.WriteLine($"the sum of row {i}: {RowSum}");
            }

            for (int j = 0; j < arr51.GetLength(0); j++)
            {
                int ColSum = 0;
                for (int i = 0; i < arr51.GetLength(1); i++)
                {
                    ColSum += arr51[i, j];
                }
                Console.WriteLine($"the sum of column {j}: {ColSum}");
            }

            /*
             * Question: How is the GetLength(dimension) method used in multi-dimensional arrays? 
             * Answer:
             * you use the GetLength(0) to get the number of rows and GetLength(1) to get the number of columns in a 2D array
             * and GetLength(3) to get the number of elements in a 3D array and so on
             */
            #endregion

            #region Problem06
            int[][] arr61 = new int[3][];

            arr61[0] = new int[2];
            arr61[1] = new int[4];
            arr61[2] = new int[3];

            for (int i = 0; i < arr61.Length; i++)
            {
                Console.WriteLine($"Enter values for row {i}:");
                for (int j = 0; j < arr61[i].Length; j++)
                {
                    Console.Write($" Enter value for column {j}: ");
                    arr61[i][j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < arr61.Length; i++)
            {
                Console.WriteLine($"Row {i}: ");
                for (int j = 0; j < arr61[i].Length; j++)
                {
                    Console.Write(arr61[i][j] + " ");
                }
                Console.WriteLine();
            }

            /*
             * Question: How does the memory allocation differ between jagged arrays and rectangular arrays?
             * Answer:
             * jagged arrays are stored in memory as an array of references to other blocks (each block hold an inner array)
             * so it is not just single block of memory but rather multiple blocks of memory for each inner array
             * while rectangular arrays are stored in just one block of memory and all elements are stored in it
             */
            #endregion

            #region Problem07
            string? refernce = null;

            Console.Write("Enter a refernce: ");
            string? input = Console.ReadLine();

            refernce = input;
            Console.WriteLine($"you entered: {refernce}");

            /*
             * Question: What is the purpose of nullable reference types in C#? 
             * Answer:
             * the purpose of nullable reference types in C# is to provide a way to indicate that a reference type variable can be null
             * and to help prevent null reference exceptions at compile time by providing warnings
             * when a nullable reference type is dereferenced without a null check.
            */
            #endregion

            #region Problem08
            int num81 = 100;
            object OB81 = num81;

            Console.WriteLine($"the number is : {num81}");
            Console.WriteLine($"after boxing, the object is: {OB81}");

            try
            {
                int OB82 = (int)OB81;
                Console.WriteLine($"successfully unboxed: {OB82}");

                Console.WriteLine("trying to unbox to wrong type (string)...");
                string S81 = (string)OB81;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Error: you can not cast to string , system massege: {ex.Message}");
            }

            /*
             * Question: What is the performance impact of boxing and unboxing in C#?
             * Answer:
             * the impact is significant overhead due to:
             * 1- Memory Allocation: Boxing forces a value from the stack onto the heap, creating a new object.
             * 2- CPU Cycles: Unboxing requires a type check and a memory copy.
             * 3- GC Pressure: Frequent boxing creates many objects, forcing the Garbage Collector to run more often, which slows down the entire application.
             */
            #endregion

            #region Problem09
            // using SumAndMultiply method :
            Console.WriteLine("Enter a number:");
            int num91;
            int.TryParse(Console.ReadLine(), out num91);

            Console.WriteLine("Enter a second number:");
            int num92;
            int.TryParse(Console.ReadLine(), out num92);

            int sum;
            int product;

            SumAndMultiply(num91, num92, out sum, out product);

            Console.WriteLine($"the sum is: {sum}");
            Console.WriteLine($"the product is: {product}");

            /*
             * Question: Why must out parameters be initialized inside the method?
             * Answer:
             * because out parameters are meant to be used as output parameters
             * they must be assigned a value before the method returns
             */
            #endregion

            #region Problem10
            // using PrintString method :
            PrintString("Hello", 3);

            PrintString("Welcome");

            PrintString(count: 2, message: "Ahmed");

            /*
             * Question: Why must optional parameters always appear at the end of a method's parameter list? 
             * Answer:
             * because when you call a method with optional parameters
             * the compiler needs to know which arguments correspond to which parameters
             */
            #endregion

            #region Problem11
            int[]? nullableArray = null;

            int length = nullableArray?.Length ?? 0;
            Console.WriteLine($"array length: {length}");

            /*
             * Question: How does the null propagation operator prevent NullReferenceException?
             * Answer:
             * If the object on the left is null it immediately stops the operation and returns null for the entire expression
             * instead of attempting to access the member.
             */
            #endregion

            #region Problem12
            Console.Write("Enter a day of the week (e.g., Monday): ");
            string? S12 = Console.ReadLine();

            int dayNumber = S12?.ToLower().Trim()
            switch
            {
                "monday" => 1,
                "tuesday" => 2,
                "wednesday" => 3,
                "thursday" => 4,
                "friday" => 5,
                "saturday" => 6,
                "sunday" => 7
            };

            if (dayNumber != 0)
            {
                Console.WriteLine($"is the day {dayNumber} of the week.");
            }
            else
            {
                Console.WriteLine("Invalid day entered.");
            }

            /*
             * Question: When is a switch expression preferred over a traditional if statement?
             * Answer:
             * when you have a variable that can take on multiple discrete values 
             * and you want to execute different code based on those values
             */
            #endregion

            #region Problem13
            // using SumArray method :
            int[] arr1ToSum = { 10, 20, 30 };
            int SumOfarr1 = SumArray(arr1ToSum);
            Console.WriteLine($"the sum of array 1 is: {SumOfarr1}");
            int SumOfarr2 = SumArray(10, 20, 30);
            Console.WriteLine($"the sum of array 2 is: {SumOfarr2}");

            /*
             * Question: What are the limitations of the params keyword in method definitions?
             * Answer:
             * the limitations of the params keyword are:
             * 1- it must be the last parameter in the method definition 
             * 2- only one params parameter is allowed per method 
             * 3- it cannot be used with ref or out parameters
             */

            #endregion

            // part 02

            #region Problem14
            Console.Write("Enter a positive integer: ");

            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i < n)
                    {
                        Console.Write(i + ", ");
                    }
                    else
                    {
                        Console.Write(i);
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("invalid input");
            }
            #endregion

            #region Problem15

            Console.Write("Enter an integer to display its multiplication table: ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {

                for (int i = 1; i <= 12; i++)
                {
                    int result = num * i;

                    if (i < 12)
                    {
                        Console.Write(result + ", ");
                    }
                    else
                    {
                        Console.Write(result);
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("invalid input");
            }
            #endregion

            #region Problem16
            Console.Write("Enter a number: ");

            if (int.TryParse(Console.ReadLine(), out int x))
            {
                Console.WriteLine($"Even numbers between 1 and {x}:");

                for (int i = 1; i <= x; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i);

                        if (i < x - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            #endregion

            #region Problem17
            Console.Write("Enter the base number: ");
            if (!int.TryParse(Console.ReadLine(), out int baseNum))
            {
                Console.WriteLine("invalid input for base number");
                return;
            }

            Console.Write("Enter the power: ");
            if (!int.TryParse(Console.ReadLine(), out int power) || power <= 0)
            {
                Console.WriteLine("invalid input for power");
                return;
            }

            int result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= baseNum;
            }

            Console.WriteLine(result);

            #endregion

            #region Problem18
            Console.Write("Enter a string: ");
            string S18 = Console.ReadLine();

            Console.Write("the output: ");
            for (int i = S18.Length - 1; i >= 0; i--)
            {
                Console.Write(S18[i]);
            }
            Console.WriteLine();
            #endregion

            #region Problem19
            Console.Write("Enter an integer: ");
            string? Y = Console.ReadLine();

            Console.Write("the output: ");
            for (int i = Y.Length - 1; i >= 0; i--)
            {
                Console.Write(Y[i]);
            }
            Console.WriteLine();
            #endregion

            #region Problem21
            Console.WriteLine("Enter a sentence:");
            string sentence = Console.ReadLine();

            string[] S21
                = sentence.Split(' ');

            Console.Write("the output: ");
            for (int i = S21.Length - 1; i >= 0; i--)
            {
                Console.Write(S21[i] + " ");
            }
            Console.WriteLine(); 
            #endregion


        }    

        #region Problem02
        public static void TestDefensiveCode()
        {
            int X, Y, Z;
            do
            {
                Console.WriteLine("Enter first Number : ");
            }
            while (!int.TryParse(Console.ReadLine(), out X) || X <= 0);
            do
            {
                Console.WriteLine("Enter Second Number : ");
            }
            while (!int.TryParse(Console.ReadLine(), out Y) || Y < 1);

            Z = X / Y;

        }

        /*
         * Question: How does int.TryParse() improve program robustness compared to int.Parse()? 
         * Answer: 
         * int.Parse() which throws a FormatException if the input is not a valid integer,
         * but int.TryParse() allows you to check the validity of the input before attempting to use 
         * it returns a boolean indicating whether the parsing was successful or not
         * thus preventing potential crashes and improving the overall robustness of your program.
         */
        #endregion

        static void SumAndMultiply(int a, int b, out int sum, out int product)
        {
            sum = a + b;
            product = a * b;
        }

        static void PrintString(string message, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(message);
            }
        }

       
        static int SumArray(params int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        } 
       
    }
}
