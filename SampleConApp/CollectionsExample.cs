using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using CommonLayer;
/*
* Collections is a group of classes created to represents various kinds of data strucures to suit UR App requirements which otherwise only depend or Arrays. These classes are created to remove the disadvantages of the arrays in its programs. Arrays are static in nature and fixed in size and U dont have possibility to either add items to the Array or remove items from the array without recreating it. 
* .NET has 2 versions of collections: Generic and Non-Generic Version. Non-Generic version was the first form of Collections introduced in .NET 1.0. They are not type safe as they store the data as object. They are unsafe while reading the data. 
* Generics was introduced in .NET 2.0. It is based on Template concept of C++ where the type is determined while creating the collection object. 
*/
namespace SampleConApp
{
    class CollectionsExample
    {
        static void Main(string[] args)
        {
            stackExample();
            //queueExample();
            //dictionaryExample();
            //hashSetExample();
            //listExample();
            //nonGenericExample();
        }

        private static void stackExample()
        {
            Stack<string> pages = new Stack<string>();
            do
            {
                Console.WriteLine("Enter the page to view");
                pages.Push(Console.ReadLine());//Adds the item to the top....
                string next = Prompt.GetString("Enter B for Back");
                if (next == "B")
                    pages.Pop();//Removes the top item from the Stack
                foreach(string page in pages)
                    Console.WriteLine(page);
            } while (true);
        }

        private static void queueExample()
        {
            Queue<string> recentItems = new Queue<string>();
            do
            {
                string item = Prompt.GetString("Enter the Item to see");
                if (recentItems.Count == 5)
                    recentItems.Dequeue();//Removes the first item in the queue. 
                recentItems.Enqueue(item);//Adds the item to the bottomm
                var list = recentItems.Reverse();//System.Linq...
                Console.WriteLine("UR recently viewed items:");
                foreach(string element in list)
                    Console.WriteLine(element);
            } while (true);
        }

        private static void dictionaryExample()
        {
            //memorywise its more in size, but highly optimized as U dont loop while accessing the members. Stores the data in the form of key-value pairs. Key is unique for the collection and value associated with the key may not be unique. Uniqueness of the key is based on the hashcode only. 
            //username and password where username is unique but passwords for the users may or may not be the same. 
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("user1", "apple123");//Adds the pair to the dictionary
            users["user2"] = "welcome123";//Another way to add the pair..
            //Add method will throw an Exception if the Key already exists. [] operator will replace the value if the key exists, else adds the new key and the value to it. 
            if (users.ContainsKey("user3"))//Checks for the key...
                Console.WriteLine("User already exists");
            else
            {
                Console.WriteLine("user does not exist\n Please enter a password");
                users["user3"] = Console.ReadLine();
            }
            ///////////////display all the pairs from the dictionary////////////
            foreach(KeyValuePair<string, string>pair in users)
                Console.WriteLine($"{pair.Key}:{pair.Value}");
            //Find a certain key and its value:
            Console.WriteLine("The value of user1 is " + users["user1"]);//get the value of the specified key in the dictionary, no need to iterate....
        }

        private static void hashSetExample()
        {
            //HashSet is a collection class similar to List but stores only unique values in it. It implements an interface called ISet<T> which has methods to check the hash value of an object before it inserts to the collection. 
            //HashSet maintains the Uniqueness if the class of the object overrides the Equals and the GetHashCode method. 
            HashSet<Book> library = new HashSet<Book>();
            library.Add(new Book { BookID = 111, Price = 456, Title = "Apple Nopl" });
            library.Add(new Book { BookID = 112, Price = 456, Title = "Apple Nopl" });
            library.Add(new Book { BookID = 113, Price = 456, Title = "Apple Nopl" });
            library.Add(new Book { BookID = 114, Price = 456, Title = "Apple Nopl" });
            library.Add(new Book { BookID = 115, Price = 456, Title = "Apple Nopl" });
            Console.WriteLine("The Total books: " + library.Count);
            //Add returns bool to tell whether the object is added or not...
        }

        private static void listExample()
        {
            List<string> fruits = new List<string>();//Blank List<T>
            fruits.Add("Apple");//Adds to the bottom of the List....
            fruits.Add("Mango");
            fruits.Add("Banana");
            fruits.Insert(2, "PineApple");//Anywhere in b/w the list if the index is within the bounds. 
            foreach (String fruit in fruits) Console.WriteLine(fruit);
            Console.WriteLine(fruits.Remove("Banana")); //Remove method tries to remove an existing object from the collection, if not found it returns false, else returns true. 
            Console.WriteLine("The no items in the basket:" + fruits.Count);

            //To display using for loop:
            for (int i = 0; i < fruits.Count; i++)
            {
                Console.WriteLine(fruits[i]);//List supports INDEX also......
            }
            //List allows duplicates. It does not have any feature to allow only unique values within the list. 
        }

        private static void nonGenericExample()
        {
            //old Collections store the data as object, which is unsafe as the data type could be anything, they use a lot of boxing and unboxing which will reduce the performance of the Collection. 
            ArrayList obj = new ArrayList();//Create Dynamic Arrays....
            obj.Add(123);
            obj.Add("Apple123");
            for (int i = 0; i < obj.Count; i++)
            {
                Console.WriteLine(obj[i].ToString().ToUpper());
            }
        }
    }
}
