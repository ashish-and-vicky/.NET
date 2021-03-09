using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpOverloadingEg
{
    class Program
    {
        static void Main()
        {
            Class1 o = new Class1 { i = 10 };
            Class1 o1 = new Class1 { i = 20 };
            Class1 o2 = new Class1 { i = 30 };

            o = o + 5;
            o = o1 + o2;
            o= ++o;
            Console.WriteLine(o.i);
            Console.ReadLine();
        }
    }

    public class Class1
    {
        public int i;
        public static Class1 operator+(Class1 o, int i)
        {
            Class1 retval= new Class1();
            retval.i = o.i + i;
            return retval;
        }
        public static Class1 operator +(Class1 o1, Class1 o2)
        {
            Class1 retval = new Class1();
            retval.i = o1.i + o2.i;
            return retval;
        }
        public static Class1 operator ++(Class1 o1)
        {
            Class1 retval = new Class1();
            retval.i = ++o1.i ;
            return retval;
        }

    }
}
