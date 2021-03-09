using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBasics
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();

            //o.i = 100;
            //o.i = 200;

            //Console.WriteLine(o.i);

            //o.SetI(100);
            //Console.WriteLine(o.GetI());

            o.P1 = 10; //acting like SetI above

            o.P2 = "a";

            Console.WriteLine(o.P2);
            Console.WriteLine(o.P1);

            //o.P1 = ++o.P1 + o.P1++ - o.P1-- - --o.P1;  
            //this is benifit of using setter getter in this way. increment decrement is easy


            //o.P3 = "new";  we cant assign anything to it, we can't do as P3 is read only i.e it has only get method
            Console.WriteLine(o.P3);

            o.P4 = 123;
            Console.WriteLine(o.P4);
            Console.ReadLine();
        }
        static void Main()
        {
            Class1 o;
            o = new Class1();

            Console.WriteLine();

            Class1 o2 = new Class1(100);
            Console.WriteLine(o.P1);
            Console.WriteLine(o2.P1);

            o = null;
            o2 = null;
            Console.ReadLine();
            GC.Collect();
            Console.ReadLine();
        }
    }
    public class Class1
    {
        #region Constructors
        public Class1()
        {
            Console.WriteLine("no param cons called");
            P1 = 5;
        }
        public Class1(int P1)
        {
            Console.WriteLine("int param cons called");
            this.P1 = P1;
        }
        #endregion
        ~Class1()
        {
            Console.WriteLine("DES");
        }

        #region Properties
        //public int i;
        private int i; 
        public void SetI(int x)
        {
            if (x < 100) //if this condition fails then i will be set to 0 as GetI is returning i.
                i = x;
            else
                //throw an exception here
                Console.WriteLine("invalid value");
        }

        public int GetI()
        {
            return i; 
        }

        //property
        private int p1; // This is called a 'Field'...Class level variables are called as fields.
        public int P1 // This is called a property.
        {
            set  //gets called when   o.P1 = 10;
            {
                //passed value is available as 'value'
                //value is taken as 10 here which is passed above in main
                //as above it is int P1 therefore 'value' will become int  
                if (value < 100)
                    p1 = value;
                else
                    Console.WriteLine("invalid P1");
            }
            get  //gets called when Console.WriteLine(o.P1);
            {
                return p1;
            }
        }

        private string p2;
        public string P2
        {
            get 
            { 
                return p2;
            }
            set 
            { 
                p2 = value; 
            }
        }
        //public string P2;   //--- field

        //read only property

        private string p3="Hello";
        public string P3
        {
            get 
            { 
                return p3; 
            }
           
        }

        //auto properties --> called so because if we don't provide fields then it takes on it's own
        public int P4 
        { 
            get;
            set; 
        }
        #endregion
    }
}
