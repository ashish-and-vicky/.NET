using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BasicClassConcepts
{
    class Program
    {
        static void oldMain()
        {
            //System.Console.WriteLine("Hello World");
            Console.WriteLine("aa");
            Console.ReadLine();

           //System.Data.DataSet ds = new System.Data.DataSet();
        }
        static void Main()
        {
            //Class1 o;   // o is a reference of type Class1
            //o = new Class1();  // allocate memory for an object of type Class1 and make o point to it

            Class1 o = new Class1();
            o.Display();
            o.Display("Vik");

            //positional parameters
            Console.WriteLine(o.Add(10, 20, 30, 40));
            Console.WriteLine(o.Add(10, 20, 30));
            Console.WriteLine(o.Add(10, 20));
            Console.WriteLine(o.Add(10));
            Console.WriteLine(o.Add());
            Console.WriteLine(  );

            //named parameters
            Console.WriteLine(o.Add(d: 40));
            Console.WriteLine(o.Add(c: 30));
            Console.WriteLine(o.Add(d:40, c: 30));


            //Console.WriteLine(o.Add2(d: 40)); Here we need to enter all the values
            //Console.WriteLine(o.Add2(a: 40));
            Console.WriteLine(o.Add2(d: 40, c: 30, a: 20, b:10));
            Console.ReadLine();
        }
    }
    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }

        //func overloading
        public void Display(string s)
        {
            Console.WriteLine("Display" + s);
        }


        //optional parameters with default values
        public int Add(int a= 0, int b= 0, int c= 0, int d=0)
        {
            return a + b + c + d;
        }
        //public int Add(int a, int b, int c)
        //{
        //    return a + b + c ;
        //}
        //public int Add(int a, int b)
        //{
        //    return a + b ;
        //}
        public int Add2(int a , int b, int c, int d )
        {
            return a + b + c + d;
        }
    }
}

namespace n2
{
    class C3
    {
       
    }
    class Class2
    {

    }
    namespace n3
    {
        class class4
        {

        }
    }
}
