using System;
/*
 */
namespace SampleConApp
{
    class ArraysExample
    {
        static void Main(string[] args)
        {
            //singleDimensionalArray();
            //multiDimensionalArray();
            //jaggedArray();
            usingArrayClass();
        }

        private static void usingArrayClass()
        {
            //When U want to create an Array dynamically, then U could use the static method of the Array class called CreateInstance to create an Array and perform operations on it. 
            Console.WriteLine("Enter the size of the Array");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the CTS Type of the Array U want to create");
            Type dataType = Type.GetType(Console.ReadLine(), true, true);//No Exception should be thrown if the data type is not matching, and it should ignore the case...
            Array instance = Array.CreateInstance(dataType, size);

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the value for the type " + dataType.Name);
                string value = Console.ReadLine();
                instance.SetValue(Convert.ChangeType(value, dataType), i);
            }
            foreach(object element in instance)
                Console.WriteLine(element);
        }

        private static void jaggedArray()
        {
            //Array of Arrays is called as Jagged Array.  Fixed no of rows but variable no of columns in each row is called as Jagged Array. A School is an array of classes where each class has an array of students in it. 
            int[][] school = new int[3][];//U have got 3 rows....
            school[0] = new int[] { 45, 56, 56, 45, 45 };
            school[1] = new int[] { 67, 66, 46, 44 };
            school[2] = new int[] { 66, 66, 55, 44, 56, 66, 77, 87, 77, 76 };
            foreach(int[] classroom in school)
            {
                Console.WriteLine("Scores in Class Room");
                foreach(int score in classroom)
                    Console.Write(score + " ");
                Console.WriteLine();
            }
        }

        private static void multiDimensionalArray()
        {
            int[,] TwoDArray = new int[2, 3];
            //All arrays are reference types.  Arrays are all instances of a class System.Array. It gives properties to get the info about the array. 
            Console.WriteLine("The Dimension of the Array :" + TwoDArray.Rank);
            Console.WriteLine("The Total no elements in this array: " + TwoDArray.Length);
            for (int i = 0; i < TwoDArray.GetLength(0); i++)
            {
                Console.WriteLine("Enter the scores for the participant " + (i + 1));
                for (int j = 0; j < TwoDArray.GetLength(1); j++)
                {
                    Console.WriteLine("Enter the score " + (j + 1));
                    TwoDArray[i, j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Finished the tabulation of score for the participant " + (i + 1));
            }
            Console.WriteLine("Displaying all the scores in Matrix format");
            for (int i = 0; i < TwoDArray.GetLength(0); i++)
            {
                for (int j = 0; j < TwoDArray.GetLength(1); j++)
                {
                    Console.Write(TwoDArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        private static void singleDimensionalArray()
        {
            int[] array = new int[5];
            for (int i = 0; i < 5; i++)
            {
                array[i] = i + 1;
            }
            foreach (int value in array)
                Console.WriteLine(value);
            //Foreach is forward only and read only, I cannot use foreach for assignment, but for reading the data. foreach is always within the bounds of the collection, there is no chance of array going out of bounds. foreach can work only on Collections(Groups).  
        }
    }
}