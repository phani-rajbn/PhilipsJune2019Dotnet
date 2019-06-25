using System;

namespace SampleConApp
{
    class Product
    {
        int productID;//data is private and will be inaccessible outside the class. 
        string productName;
        int _productCost;//Private variables will be camel-cased in C#...
        //U could use _ to prefix private variables in C# to avoid naming conflicts b/w public accessors and private members.  

        public int ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                productID = value;
            }
        }
       //properties are usually public as they are accessors....
        public string ProductName
        {
            get { return productName; }//camelcasing for private members.
            set { productName = value; }
        }

        public int ProductCost
        {
            get { return _productCost; }
            set { _productCost = value; }
        }//value is a smart keyword which takes the data type of the property
    }
    class OOPFeatures
    {
        static void Main(string[] args)
        {
 
            Product product = new Product();
            product.ProductName = "Philips Trimmer";
            product.ProductCost = 1999;
            product.ProductID = 111;

            //Read the data and display it on Console...
            Console.WriteLine("The Name of the product is {0}\nThe Cost is {1:C} and is identified by an ID:{2}", product.ProductName, product.ProductCost, product.ProductID);
        }
    }
    /*Points to remember:
     * Properties are accessors to the private data members. 
     * They can have get, set or both. 
     * Properties internally behave like functions but are used like Fields.
     * Since C# 4.0, there is a new syntax of creating properties called Automatic Properties where U dont need to create private fields, as they are internally created by .NET as hidden fields which are accessed by the automatic properties.  
     */
}
