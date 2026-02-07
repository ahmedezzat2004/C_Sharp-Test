using System;

namespace C_Day04_test
{
    public enum DayOfWeek
    {
        Saturday = 1,
        Sunday = 2,
        Monday = 3,
        Tuesday = 4,
        Wednesday = 5,
        Thursday = 6,
        Friday = 7
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Problem01
            int[] arr11 = new int[10];
            int[] arr12 = new int[] { 10, 20, 30 };
            int[] arr13 = { 10, 20, 30 };
            arr11[0] = 100;
            arr12[1] = 200;
            arr13[2] = 300;
            Console.WriteLine(arr11[0]);
            Console.WriteLine(arr12[1]);
            Console.WriteLine(arr13[2]);
            /*
             * Question: What is the default value assigned to array elements in C#?
             * Answer: 
             * The default value assigned to array elements in C# depends on the type of the array
             * For numeric types (like int, float, double), the default value is 0
             * For reference types (like string, object), the default value is null
             * For bool, the default value is false.
             */
            #endregion

            #region Problem02
            int[] arr21 = { 1, 2, 3 };
            int[] arr22 = arr21;
            arr22[0] = 7;
            Console.WriteLine("after shallow copy: " + arr21[0]);


            int[] arr23 = (int[])arr21.Clone();
            arr23[0] = 5;
            Console.WriteLine("after deep copy: " + arr21[0]);

            /*
             * Question: What is the difference between Array.Clone() and Array.Copy()? 
             * Answer: 
             * The Clone() method returns a new array object containing all the elements in the original array
             * The CopyTo() method copies the elements into another existing array
             * "ref: stackOverFlow website"
             */
            #endregion

            #region Problem03
            int[,] grades = new int[3, 3];

            for (int i = 0; i < grades.GetLength(0); i++)
            {
                for (int j = 0; j < grades.GetLength(1); j++)
                {
                    Console.WriteLine($"enter grade for student {i + 1}, for subject {j + 1}: ");
                    grades[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < grades.GetLength(0); i++)
            {
                Console.WriteLine($"for student number {i + 1}: ");
                for (int j = 0; j < grades.GetLength(1); j++)
                {
                    Console.Write(grades[i, j] + " ");
                }
                Console.WriteLine();
            }
            /*
             * Question: What is the difference between GetLength() and Length for multi dimensional arrays? 
             * Answer:
             * GetLength takes an integer that specifies the dimension (in our example 0 for raws or 1 for columns) of the array that you're querying and returns its length.
             * Length property returns the total number of items in an array (will return 9 in our example)
             * "ref: stacOverFlow website"
             */
            #endregion

            #region Problem04
            int[] arr41 = { 5, 7, 3, 8, 1 };
            Array.Sort(arr41);
            Console.WriteLine("after sorting:");
            for (int i = 0; i < arr41.Length; i++)
                Console.Write(arr41[i] + " ");
            Console.WriteLine();

            Array.Reverse(arr41);
            Console.WriteLine("after reversing:");
            for (int i = 0; i < arr41.Length; i++)
                Console.Write(arr41[i] + " ");
            Console.WriteLine();

            int index = Array.IndexOf(arr41, 5);
            Console.WriteLine($"index of 5:  {index} ");
            Console.WriteLine();

            int[] arr42 = new int[5];

            Array.Copy(arr41, arr42, 5);
            Console.WriteLine("after copying: ");
            for (int i = 0; i < arr42.Length; i++)
                Console.Write(arr42[i] + " ");
            Console.WriteLine();

            Array.Clear(arr41, 0, arr41.Length);
            Console.WriteLine("after clearing: ");
            for (int i = 0; i < arr41.Length; i++)
                Console.Write(arr41[i] + " ");
            Console.WriteLine();

            /*
             * Question: What is the difference between Array.Copy() and Array.ConstrainedCopy()?
             * Answer: 
             * Array.Copy might partially succeed if an error occurs. 
             * Array.ConstrainedCopy if the copy cannot be completed fully it rolls back and makes no changes
             */
            #endregion

            #region Problem05
            int[] ID = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < ID.Length; i++)
                Console.Write(ID[i] + " ");
            Console.WriteLine();

            foreach (int x in ID)
                Console.Write(x + " ");
            Console.WriteLine();

            int n = ID.Length - 1;
            while (n >= 0)
            {
                Console.Write(ID[n--] + " ");
            }
            Console.WriteLine();

            /*
             * Question: Why is foreach preferred for read-only operations on arrays?
             * Answer: 
             * That is because foreach is meant to iterate over a container 
             * making sure each item is visited exactly once without changing the container
             * and does not use an explicit "loop index" to avoid nasty side effects.
             * "ref: stackOverFlow website"
             */
            #endregion

            #region Problem06

            int oddNum;
            do
            {
                Console.Write("Enter a positive odd number: ");
            }
            while (!int.TryParse(Console.ReadLine(), out oddNum) || oddNum <= 0 || oddNum % 2 == 0);

            /*
             * Question: Why is input validation important when working with user inputs?
             * Answer:  
             * User input validation is essential for:
             * Preventing Errors: Ensures the program behaves correctly based on user responses.
             * Enhancing Security: Protects against malicious inputs that could harm the system.
             * Improving User Experience: Provides clear feedback and prevents frustration from invalid inputs.
             * "ref: DevZery website"
             */

            #endregion

            #region Problem07
            int[,] M = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Console.WriteLine("print matrix M:");
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    Console.Write(M[i, j] + "\t");
                }
                Console.WriteLine();
            }
            /*
             * Question: How can you format the output of a 2D array for better readability?
             * Answer:use the \t character to add horizontal spacing between elements as shown in the example above.
             */
            #endregion

