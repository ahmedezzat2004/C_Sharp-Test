using System;

namespace C_Day07_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Part01

            #region Problem01
            Car c1 = new Car();
            string str11 = c1.ToString();
            Console.WriteLine(str11);

            Car C2 = new Car(2);
            string str12 = C2.ToString();
            Console.WriteLine(str12);

            Car C3 = new Car(3, "Mazda");
            string str13 = C3.ToString();
            Console.WriteLine(str13);

            Car C4 = new Car(4, "Mazda", 50000);
            string str14 = C4.ToString();
            Console.WriteLine(str14);
            /*
             * Question: Why does defining a custom constructor suppress the default constructor in C#? 
             * Answer:
             * the compiler stop providing the "empty" default constructor to prevent people from creating "blank" objects 
             * that might break your logic
             */
            #endregion

            #region Problem02
            Calculator cal = new Calculator();
            Console.WriteLine(cal.Sum(1, 2));
            Console.WriteLine(cal.Sum(1, 2, 3));
            Console.WriteLine(cal.Sum(1.5, 2.5));

            /*
             * Question: How does method overloading improve code readability and reusability? 
             * Answer:
             * Method overloading allows you to use the same method name for different purposes
             * which can make your code more intuitive and easier to read
             * It also promotes code reusability by enabling you to define multiple behaviors for a single method name
             * reducing the need for duplicate code and enhancing maintainability
             */
            #endregion

            #region Problem03
            Child chiled = new Child(10, 20, 30);

            Console.WriteLine("X: " + chiled.X);
            Console.WriteLine("Y: " + chiled.Y);
            Console.WriteLine("Z: " + chiled.Z);

            /*
             * Question: What is the purpose of constructor chaining in inheritance?  
             * Answer:
             * to ensure that the base class is properly initialized before the derived class adds its own initialization logic.
             */
            #endregion

            #region Problem04

            Console.WriteLine(chiled.Product());
            /*
             * Question: How does new differ from override in method overriding?
             * Answer:
             * new is used to hide a method in the base class while override is used to provide a new implementation for a method in the base class.
             */
            #endregion

            #region Problem05

            Parent parent = new Parent(10, 20);
            Console.WriteLine("parent method:");
            string str51 = parent.ToString();
            Console.WriteLine(str51);
            Console.WriteLine("chiled method:");
            string str52 = chiled.ToString();
            Console.WriteLine(str52);

            /*
             * Question: Why is ToString() often overridden in custom classes?
             * Answer:
             * because it provides a way to return a string representation of an object
             * which can be useful for debugging, logging, or displaying information about the object in a user-friendly format
             * By overriding ToString() you can customize the output to include relevant details about the object's state or properties
             * making it easier to understand and work with the object in various contexts
             */
            #endregion

            #region Problem06
            Rectangle rec1 = new Rectangle(5, 10);

            rec1.Draw();
            Console.WriteLine("The Area is: " + rec1.Area);

            /*
             * Question: Why can't you create an instance of an interface directly?  
             * Answer:
             * because an interface is a contract that defines a set of methods and properties that a class must implement
             * but it does not provide any implementation itself
             */
            #endregion

            #region Problem07
            Circle circle = new Circle(5);
            circle.PrintDetails();

            /*
             * Question: What are the benefits of default implementations in interfaces introduced in C# 8.0? 
             * Answer: 
             * default implementations allow you to add new functionality to an interface without breaking the classes that already use it 
             * before to C# 8.0 adding a method to an interface was a "breaking change" that 
             * every single class using that interface would suddenly fail to compile until they all manually added the new method
             */
            #endregion

            #region Problem08
            IMovable myVehicle = new Car();

            myVehicle.Move();

            /*
             * Question: Why is it useful to use an interface reference to access implementing class methods?  
             * Answer:
             * because it allows you to write more flexible and maintainable code 
             * using an interface reference is useful because it allows you to focus on what an object can do
             * rather than how it is built
             */
            #endregion

            #region Problem09
            File file = new File("MyFile");

            file.Read();
            file.Write();

            /*
             * Question: How does C# overcome the limitation of single inheritance with interfaces? 
             * Answer:
             * C# allows a class to implement multiple interfaces which enables it to inherit behavior 
             * from multiple sources without the complications of multiple inheritance that can arise with classes
             */
            #endregion

            #region Problem10
            Rectangle rec2 = new Rectangle(4, 5);

            rec2.Draw();
            Console.WriteLine("Area: " + rec2.CalculateArea());

            /*
             * Question: What is the difference between a virtual method and an abstract method in C#? 
             * Answer:
             * virtual method is a method that has an implementation in the base class and can be overridden in derived classes
             * while an abstract method is a method that does not have an implementation in the base class and
             * must be overridden in derived classes.
             */
            #endregion

            // Part02

            #region Part02
            /*
                * Q1: What is the difference between class and struct in C#?
                * Answer: 
                * 1- a class is a reference type while a struct is a value type
                * 2- a class can support inheritance while a struct cannot
                * 3- a class is allocated on the heap managed by th garbage collector while a struct is allocated on the stack
                * 4- a class can have a parameterless constructor while a struct cannot have a parameterless constructor (unless it's a nullable struct)
                * 5- a class has extra memory overhead due to reference type features while a struct is more lightweight
                * 6- a class can be null while a struct cannot be null (unless it's a nullable struct)
                * 7- a class is typically used for complex data structures and objects that require reference semantics 
                * while a struct is typically used for small simple data structures that benefit from value semantics
                * 8- new keyword in Class: Allocates memory on the Heap then Initializes with defaults then Calls the user-defined constructor then Returns the reference (address)
                * while new keyword in Struct: Initializes with defaults then Calls the user-defined constructor then Returns the value (copy)
                * 9- Classes support full inheritance and polymorphic behavior but Structs do not support inheritance
                * Because of their fixed size on the stack
                */

            /*
             * Q2: If inheritance is relation between classes clarify other relations between classes
             * Answer:
             * 1- Association: a relationship where one class uses another class as part of its functionality but does not own it 
             * For example a Car class might have an Engine class as part of its functionality but the Engine can exist independently of the Car.
             * 2- Aggregation: a relationship where one class owns another class but the owned class can exist independently of the owner
             * the owned class is typically created outside the owner class and passed to it as a parameter 
             * 3- Composition: a relationship where one class owns another class and the owned class cannot exist independently of the owner
             * the owned class is typically created in the owner class
             */ 
            #endregion

        }
    }
}
