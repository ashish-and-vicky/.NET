using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main1()
        {
            //System.Array-------behind compiler calls this class
            int[] arr = new int[5];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("enter element no {0} : ", i);
                //Console.WriteLine("enter element no {0} {1}: ", i, i+1);
                //Console.WriteLine("enter element no " + i + " : ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            foreach (int x in arr)
            {
                Console.WriteLine("Value is {0}", x);
            }

            Console.ReadLine();
        }
        static void Main2()
        {
            //System.Array
            int[] arr = new int[5];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("enter element no {0} : ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Array.Clear(arr, 0, 5); ------clears the array (initialises to def value i.e is 0) starting from 0th to 5th element 
            //Array.Copy(arr, arr2, arr.Length); ------copies from 1st array to 2nd array
            //Array.ConstrainedCopy(arr, 0, arr2, 0, arr.Length);  -- copies from 1st to 2nd, but dosen't work if there was an error            
            //Array.CreateInstance(typeof(int), 0)---tells the type of datatype at that place
            //int pos = Array.IndexOf(arr, 10); -------returns -1 if not found
            //int pos = Array.LastIndexOf(arr, 10); -----returns -1 if not found---tells which index the value is starting from the last
            //int pos = Array.BinarySearch(arr, 10); ------returns -1 if not found---for Binary Search, array should be in a sorted order
            //Array.Reverse(arr)---reverses the existing array
            //Array.Sort(arr)---sorts the array
            foreach (int x in arr)
            {
                Console.WriteLine("Value is {0}", x);
            }

            Console.ReadLine();
        }

        static void Main3()
        {
            int[,] arr = new int[5, 3];

            Console.WriteLine(arr.Length); //returns 5 x 3
            
            
            Console.WriteLine(arr.Rank); //it returns the dimension of the array
            Console.WriteLine(arr.GetLength(0)); //suppose we want the length of 1st element of array i.e 5 in above array then we use it.
            Console.WriteLine(arr.GetLength(1));

            Console.WriteLine(arr.GetUpperBound(0)); //it returns you the UpperBound of 5 which is one less...i.e 4...but LowerBond is 0
            Console.WriteLine(arr.GetUpperBound(1));


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("Enter marks for student number {0} and subject {1} ",i, j);
                    arr[i,j] = Convert.ToInt32(Console.ReadLine()); //Convert the entered values integer.
                }
            }
            Console.WriteLine();
            //foreach (int x in arr)
            //{
            //    Console.WriteLine(x);
            //}

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Marks for student number {0} and subject {1} is {2}", i, j, arr[i, j]);
                }
            }
            Console.ReadLine();
        }


        static void Main()
        {
            //jagged
            int[] [] arr = new int[5][]; // this is array of int array
            arr[0] = new int[3]; //will run upto---- arr[0][0]- arr[0][2]
            arr[1] = new int[4];
            arr[2] = new int[2];
            arr[3] = new int[3];
            arr[4] = new int[4];

            for (int i = 0; i < arr.Length; i++) //arr[1].Length will give me arr[1] = new int[4];
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("enter value for subscript [{0}][{1}] : ", i, j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine()); //Convert the entered values integer.
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is {2}  ", i, j, arr[i][j]);

                }
            }
            Console.ReadLine();
        }
    }

    //marks for 5 students 3 marks
    //int [,] arr = new int [5,3]

    //5 rows , each row has 3 cols
    //5 rows , each row has diff cols
    //array of arrays
    //int[] [] arr = new int [2][]  ====> jagged array-----here we are creating array of int array...i.e array within array.
    //arr[0] = new int [138];------this refers 1st element of that array with 138 members
    //arr[1] = new int [112];

    //0 -> [][][]...138 arrays total
    //1 -> [][][][][]....112 arrays total



}
