using System;

/*
 * Customizing object type in C#.
 * object is the base type for all the data types of .NET. Every class U create is derived from the object. object is a reference type. 
 * object has 5 functions which can be overriden by the derived classes:
 * ToString() method to convert the object to string. 
 * Equals() method that defines the equality of an object with another. 
 * GetHashCode() method is to get the Hashcode of the object. 
 * MemberwiseClone() is a protected method that can be overriden to clone an object(Copy). 
 * GetType method is used to get the Type information about the object. GetType method cannot be overriden. It is used only to get the data type details about the object.
 * When an object is passed as an arg to the WriteLine method, it will evaluate the object to a string and displays the string. 
 * By default, the fullname of the class is the string representation of it. However U could override the ToString method to get any string representation of the object like its data or a combination of its data.
 * If U want to define the equality of 2 objects while comparing, then U should override the Equals method. it returns a bool where true means equality is successfull else they are unequal. The Equals method takes an object as an arg which is supposed to be the object to be compared with.  
 */
namespace SampleConApp
{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
           if(obj is Book)
            {
                Book unboxed = obj as Book;
                if ((Title == unboxed.Title) && (Price == unboxed.Price) && (BookID == unboxed.BookID))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return String.Format($"{Title} costs {Price:C}");
        }

        public override int GetHashCode()
        {
            //Its upto UR logic to return a 32 Bit no that identifies UR Object. 
            return BookID.GetHashCode();
        }
    }
    class ObjectUsage
    {
        static void Main(string[] args)
        {
            //toStringOverriding();
            //equalsOverriding();
            hashCodeOverriding();
        }

        private static void hashCodeOverriding()
        {
            //An hashcode is a numeric representation of the object to define its identity in a hash based collection. The HashCode is available for every variable or data type that u use in C#.
            //HashCode is also used to equate 2 objects. If 2 Object's HashCode is different, then they are not equal and they dont belong to the same type. If the HashCode of 2 objects are same, then the CLR will go for the Equals method to check the equality of the objects,
            //Hashbased collection used this hashCode to identify the objects. HashSet, HashTable, Dictionary, are the examples of the Collection classes that determine the identity of the objects in their collection thro GetHashCode method.
            int x = 123;
            int y = 234;
            Console.WriteLine(x.GetHashCode());
            Console.WriteLine(y.GetHashCode());
            Console.WriteLine("Apple".GetHashCode());
            Book bk1 = new Book { BookID = 123, Price = 550, Title = "2 States" };
            Book bk2 = new Book { BookID = 123, Price = 550, Title = "2 States" };
            Console.WriteLine(bk1.Equals(bk2));//true or false...
        }

        private static void equalsOverriding()
        {
            //2 reference type objects are equal if they share the same memory, same data does not guarantee the equality of the objects. 
            Book bk1 = new Book { BookID = 123, Price = 550, Title = "2 States" };
            Book bk2 = new Book { BookID = 124, Price = 550, Title = "2 States" };
            if(bk1.Equals(bk2))
                Console.WriteLine("They are same");
            else
                Console.WriteLine("They are different");
        }

        private static void toStringOverriding()
        {
            Book bk = new Book { BookID = 123, Title = "Professional C#", Price = 450 };
            Console.WriteLine(bk);//Converting the object to a string and display the string, Its ToString method will do the job of converting it to string. 
        }
    }
}
