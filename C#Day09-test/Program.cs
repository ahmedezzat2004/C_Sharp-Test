using System;
using System.Collections.Generic;

namespace C_Day09_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //part01

            #region Problem01

            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine($"Name: {day} , Value: {(int)day}");
            }

            /*
            * Question: Why is it recommended to explicitly assign values to enum members in some cases?
            * Answer:
            * sometimes we need to assign values manually because:
            * 1- if we are storing enum values in a database or file, the numbers must not change,
            * if someone adds a new member in the middle, it will mess up old saved data
            * 2- when we use flags enum (like permissions) we need specific numbers like 1,2,4,8...
            * 3- it makes the code more readable and easier to understand for other people
            */
            #endregion

            #region Problem02

            foreach (Grades grade in Enum.GetValues(typeof(Grades)))
            {
                Console.WriteLine($"Grade: {grade} , Value: {(double)grade}");
            }

            /*
            * Question: What happens if you assign a value to an enum member that exceeds the underlying type's range?
            * Answer:
            * if i try to put a value that is too big or too small for the type i chose
            * the compiler will give me an error and the code will not run
            */

            #endregion

            #region Problem03

            Person p1 = new Person();
            p1.Name = "Ahmed";
            p1.Age = 25;
            p1.Department = "IT";
            p1.ToString();

            Person p2 = new Person();
            p2.Name = "Sara";
            p2.Age = 30;
            p2.Department = "HR";
            p2.ToString();

            /*
             * Question : Purpose of virtual keyword with properties ?
             * Answer   :
             * virtual means "child classes are allowed to override this property
             * and supply their own version."
             * Without virtual the child cannot use the override keyword.
             * Core of runtime polymorphism : the correct version is picked at run-time
             * depending on the actual object type (not the reference type).
             */
            #endregion

            #region Problem04
            Child c = new Child { Name = "Mohamed", Salary = 7000 };
            c.DisplaySalary();

            /* Question: Why can't you override a sealed property / method ?
            * Answer:
            * sealed tells the compiler "this is the final implementation – stop here."
            * Trying to override it in a further sub-class causes a compile-time error.
            * Reasons to seal :
            * 1- Protect critical logic from accidental / malicious change.
            * 2- Minor JIT optimisation (devirtualisation).
            */   
            #endregion

            #region Problem05
            double U = Utility.RectanglePerimeter(5, 3);
            Console.WriteLine(U);

            /* Question: Key difference between static and object members ?
            * Answer:
            * 1- static belongs to the CLASS itself, shared, one copy in memory.
            * Called via class name : Utility.RectanglePerimeter(…)
            * Cannot use 'this' keyword.
            * 2- instance belongs to each OBJECT separately.
            * Called via reference : myObj.Method()
            * Can use 'this' keyword.
            */
            #endregion

            #region Problem06
            ComplexNumber cn1 = new ComplexNumber { Real = 2, Imag = 3 };
            ComplexNumber cn2 = new ComplexNumber { Real = 1, Imag = 4 };
            ComplexNumber cn3 = cn1 * cn2;
            Console.WriteLine($"cn1 = {cn1}");
            Console.WriteLine($"cn2 = {cn2}");
            Console.WriteLine($"cn1 * cn2 = {cn3}");

            /* Question: Can you overload ALL operators in C# ?
            * Answer:
            * No,
            * we can overload : +  -  *  /  %  ==  !=  <  >  <=  >=  !  ~  ++  -- …
            * we can not overload : =  &&  ||  ?  new  typeof  sizeof  is  as
            * Reason : the non-overloadable set is fundamental to the language runtime.
            * Allowing = overload would make assignment unpredictable and break the language.
            */
            #endregion

            #region Problem07
            Console.WriteLine($"sizeof(int)  = {sizeof(int)}  bytes  (default enum underlying type)");
            Console.WriteLine($"sizeof(byte) = {sizeof(byte)} byte   (our Gender enum)");
            foreach (Gender gen in Enum.GetValues(typeof(Gender)))
                Console.WriteLine($"Gender : {gen,-10} Value : {(byte)gen}");

            /* Question: When to change the underlying type of an enum ?
            * Answer:
            * - Use byte / short for very few values, want to save memory
            * (byte = 1 byte  vs  default int = 4 bytes)
            * - Use long for values exceed int range
            * - Keep default int for most everyday cases, safest choice
            * Rule: change only when there is a clear reason.
            */
            #endregion

            #region Problem08
            double cel = 100;
            double fah = Utility.CelsiusToFahrenheit(cel);
            Console.WriteLine($"{cel}°C is {fah}°F");
            Console.WriteLine($"{fah}°F is {Utility.FahrenheitToCelsius(fah)}°C");

            /* Question: Why can't a static class have instance constructors ?
            * Answer:
            * A static class can never be instantiated, An instance constructor only makes sense when creating objects.
            * Since no object is ever created, an instance ctor would be unreachable compiler disallows it
            * A static constructor (runs once) is still allowed.
            */
            #endregion

            #region Problem09

            string[] inputs = { "A", "B", "InvalidGrade", "F", "XYZ", "C" };
            for(int i=0 ; i < inputs.Length; i++)
            {
                if (Enum.TryParse(inputs[i], out Grades parsed))
                    Console.WriteLine($"Ok {inputs[i]} is {parsed}  ({(short)parsed})");
                else
                    Console.WriteLine($"Failed {inputs[i]} invalid, handled gracefully");
            }
            /* Question : TryParse vs int.Parse ?
            * Answer:
            * int.Parse throws FormatException on bad input and can crash program.
            * TryParse returns bool, never throws and safe for any user input.
            */
            #endregion

            #region Problem10

            Employee[] emps =
            {
                new Employee(1, "Ali",    6000, "IT"),
                new Employee(2, "Mona",   8000, "HR"),
                new Employee(3, "Kareem", 7000, "IT"),
            };
            Employee target = new Employee(2, "Mona", 8000, "HR");
            int idx = Helper<Employee>.SearchArr(emps, target);
            Console.WriteLine(idx != -1 ? $"Found at index {idx} , {emps[idx]}": "Not found");

            /*
             * Question: What is the difference between overriding Equals and == for object comparison in C# struct and class ? 
             * Answer:
             * - For a class, == by default compares references (memory addresses), 
             * while Equals can be overridden to compare content. 
             * So two different objects with the same data would be "not equal" with == but "equal" with an overridden Equals.
             */

            /*
             * Question: Why is overriding ToString beneficial when working with custom classes?
             * Answer: 
             * overriding ToString allows us to provide a meaningful string representation of our objects.
             */
            #endregion

            #region Problem11
            Console.WriteLine($"MaxOf(10, 25)= {Helper<int>.Max(10, 25)}");
            Console.WriteLine($"MaxOf(3.14, 2.71) = {Helper<double>.Max(3.14, 2.71)}");
            Console.WriteLine($"MaxOf(\"apple\", \"zebra\") = {Helper<string>.Max("apple", "zebra")}");

            /* Question: Can generics be constrained to specific types ?
            * Answer:
            * Yes, using the 'where' keyword.
            * for example : 
            * where T : IComparable   
            */
            #endregion

            #region Problem12
            int[] nums = { 1, 2, 3, 2, 4, 2 };
            Console.WriteLine($"Before: {nums} ");
            Helper<int>.ReplaceArray(nums, 2, 99);
            Console.WriteLine($"After: {nums} ");

            string[] strs = { "cat", "dog", "cat", "bird" };
            Console.WriteLine($"Before: {strs} ");
            Helper<string>.ReplaceArray(strs, "cat", "lion");
            Console.WriteLine($"After: {strs} ");

            /* Question: Key differences between generic methods and generic classes ?
            * Answer:
            * Generic Method: type param on the method public T Max<T>(T a, T b)
            * Type inferred or specified at the call site, Only that one method is generic; rest of class is normal.
            * Generic Class: type param on the class Helper<T> Specified when creating the object: new Helper<int>() 
            * All methods in the class share the same T.
            * Rule : use generic method when only one operation needs flexibility.
            * and use generic class  when the whole data structure works around one T.
            */
            #endregion

            #region Problem13
            Rectangle r1 = new Rectangle { Length = 10, Width = 5 };
            Rectangle r2 = new Rectangle { Length = 20, Width = 8 };
            Console.WriteLine($"Before : r1={r1}  r2={r2}");
            Rectangle r3 = r1; 
            r1 = r2;
            r2 = r3;
            Console.WriteLine($"After  : r1={r1}  r2={r2}");

            /*Question: Why prefer a generic Swap over a custom method for each type ?
            * Answer:
            * Without generics we repeat the same three lines for every type : SwapInt, SwapDouble, SwapRectangle, SwapPoint …
            * Violates DRY (Don't Repeat Yourself).
            * Generic Swap<T> writes it ONCE and it works for all types.
            * Benefits : less code, one bug-fix location, type-safe, no boxing.
            */
            #endregion

            #region Problem14

            Department itDept = new Department { DeptId = 1, DeptName = "IT" };
            Department hrDept = new Department { DeptId = 2, DeptName = "HR" };

            Employee e1 = new Employee { EmpId = 1, Name = "Ali", Dept = itDept };
            Employee e2 = new Employee { EmpId = 2, Name = "Mona", Dept = hrDept };
            Employee e3 = new Employee { EmpId = 3, Name = "Kareem", Dept = itDept };
            Employee[] all = { e1, e2, e3 };

            Employee searchE = new Employee { EmpId = 3, Name = "Kareem", Dept = itDept };
            int res = Helper<Employee>.SearchArr(all, searchE);
            Console.WriteLine(res != -1 ? $"Found : {all[res]}" : "Not found");

            /* Question: How does overriding Equals for Department improve search accuracy ?
            * Answer:
            * Without override, Equals on a class compares reffernces (memory addresses).
            * Two separate Department objects with the same data would be "not equal."
            * After override, Equals compares DeptId + DeptName (content).
            * SearchArray uses Equals internally to finds employees by department correctly.
            */
            #endregion

            #region Problem15

            CircleStruct cs1 = new CircleStruct { Radius = 5, Color = "Red" };
            CircleStruct cs2 = new CircleStruct { Radius = 5, Color = "Red" };
            CircleStruct cs3 = new CircleStruct { Radius = 9, Color = "Blue" };

            Console.WriteLine($"cs1 == cs2 (same values) : {cs1 == cs2}");   
            Console.WriteLine($"cs1 == cs3 (diff values) : {cs1 == cs3}");   
            Console.WriteLine($"cs1.Equals(cs2): {cs1.Equals(cs2)}");

            CircleClass cc1 = new CircleClass { Radius = 5, Color = "Red" };
            CircleClass cc2 = new CircleClass { Radius = 5, Color = "Red" };
            CircleClass cc3 = cc1; 

            Console.WriteLine($"cc1 == cc2 (diff ref, same data) : {cc1 == cc2}");  
            Console.WriteLine($"cc1 == cc3 (same reference) : {cc1 == cc3}");   
            Console.WriteLine($"cc1.Equals(cc2) (overridden) : {cc1.Equals(cc2)}");

            /*
             * Question: Why is == not implemented by default for structs?
             * Answer: 
             * The compiler doesn't know which fields define "equality" for a struct.
             * Should it compare all fields?  A subset?  The developer must decide.
             * Equals() IS auto-generated (reflection over all fields) but is slow.
             * For == the developer must explicitly overload it to set the rule.
             * This forces deliberate design rather than silent wrong behaviour.
             * (Compare: classes get a default == that compares references.)
             */
            #endregion

            //part02

            /*
             * Q1- What we mean by Generalization concept using Generics ?  
             * Answer:
             * Generalization using Generics means creating a single template that works for many data types.
             * Instead of writing separate code for int, string, or bool, you use a placeholder (usually <T>).
             * The 3 Main Points:
             * 1-Code Reuse: You write the logic once and apply it to any type.
             * 2-Type Safety: The compiler checks that you’re using the correct data, preventing "Runtime" crashes.
             * 3-Performance: It is faster than using the object type because it avoids "Boxing" (converting values to objects).
             */

            /*
             * Q2- What we mean by hierarchy design in real business ? 
             * Answer:
             * Hierarchy Design is the "Chain of Command" in a company. It defines who is in charge, who reports to whom, and how decisions are made.
             * The 3 Levels:
             * 1-Top Management: (CEO/Owners) Set the big goals and vision.
             * 2-Middle Management: (Department Heads) Turn goals into plans for their teams.
             * 3-Operational Level: (Employees) Do the daily work and tasks.
             * it is important for :
             * -Clear Authority: Everyone knows their boss and their responsibilities.
             * -Better Flow: Information moves up (reports) and down (instructions) efficiently.
             * -Organization: It groups people by skill, like putting all "Tech" people in one IT department.
             */

            #region Problem01(2)

            int[] arr11 = { 1, 2, 3, 4, 5 };
            Console.Write($"Original :{arr11} ");
            Console.Write($"Reversed : {GenericHelper.ReverseArray(arr11)}");

            string[] arr12 = { "apple", "banana", "cherry" };
            Console.Write($"Original :{arr12} ");
            Console.Write($"Reversed : {GenericHelper.ReverseArray(arr12)}");

            #endregion

            #region Problem02(2)
            MyStack<int> stack = new MyStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Peek after: {stack.Peek()}");
            #endregion

            #region Problem03(2)

            int[] arr31 = { 10, 20, 30, 40, 50 };
            Console.WriteLine($"Before: {arr31}");
            GenericHelper.SwapElements(arr31, 0, 3);
            Console.WriteLine($"After: {arr31}");

            #endregion

            #region Problem04(2)
            int[] arr41 = { 3, 7, 1, 9, 4, 6 };
            string[] arr42 = { "banana", "apple", "zebra", "mango" };
            Console.WriteLine($"Max int: {GenericHelper.FindMax(arr41)}");
            Console.WriteLine($"Max string: {GenericHelper.FindMax(arr42)}");
            #endregion

        }
    }
}
    enum WeekDays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    enum Grades : short
    {
        F = -1,
        D = 0,
        C = 1,
        B = 2,
        A = 3
    }

    enum Gender : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }

    struct Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override string ToString()
        {
            return $"({Length} x {Width})";
        }
    }

    struct CircleStruct
    {
        public double Radius { get; set; }
        public string Color { get; set; }

        public static bool operator ==(CircleStruct L, CircleStruct R)
        {
            return L.Radius == R.Radius && L.Color == R.Color;
        }
        public static bool operator !=(CircleStruct L, CircleStruct R)
        {
            return !(L == R);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is CircleStruct)) return false;
            CircleStruct other = (CircleStruct)obj;
            return Radius == other.Radius && Color == other.Color;
        }
        public override int GetHashCode()
        {
            return Radius.GetHashCode() ^ Color.GetHashCode();
        }
    }