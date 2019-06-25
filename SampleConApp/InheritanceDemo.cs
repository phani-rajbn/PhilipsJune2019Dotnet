using System;
/*
 * Inheritance is based on SOLID Principle's Open-Close Principle where a class when created is Open for Extension but Closed for Modification.
 * Class is said to be immutable, U cannot modify a class once created. 
 * So to add any new functionality(Extending) or modify an existing functionality(Overriding) we need Inheritance. 
 * In C#, Inheritance is single inheritance(UR Class can have only one base class at any level), not multiple. However we have multi-level Inheritance where a class can have an hirarchy of classes.  
 * U have general inheritance no private or public inheritance.
 * Use method overriding for modifying the existing functionality of the base class in its derived. 
 * The base class must provide a permission to the derived classes to modify the method without changing the signature of the method. This is done using a declaration called virtual. 
 * Derived class will perform the modification using override. Only virtual methods can be overriden in the derived class. Non Virtual methods cannot be overriden. 
 * If the method in the base class is itself an overriden method, it could be further overriden in the derived class.
 * While overriding, U should not alter the signature of the method. 
 * If new methods are created by the derived class, then the base class object when instantiated to derived class will not get these methods. However U could do downcasting to the derived type and invoke the methods from it. 
 * This is applicable even for the non virtual methods that are modified by the derived class without breaking the signature. This is also called as METHOD HIDING...
 */
namespace SampleConApp
{
    enum PaymentMode { Cash, Card, Cheque, Paytm};
    class ParentBusiness
    {
        public virtual void RecievePayment(PaymentMode mode, int amount)
        {
            switch (mode)
            {
                case PaymentMode.Cash:
                    Console.WriteLine("Payment accepted for {0:C} by cash", amount);
                    break;
                case PaymentMode.Cheque:
                    Console.WriteLine("Payment accepted for {0:C} by Cheque", amount);
                    break;
                case PaymentMode.Card:
                case PaymentMode.Paytm:
                default:
                    Console.WriteLine("Invalid Mode of Payment, Payment not accepted");
                    break;
            }
        }
    }

    //taken over by the son of the businessman....
    class NewBusiness : ParentBusiness
    {
        public void MakePayment(int amount)
        {
            Console.WriteLine("Payment of {0:C} made by Online Paypal", amount);
        }
        public override void RecievePayment(PaymentMode mode, int amount)
        {
            switch (mode)
            {
                case PaymentMode.Cheque:
                    Console.WriteLine("Cheques are no longer accepted, Pay by cash, card or Paytm");
                    break;
                default:
                    Console.WriteLine("Payment of {0:C} accepted by {1}", amount, mode);
                    break;
            }
        }
    }
    class BaseClass
    {
        public void BaseFunc()
        {
            Console.WriteLine("Base Func");
        }
    }
    // U might not have the source code of the BaseClass, U might wish to add new feature to the new clients and retain certain features to the existing or older clients. no access specifier is required while inheriting it unlike C++. This makes the inheritance clean without any confusion. All the members of the base class will retain their accessiblity in the derived class. 
    class DerivedClass : BaseClass
    {
        //This is more like a new function, hence the new keyword.....
        public new void BaseFunc()
        {
            Console.WriteLine("Derived Version");
        }
        public void DerivedFunc()
        {
            Console.WriteLine("Derived Func");
        }
    }
    class InheritanceDemo
    {
        static void Main(string[] args)
        {
            //simpleInheritancecExample();
            //overridingExample();
            methodHiding();
        }

        private static void methodHiding()
        {
            BaseClass baseV = new DerivedClass();
            baseV.BaseFunc();//The derived version is not known to the base class.
            if(baseV is DerivedClass)
            {
                DerivedClass cast = baseV as DerivedClass;
                cast.BaseFunc();
            }
        }

        private static void overridingExample()
        {
            ParentBusiness bookStore = new ParentBusiness();
            bookStore.RecievePayment(PaymentMode.Cheque, 4500);
            bookStore.RecievePayment(PaymentMode.Card, 4500);
            if (bookStore is NewBusiness)//Will fail....
            {
                NewBusiness newStore = bookStore as NewBusiness;//New style of casting since C# 3.0. Safe way of UNBOXING......
                newStore.MakePayment(45000);
            }else
                Console.WriteLine("Still working with older version");

            bookStore = new NewBusiness();//Runtime polymorphism.. Base Class object can be easily substituted by any of the sub class objects without breaking the functionality. This is based on the 3rd Principle of the SOLID(Luskov's Substitution Principle). 
            bookStore.RecievePayment(PaymentMode.Cash, 4500);
            bookStore.RecievePayment(PaymentMode.Cheque, 45000);
            //If U R using the base class object, only functions and its overrides are available thro that object, any new method added by the derived class will not be available to the object. 
            //In such cases, U should do downcasting of the object to the derived type and then call its methods...
            //((NewBusiness)bookStore).MakePayment(45000);
            if (bookStore is NewBusiness)//Will fail....
            {
                NewBusiness newStore = bookStore as NewBusiness;//New style of casting since C# 3.0. Safe way of UNBOXING......
                newStore.MakePayment(45000);
            }
            else
                Console.WriteLine("Still working with older version");
        }

        private static void simpleInheritancecExample()
        {
            BaseClass cls = new BaseClass();
            cls.BaseFunc();

            DerivedClass divCls = new DerivedClass();
            divCls.BaseFunc();//old clients
            divCls.DerivedFunc();//new clients....
        }
    }
}
