using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 
1. Polymorphic behaviour
2. Contract between the interface and the class
3. Common interface for large projects
4. Design patterns
 
 */
namespace Interfaces1
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            //method 1-----this method is called Implicit reference
            o.Insert();
            o.Update();
            o.Delete();
            o.Display();

            Console.WriteLine();

            //method 2-----this method is called Explicit reference
            IDbFunctions oIDb;
            oIDb = o;
            oIDb.Delete();

            Console.WriteLine();

            //method 3-----this method is called TypeCast reference
            ((IDbFunctions)o).Delete();

            Console.ReadLine();
        }
    }
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public class Class1 : IDbFunctions //It becomes compulsory to implement all the methods of interface
    {
        public void Delete()
        {
            Console.WriteLine("Class1 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }
    }
}

namespace Interfaces2
{
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }

    public class Class1 : IDbFunctions //It becomes compulsory to implement all the methods of interface
    {
        public void Delete()
        {
            Console.WriteLine("Class1 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }
    }
    public class Class2 : IDbFunctions //It becomes compulsory to implement all the methods of interface
    {
        public void Delete()
        {
            Console.WriteLine("Class2 - IDb.Delete");
        }

        public void Show()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class2 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class2 - IDb.Update");
        }
    }
    class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            o1.Insert();
            Class2 o2 = new Class2();
            o2.Insert();

            //method 2
            IDbFunctions oIDb;
            oIDb = o1;
            oIDb.Insert();

            oIDb = o2;
            oIDb.Insert();
            Console.ReadLine();
        }
        static void Main2()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();
            InsertMethod(o1); // creating directly a function to call the interfaces.
            InsertMethod(o2);
            Console.ReadLine();
        }

        //this is general method, here we are passing the reference of interface to a seperate function insted of creating a seperate new object of class like above.
        static void InsertMethod(IDbFunctions oIDb) //oIDb = o1....or o2        
        {
            oIDb.Insert();
        }

    }

}

namespace Interfaces3
{
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete(); //this delete is also present in IDbFunctions therefore to use this we need to call it specifically/explicitly shown below..

    }
    public class Class1 : IDbFunctions, IFileFunctions //It becomes compulsory to implement all the methods of interface
    {
        void IDbFunctions.Delete() //for not confusing the compiler, we are explicitly calling the interfaces
        {
            Console.WriteLine("Class1 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }

        public void Close()
        {
            Console.WriteLine("Class1 - IFile.Close");
        }

        void IFileFunctions.Delete() // if we call explicitly, then they are private which we cam't change
        {
            Console.WriteLine("Class1 - IFile.Delete");
        }

        public void Open()
        {
            Console.WriteLine("Class1 - IFile.Open");
        }
    }
    public class MainClass
    {
        static void Main()
        {
            Class1 o = new Class1();

            o.Open();
            


            IFileFunctions oIFile; //therefore to call the delete of IFile specifically we use the method 2 of calling in main.
            oIFile = o;
            oIFile.Delete(); 

            //IDbFunctions....

            Console.ReadLine();
        }


    }
}

//TO DO : Inheritance in Interfaces