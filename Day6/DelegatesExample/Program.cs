using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Delegate means assigning a task to someone or something else.....we are creating it here because in some cases we won't be allowed to call the functions directly

//Delegate Hierarchy:-

//Object----
//Delegate----
//MultiCastDelegate----this inherits from the above Delegates----it casts to multiple functions at the same time
//Del1----it inherits from the above code
namespace DelegatesExample
{
    //for calling Delegates---- Step 1 : create a delegate class having the same signature as the function to call

    public delegate void Del1(); //return type of delegates is 'void' only as per its documentation

    public delegate int DelAdd(int a, int b);
    class Program
    {
        static void Main1()
        {
            //Display();
            //step 2 : create a delegate object passing the function name as a parameter.
            Del1 objDel = new Del1(Display);

            //step 3 : call the func via the delegate object
            objDel(); //it actually goes and call display

            Console.ReadLine();
        }
        static void Main2()
        {
            Del1 objDel;
            objDel = new Del1(Display);
            objDel();

            objDel = new Del1(Show);
            objDel();
            Console.ReadLine();
        }

        static void Main3()
        {
            Del1 objDel;
            objDel = new Del1(Display);
            objDel();


            Console.WriteLine();
            Console.WriteLine();
            objDel += new Del1(Show); // the '+' sign adds the show method to the the display method i.e '+' adds to the previous delegate
            objDel(); // if we had parameters then the same parameters will be passed to the different calls


            Console.WriteLine();
            Console.WriteLine();
            objDel += new Del1(Display);
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            objDel -= new Del1(Display); // the '-' sign subtracts the Display to the the display method...i.e it removes the last or latest added element which is at line no 61
            objDel();

            Console.ReadLine();
        }

        static void Main4()
        {
            Del1 objDel;
            objDel = Display; // by using delegates this task becomes easy
            objDel();


            Console.WriteLine();
            Console.WriteLine();
            objDel += Show;
            objDel();


            Console.WriteLine();
            Console.WriteLine();
            objDel += Display;
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            objDel -= Display;
            objDel();

            Console.ReadLine();
        }

        static void Main5()
        {
            Del1 objDel = (Del1)Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display)); //combination of delegates from different functions...typecasting is done because delegate is defined as a class above
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            //objDel = (Del1)Delegate.Remove(objDel, new Del1(Display)); ------means objDel ka last added display will get removed
            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Display)); //will remove all Display functions
            objDel();

            Console.ReadLine();
        }

        static void Main6()
        {
            //DelAdd objDelAdd = new DelAdd(Add);---this is one method to call or...
            DelAdd objDelAdd = Add; //by directly writing the function code...or

            Console.WriteLine(objDelAdd(10,20)); //by passing values if we want to...by defining a structure
            // TO DO : Try multicast delegates with parameters and a return value

            Console.ReadLine();
        }

        static void Main7()
        {
            //DelAdd objDelAdd = new DelAdd(Add);----for calling from same class
            //DelAdd objDelAdd = Class2.Add;   //if static----and for calling from another class
            Class2 objCls2 = new Class2();
            DelAdd objDelAdd = objCls2.Add;   //if not static then creating an object


            Console.WriteLine(objDelAdd(10, 20));
            // TO DO : Try multicast delegates with parameters and a return value

            Console.ReadLine();
        }
        static void Main()
        {
            //Console.WriteLine(PassMethodToCallAsAParameter(new DelAdd(Add), 20, 10));
            Console.WriteLine(PassMethodToCallAsAParameter(Add, 20, 10)); 
            Console.WriteLine(PassMethodToCallAsAParameter(Subtract, 20, 10));
            Console.WriteLine(PassMethodToCallAsAParameter(Multiply, 20, 10));
            Console.ReadLine();
        }
        static void Display()
        {
            Console.WriteLine("disp");
        }
        static void Show()
        {
            Console.WriteLine("show");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static int PassMethodToCallAsAParameter(DelAdd objDelAdd,int a, int b)//objDelAdd = Add, a = 20, b = 10
        {
            return objDelAdd(a, b);
        }
    }
    public class Class2
    {
        public  int Add(int a, int b)
        {
            return a + b;
        }
    }
}

