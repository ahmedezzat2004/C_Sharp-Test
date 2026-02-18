using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Day07_test
{
    internal class Car : IMovable {

        public int ID;
        public string Brand;
        public int price;
        public Car() {
            ID = 1;
            Brand = "BMW";
            price = 100000;
        }
        public Car(int _ID , string _Brand , int _Price) {
            ID = _ID;
            Brand = _Brand;
            price = _Price;
        }
        public Car(int _ID) : this( _ID, "BMW" , 100000) {
        
        }
        public Car(int _ID , string Brand) : this(_ID, Brand, 100000)
        {

        }

        public void Move()
        {
            Console.WriteLine("The car is moving");
        }

        public override string ToString()
        {
            return $"ID : {ID} , Brand : {Brand} , Price : {price}";
        }

    }
}
