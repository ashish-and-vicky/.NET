using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main()
        {
            //int? i = 100;
            //Nullable<int> i = 100;


            //IntegerStack o = new IntegerStack(3);
            //o.Push(10);
            //o.Push(20);
            //o.Push(30);

            //Console.WriteLine(o.Pop());
            //Console.WriteLine(o.Pop());
            //Console.WriteLine(o.Pop());
            //Console.WriteLine(o.Pop());

            MyStack<int> o = new MyStack<int>(3); //Similar as above but with type int
            o.Push(10);
            o.Push(20);
            o.Push(30);

            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());


            MyStack<string> o2 = new MyStack<string>(3);
            o2.Push("1");
            Console.WriteLine(o2.Pop());



            Console.ReadLine();
        }
    }
    class IntegerStack
    {
        int[] arr;
        public IntegerStack(int Size)
        {
            arr = new int[Size];
        }
        int Pos = -1;
        public void Push(int i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public int Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
    class StringStack
    {
        string[] arr;
        public StringStack(int Size)
        {
            arr = new string[Size];
        }
        int Pos = -1;
        public void Push(string i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public string Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }


    //where T : class  - T must be a reference type
    //where T : struct - T must be a value type
    //where T : ClassName - T must be either ClassName or a derived class
    //where T : InterfaceName - T must be a class that implements InterfaceName
    //where T : new() - T must have a no parameter constructor

    //constraints can be combined. new() must appear at the end if new() is used
    //Rules for Defining Constrain:-
    //where T : ClassName, InterfaceName-----this means T should either be Employee class for eg....with compulsary Interface name in it
    //where T : ClassName, InterfaceName, new()
    class MyStack<T> 
      // where T : class----this is a constrain type which...as class is Reference Type, therefore T is taken as a Reference Type
    {
        T[] arr;
        public MyStack(int Size)
        {
            //T obj = new T();

            arr = new T[Size];
        }
        int Pos = -1;
        public void Push(T i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public T Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }

    //suppose if we want to use same fuction with different data types, then we write same function with different data types...to avoid that Generics are used
    //class MyOperations<T>
    //{
    //    public static void Swap(ref T i, ref T j)
    //    {
    //        T temp;
    //        temp = i;
    //        i = j;
    //        j = temp;
    //    }

    //}
    //class IntOperations
    //{
    //    public static void Swap (ref int i , ref int j)
    //    {
    //        int temp;
    //        temp = i;
    //        i = j;
    //        j = temp;
    //    }

    //}
    //class ShortOperations
    //{
    //    public static void Swap(ref short i, ref short j)
    //    {
    //        short temp;
    //        temp = i;
    //        i = j;
    //        j = temp;
    //    }

    //}
}
