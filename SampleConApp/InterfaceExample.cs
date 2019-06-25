using System;
/*
 * interfaces are like abstract classes that have only abstract methods. 
 * They cannot have fields, they can have either methods or properties. s
 * interface methods are only public and so, no access specifier is to be given
 * class that implements them, must provide public defns. to all the methods. 
 * Class can implement multiple interfaces at the same level.
 * Class could implement an interface either explicitly or implicitly. 
 * One interface could be implemented by different classes which can lead to a design pattern called Factory pattern. 
 * interface is more like a contract which must be implemented by the implementor class. If a class implements an interface, it is assumed always that the class must and will provide the public definitions for those methods, in other words, the class guarantees that the functions are made available. 
 */
namespace SampleConApp
{
    interface IParty
    {
        void OrderCake();
        void InviteFriends();
        void OrderFood();
    }

    //Interface implementation and Class derivation syntax as same in C#...
    class BirthdayParty : IParty
    {
        public void InviteFriends()
        {
            Console.WriteLine("Email all the frieds for the party");
        }

        public void OrderCake()
        {
            Console.WriteLine("Order Cake from Butter Sponge");
        }

        public void OrderFood()
        {
            Console.WriteLine("Ordered Food From Vidyarthi Bhavan");
        }
    }

    class CustomParty : IParty
    {
        public void InviteFriends()
        {
            Console.WriteLine("I dont have friends");
        }

        public void OrderCake()
        {
            Console.WriteLine("Order Eggless cake");
        }

        public void OrderFood()
        {
            Console.WriteLine("Prepare my own food");
        }
    }
    class InterfaceExample
    {
        static void Main(string[] args)
        {
            IParty myParty = new BirthdayParty();
            myParty.InviteFriends();
            myParty.OrderCake();
            myParty.OrderFood();
        }
    }
}
