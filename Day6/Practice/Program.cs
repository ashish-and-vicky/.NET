using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{

    public delegate void Del1();
    public delegate int DelAdd1(int a, int b);
    class Program
    {
        static void Main1(string[] args)
        {
            Del1 objDel = new Del1(Display);
            objDel();
            Console.ReadLine();
        }

        static void Main2(string[] arg)
        {
            Del1 d;
            d = new Del1(Display);
            d();
            Console.ReadLine();
        }

        static void Main3()
        {
            Del1 objDel;
            objDel = new Del1(Display);
            objDel();


            objDel += new Del1(Show);
            objDel();


            objDel += new Del1(Show);
            objDel();

            Console.ReadLine();
        }

        static void Main4(string[] args)
        {
            Del1 objDel = (Del1)Delegate.Combine(new Del1(Display), new Del1(Show));
            objDel();

            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Show));
            objDel();
            Console.ReadLine();

        }

        static void Main5()
        {
            DelAdd1 objDelAdd = new DelAdd1(Add);

            Console.WriteLine(objDelAdd(10,20));

            Console.ReadLine();
        }

        static void Main6()
        {
            Class2 objCls2 = new Class2();
            DelAdd1 objDel2 = objCls2.Add;

            Console.WriteLine(objDel2(10,20));
        }

        static void Main()
        {
            Console.WriteLine(PassMethodToCallAsAParameter(Add, 20, 10));
        }
        
        static void Display()
        {
            Console.WriteLine("Display is called");
        }

        static void Show()
        {
            Console.WriteLine("Show is called");
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static int PassMethodToCallAsAParameter(DelAdd1 delAdd, int a, int b)
        {
            return delAdd(a, b);
        }
    }
    public class Class2
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}


