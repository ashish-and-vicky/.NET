using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Reference Types - All classes and their variants are Ref Types
All classes, interfaces, delegates, arrays, object class, and the string class are reference types
Memory for the object is allocated on the Heap, the reference is allocated on the stack

Value Types - All structs and their variants are Value Types
All structs and enums are Value Types (enum is internally int and int is a struct)
Memory allocation is on the stack
 */
namespace RefAndValueTypes
{
    class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 200;
            o1 = o2; //o1 is pointing to the address of o2.....as classes Reference Types and are defined above of o1, o2 as reference.
            o2.i = 300;
            Console.WriteLine(o1.i);
            Console.WriteLine(o2.i);
            //300,300------the o/p of the above code is this...because Classes act as a reference i.e they point to an address and not the actual data.
            Console.ReadLine();
        }

        static void Main2()
        {
            int o1, o2;
            o1 = 100;
            o2 = 200;
            o1 = o2;
            o2 = 300;
            Console.WriteLine(o1);
            Console.WriteLine(o2);

            Console.ReadLine();
        }

        static void Main3()
        {
            string o1, o2;
            o1 = "100";
            o2 = "200";
            o1 = o2; // o1 now creats another block of memory or object and points to it(200)...it dosen't points to the same object of o2.
                     // This is a modification from C++ to avoid Dangling Pointers.
            o2 = "300";
          
            //300,300
            //200,300----because string is immutable so it takes it as an object. Therefore string behaves like Value Yype

            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.ReadLine();
        }

        static void Main4()
        {
            int i;
            int j;

            Init(out i, out j);
            //Swap(ref i, ref j);------here the swapped values will be appeared as its reference is passed i.e address of where its is swapped.
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.ReadLine();
        }
        static void Swap(ref int i, ref int j) //ref is used to pass the address where after the values are swapped...because if we write...static void Swap(int i, int j) then the values will get swapped only in this Swap block.
        {
            int temp = i;
            i = j;
            j = temp;

        }

        //out is similar to ref - changes made in func reflect back in calling code...if we would have passed ref, then it was telling to declare initial values of i & j...by using out we don't require that. 
        static void Init(out int i, out int j)
        {
            //if initial value is provided then the initial value is discarded
            // Console.WriteLine(i);----here we can't print because the initial values are discarded.
            i = 100;
            j = 200;
            //out variables MUST be initialized in the function
        }

        static void Main()
        {
            Class1 o = new Class1();
            o.i = 100;
            //DoSomething1(o);
            //DoSomething2(o);
            DoSomething3(ref o);

            Console.WriteLine(o.i);
            Console.ReadLine();
        }
        //reference type - changes made in func reflect back in calling code
        static void DoSomething1(Class1 obj) //obj =o....as in main function 'o' is passed in DoSomething...therefore o/p is 200 here
        {
            obj.i = 200;
        }
        //reference type - if new object is created, the calling code(Main) does not point to the new object
        static void DoSomething2(Class1 obj) //obj = o
        {
            
            obj = new Class1(); // Now this is pointing to a new object whose value is 200
            obj.i = 200;
        }
        //reference type passed as ref - if new object is created, the calling code(Main) points to the new object, but if we want that 'o'( in Main ) should point to a new object then 'ref' is passed.
        static void DoSomething3(ref Class1 obj) //obj = o
        {
            obj = new Class1();
            obj.i = 200;
        }
        static void DataTypes()
        {
            // datatypes in .NET gets converted into CTS (Common Type System) to avoide if code is written in different language problem.
            byte b1;
            sbyte b2;
            char ch; // char is 2 byte value because of unicode
            short sh1;
            ushort sh2;
            int i1; //System.Int32 //4
            uint i2;//System.UInt32 //4
            long l1;
            ulong l2;
            float f;
            double d;
            decimal d2; // for using highest precision in the o/p
            bool b;

            string s;
            object o;

        }
    }

    public class Class1
    {
        public int i;
    }
}
