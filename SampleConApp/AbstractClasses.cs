using System;

/*
 * Abstract classes are classes which have atleast one method that is not implememented but is expecting its derived class to implement them. As one or more methods are not implemented, they are incomplete classes, are not instantiatable. 
 * Abstract classes can have normal and virtual methods with them. 
 * Methods that are not implemented should be marked with abstract keyword. 
 * Classes with abstract methods must be marked as abstract class. 
 * The derived class which inherits from the abstract class, must implement all the abstract methods, else even this class should be marked as abstract.
 * abstract methods are implemented in the derived classes using override keyword.
 * override can be applied on virtual, override and abstract methods of the base class. 
 */
namespace SampleConApp
{
    abstract class Vehicle
    {
        public string RegNo { get; set; }
        public DateTime ParkingTime { get; set; }
        public abstract void ParkingFee();
        public double BillAmount { get; protected set; }
    }

    class Car : Vehicle
    {
        //Cars will have 60 Rs for 2 hr parking...and +20 for every additional
        public override void ParkingFee()
        {
            TimeSpan span = DateTime.Now - ParkingTime;//get the parking Time
            int hrs = span.Hours + 1;
            if (hrs <= 2)
                BillAmount = 60;
            else if(hrs > 2)
            {
                BillAmount = 60 + ((hrs - 2) * 20);
            }  
        }
    }
    //To create Bike and SUV: Bike: 20 + 5 for every hr... SUV: 100 + 30 for hr
    class AbstractClasses
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Car();
            vehicle.RegNo = "KA41 MG 9460";
            vehicle.ParkingTime = DateTime.Now.AddMinutes(-123);
            vehicle.ParkingFee();
            Console.WriteLine("The Current Parking Bill: " + vehicle.BillAmount);
        }
    }
}
