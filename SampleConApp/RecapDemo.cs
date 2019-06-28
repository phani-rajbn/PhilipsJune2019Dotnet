using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    struct Example
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }

    class BigExample
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
    class RecapDemo
    {
        static void Main(string[] args)
        {
            //valueTypeExample();
            //referenceTypeExample();
            //valueTypeArray();
            //referenceTypeArray();
            //stringVsStringBuilder();
            stringComparing();
        }

        private static void stringComparing()
        {
            string str = "Apple";
            string str2 = "Mango";
            Console.WriteLine(str.Equals(str2));//more prefered.....
            Console.WriteLine(str == str2);
            //IComparable vs. IComparer....-->Sorting purposes...
            //IEnumerable vs. IEnumerator....-->Iterating purposes. 
        }

        private static void stringVsStringBuilder()
        {
            List<string> hugeList = Enumerable.Range(1000, 200000).Select(n => n.ToString()).ToList();
            string strComplete = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            
            //foreach (var str in hugeList) strComplete += str;
            
            //Console.WriteLine(strComplete);
            
            //Console.ReadKey();
            DateTime stamp1 = DateTime.Now;
            //PlaceHolders or Interpolation($) but not + for string concatination...
            foreach (var str in hugeList) stringBuilder.Append(str);
            DateTime stamp2 = DateTime.Now;
            var span = stamp2 - stamp1;
            Console.WriteLine("Total Time: " + span.TotalSeconds);
            
            //Console.WriteLine(stringBuilder.ToString());
            //Console.ReadKey();
            //StringBuilder retains the same object while it appends its content, but string class being immutable, will create a new string every time U add it with += operator. There by old string is Garbage collected and the new string will filled with the new data. 
        }

        private static void referenceTypeArray()
        {
            BigExample[] elements = new BigExample[10];//Gets an Array of null objects. When u access the null object it throws NullReferenceException...
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = new BigExample();//Instantiating all the objects of the Array...
            }
            foreach (var item in elements)
                Console.WriteLine(item.Name);
            //Throws a NullReferenceException...
        }

        private static void valueTypeArray()
        {
            Example [] elements = new Example[10];
            foreach(var item in elements)
                Console.WriteLine(item.Name);//All Value types will be initialized to 0..
        }

        private static void referenceTypeExample()
        {
            BigExample ex = new BigExample { ID = 123, Name = "TestName" };
            BigExample ex2 = ex;//ex2 is simply as alias to ex.....
            ex2.Name = "Changed Name";
            Console.WriteLine("{0} and {1}", ex, ex2);
        }

        private static void valueTypeExample()
        {
            Example ex = new Example { ID = 123, Name = "TestName" };
            Example ex2 = ex;//Cloning the object....
            ex2.Name = "Changed Name";
            Console.WriteLine("{0} and {1}", ex, ex2);
            
        }
    }
}