            #region Problem08
            Console.WriteLine("Enter a month number (1-12): ");
            if (int.TryParse(Console.ReadLine(), out int month))
            {
                Console.WriteLine("Using if-else statements:");
                if (month == 1)
                    Console.WriteLine("January");
                else if (month == 2)
                    Console.WriteLine("February");
                else if (month == 3)
                    Console.WriteLine("March");
                else if (month == 4)
                    Console.WriteLine("April");
                else if (month == 5)
                    Console.WriteLine("May");
                else if (month == 6)
                    Console.WriteLine("June");
                else if (month == 7)
                    Console.WriteLine("July");
                else if (month == 8)
                    Console.WriteLine("August");
                else if (month == 9)
                    Console.WriteLine("September");
                else if (month == 10)
                    Console.WriteLine("October");
                else if (month == 11)
                    Console.WriteLine("November");
                else if (month == 12)
                    Console.WriteLine("December");
                else
                    Console.WriteLine("Invalid Month!");

                Console.WriteLine("Using switch statement:");
                switch (month)
                {
                    case 1:
                        Console.WriteLine("January"); break;
                    case 2:
                        Console.WriteLine("February"); break;
                    case 3:
                        Console.WriteLine("March"); break;
                    case 4:
                        Console.WriteLine("April"); break;
                    case 5:
                        Console.WriteLine("May"); break;
                    case 6:
                        Console.WriteLine("June"); break;
                    case 7:
                        Console.WriteLine("July"); break;
                    case 8:
                        Console.WriteLine("August"); break;
                    case 9:
                        Console.WriteLine("September"); break;
                    case 10:
                        Console.WriteLine("October"); break;
                    case 11:
                        Console.WriteLine("November"); break;
                    case 12:
                        Console.WriteLine("December"); break;
                    default:
                        Console.WriteLine("Invalid Month!"); break;
                }
            }
            else
            {
                Console.WriteLine("Error: Input was not a valid number.");
            }

            /*
             * Question: When should you prefer a switch statement over if-else?
             * Answer:
             * when checking a single variable against many specific constant values 
             * switch statements can be more readable and efficient than multiple if-else statements.
             */

            #endregion

            #region Problem09
            int[] arr91 = { 45, 12, 89, 12, 33, 1 };

            Array.Sort(arr91);
            Console.WriteLine("Sorted array: ");
            for (int i = 0; i < arr91.Length; i++)
                Console.Write(arr91[i] + " ");
            Console.WriteLine();
            int Index01 = Array.IndexOf(arr91, 12);
            Console.WriteLine(Index01);
            int Index02 = Array.LastIndexOf(arr91, 12);
            Console.WriteLine(Index02);
            /*
             * Question: What is the time complexity of Array.Sort()? 
             * Answer:
             * O(n log n) on average and in the worst case, where n is the number of elements in the array.
             */
            #endregion

            #region Problem10
            int[] Y = { 10, 20, 30, 40, 50 };
            int sumFor = 0;
            int sumForeach = 0;

            for (int i = 0; i < Y.Length; i++)
            {
                sumFor += Y[i];
            }
            Console.WriteLine(sumFor);

            foreach (int y in Y)
            {
                sumForeach += y;
            }
            Console.WriteLine(sumForeach);

            /*
             * Question: Which loop (for or foreach) is more efficient for calculating the sum of an array, and why?
             * Answer:
             * for loop is more efficient for calculating the sum of an array
             * because it allows direct access to the array elements using an index
             * which can be faster than the foreach loop's enumerator overhead.
             */
            #endregion

            #region Part02
            //2-
            //using DayOfWeek enum 
            Console.WriteLine("Enter a number from 1 to 7 for the day of the week: ");
            string input = Console.ReadLine();

            try
            {
                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), input);

                Console.WriteLine(day);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            //3-
            /*
             * Q-What happens if the user enters a value outside the range of 1 to 7?
             * Answer:
             * If the user enters a number "8" for example the program will not crash and simply will print the number "8" instead of a day name
             * If the user enters a non-numeric string Enum.Parse will throw an ArgumentException.
             */ 
            #endregion
        }
    }
}
