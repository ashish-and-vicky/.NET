using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Implicit Variables
namespace LanguageFeatures1
{
    class Program
    {
        static void Main1()
        {
            int i;
            var i2 = 100;  //implicit variable---depending on the right hand side the return type will be taken
            var i3 =(short) 100;  //implicit variable---inorder to update to a new datatype
            //Drawbacks of var:-
            //1) Used only for local variables
            //2) Can't be used for class level vars, fn params and return types
            //3) i2 = 200;
            Console.WriteLine(i2.GetType().ToString());
            Console.ReadLine();
            //var---can't be changed(datatype)
            //     -once assigned then return type can't be assigned
            //     -but can be updated to same datatypes
            //     -must have initial value while declaring 
           
        }
    }
}
//object initializers
namespace LanguageFeatures2
{
    public class Class1
    {
        public int i, j;
        public Class1()
        {
            i = 100;
            j = 200;
        }
        public Class1(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
    class Program
    {
        static void Main1() //OBJECT INITIALIZERS
        {
            
            Class1 o = new Class1();
            o.i = 123;
            o.j = 456;

            Class1 o2 = new Class1() { i = 123, j = 456 };  // Object Initializer
            Class1 o3 = new Class1 { i = 123, j = 456 };  // Object Initializer
            Class1 o4 = new Class1(10, 20) { i = 123, j = 456 };  // Object Initializer

        }
    }
}
//Types are of 5 types: 1) Class, 2) Struct, 3) Delegates, 4) Enums, 5) Interfaces
//Anonymous type
namespace LanguageFeatures3
{
    class Program
    {
        static void Main1() // ANONYMOUS TYPES
        {
            //Class1 o = new Class1();
            //Class1 o3 = new Class1 { i = 123, j = 456 };
            var myCar = new { Color = "Red", Model = "Ferrari", Version = "V1", CurrentSpeed = 75 }; //since these are anonymous types, here mycar is an object....and rest is same like above code

            var myCar2 = new { Color = "Blue", Model = "Merc", Version = "V2" };

            Console.WriteLine("{0} {1} {2} {3}", myCar.Color, myCar.Model, myCar.Version, myCar.CurrentSpeed);

            Console.WriteLine(myCar.GetType().ToString());
            Console.WriteLine(myCar2.GetType().ToString());

            Console.ReadLine();
        }
    }
}
//extension method
namespace LanguageFeatures4
{
    class Program
    {
        static void Main1()
        {
            int i = 123;
            i.Display();
            
            //Step 1: Create an Extension Class
            //Step 2: Create Static method within that static class
            //Step 3: In parameter write 'this' eg. (this int i)

            //i = i.Reverse();  //extension method example----An Extension method is a additionl method
            string s = "aaa";
            s.Show();
            s.Method2(10,20);
            Console.ReadLine();
        }
        static void Main2()
        {
            int i = 123;
           
            i.Display();
            MyExtensionMethods.Display(i); //internally this method is called for above line    
            i.ExtMet();

            string s = "aaa";
            s.Show();
            s.ExtMet();

            MyExtensionMethods.Show(s);
            //s.Method2(10, 20);
            Console.ReadLine();
        }

        static void Main3()
        {
            ClsMaths objClsMaths = new ClsMaths();

            Console.WriteLine(objClsMaths.Subtract(20,10)); //we got this because we have implemented IMathOperations in ClsMaths
            Console.ReadLine();
        }

        static int Reverse(int i)
        {
            int reverse = 0;
            ///code here
            return reverse;
        }
    }
    public static class MyExtensionMethods
    {
        //Note: extension method written for the base class is also available for the derived classs
        public static void ExtMet(this object i)  //here object means for the base class
        {
            Console.WriteLine(i);
        }
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }
        public static void Show(this string s)
        {
            Console.WriteLine(s);
        }
        public static void Method2(this string s, int i, int j)
        {
            Console.WriteLine(s);
        }

        //if you define an extension method for an interface, then it will be available to all the classes that implement that interface
        
        public static int Subtract(this IMathOperations i, int a, int b) //Now we will be able to call this method in Main
        {
            return a - b;
        }
    }


    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }
    public class ClsMaths : IMathOperations
    {
        
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
//partial classes
namespace LanguageFeatures5
{
    //PARTIAL CLASSES---One class put up in multiple parts seperately
    //Rules:-
    //partial classes must be in the same assembly
    //partial classes must be in the same namespace
    //partial classes must have the same name


    public partial class Class1
    {
        public int i;
    }
   
    public class Program
    {
        public static void Main1()
        {
            Class1 o = new Class1();
            
           
        }
    }
}
namespace LanguageFeatures5
{
    public partial class Class1
    {
        public int j;
    }
}

//partial methods
namespace PartialMethods
{
    public class MainClass
    {
        public static void Main()
        {
            Class1 o = new Class1();
            Console.WriteLine(o.Check());
            Console.ReadLine();
        }
    }

    //Partial methods can only be defined within a partial class.
    //Partial methods must return void.
    //Partial methods can be static or instance level.
    //Partial methods cannnot have out params
    //Partial methods are always implicitly private.
    public partial class Class1
    {
        private bool isValid = true;
        partial void Validate();
        public bool Check()
        {
            //.....
            Validate(); //we are reserving a space in this part for some one to add any code  in sometime over here
            return isValid;
        }
    }

    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            isValid = false; //Now nobody will be able to add any code now
        }
    }

}
