using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Difference between Exception and Event is that Exception is critical, Event is non critical.
//Ref. diagram
//User over here has to do 3 things 1) To create the button object 2) Write the function on the button which has to be clicked 3) Pass the function to the programmer. 

namespace EventHandling1
{
    class Program
    {
        static void Main1()
        {
            //create an object of Class1
            Class1 objClass1 = new Class1();

            //Class1 objClass1 = new Class1(objClass1_InvalidP1);-----for line no 44 i.e by passing as a parameter

            //make the event (delegate object) point to the event handler function written by us
            objClass1.InvalidP1 += objClass1_InvalidP1; //giving the user a chance to enter values again by just displaying the message below

            //event is fired only if value >99
            objClass1.P1 = 1111;
            Console.ReadLine();
        }

        static void objClass1_InvalidP1()
        {
            Console.WriteLine("invalidP1 event code here"); //this message is given by the User...programmer has declared the Class1 with delegate InvalidP1EventHandler InvalidP1 is declared by him few years ago. User is just using it
        }
    }


    //step 1: create a delegate class having the same signature as the event handler function
    public delegate void InvalidP1EventHandler(); //any event should have a void return type as per the mentioned documentation & Parameters are decided by us with it 


    //programmer writes this class
    public class Class1
    {
        public Class1(InvalidP1EventHandler InvalidP1)
        {
            this.InvalidP1 += InvalidP1;
        }

        //step 2 : Declare the event of the delegate class type (delegate object)
        public event  InvalidP1EventHandler InvalidP1; //kept it public because it has to be called from outside of the class---'event as it is an event'

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //raise the event here-----if data in not valid we should raise an Exception, but over here just for demonstration we are throwing an event
                    //Step 3 : call the delegate object
                    InvalidP1(); //if it comes here then line no 21 gets called and from there line no 28 will get called as InvalidP1() is pointing to objClass1_InvalidP1() 
                }
            }
        }
    }
}

namespace EventHandling2
{
    class Program
    {
        static void Main2()
        {
            //create an object of Class1
            Class1 objClass1 = new Class1();

            //make the event (delegate object) point to the event handler function written by us
            objClass1.InvalidP1 += objClass1_InvalidP1;
            objClass1.InvalidP1 += Handler2;

            //event is fired only if value >99
            objClass1.P1 = 1111;

            Console.WriteLine();
            objClass1.InvalidP1 -= objClass1_InvalidP1;
            objClass1.InvalidP1 -= Handler2;
            objClass1.P1 = 1111;

            Console.ReadLine();
        }

        static void objClass1_InvalidP1()
        {
            Console.WriteLine("invalidP1 event code here");
        }
        static void Handler2()
        {
            Console.WriteLine("invalidP1 event code here also");
        }
    }


    //step 1: create a delegate class having the same signature as the event handler function
    public delegate void InvalidP1EventHandler();


    //programmer writes this class
    public class Class1
    {
        //step 2 : Declare the event of the delegate class type (delegate object)
        public event InvalidP1EventHandler InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //raise the event here
                    //Step 3 : call the delegate object
                    if(InvalidP1 != null)  //if no event handler funcs are assigned to the delegate object
                        InvalidP1();
                }
            }
        }
    }
}

namespace EventHandling3
{
    class Program
    {
        static void Main1()
        {
            ////create an object of Class1
            //Class1 objClass1 = new Class1();

            ////make the event (delegate object) point to the event handler function written by us
            //objClass1.InvalidP1 += objClass1_InvalidP1;

            ////event is fired only if value >99
            //objClass1.P1 = 1111;
            Console.ReadLine();
        }
        //static void objClass1_InvalidP1(int Value)
        //{
        //    Console.WriteLine("invalidP1 event code here");
        //    Console.WriteLine("value passed was : " + Value);

        //}

        static void Main()
        {
            Class1 obj = new Class1();
            obj.InvalidP1 += Obj_InvalidP1; //after += press TAB

        }

        private static void Obj_InvalidP1(int Value)
        {
            throw new NotImplementedException();
        }
    }


    //step 1: create a delegate class having the same signature as the event handler function
    public delegate void InvalidP1EventHandler(int Value); //with parameters


    //programmer writes this class
    public class Class1
    {
        //step 2 : Declare the event of the delegate class type (delegate object)
        public event InvalidP1EventHandler InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //raise the event here
                    //Step 3 : call the delegate object
                    if (InvalidP1 != null)
                        InvalidP1(value);
                }
            }
        }
    }
}
