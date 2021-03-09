using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks; //Tasks consist of all the properties of threads and is a enhansed version of threads

//calling a method with void return type using taskobj.Start

namespace Example1
{
    class Program
    {
        static void Main1()
        {

            Action objAction1 = Func1;
            Task t1 = new Task(objAction1); //Task is passed using 'Task' keyword
  

            //Task t3 = new Task(new Action(Func1));
            //Task t4 = new Task(Func1);

            Action objAction2 = Func2;
            Task t2 = new Task(objAction2);

            t1.Start(); //to start the task we require .Start()-----but it needs to be started externally
            t2.Start();

            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("first Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("second Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

//calling a method with void return type using Task.Run and Task.Factory.StartNew
namespace Example2
{
    class Program
    {
        static void Main2()
        {
            Action objAction1 = Func1;
            Task t1 = Task.Run(objAction1); //here we don't require to start the tasks early 


            Action objAction2 = Func2;
            Task t2 = Task.Factory.StartNew(objAction2); //it is similar to Task.Run()

            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("first Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("second Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

//calling a method with void return type and parameters 
namespace Example3
{
    class Program
    {
        static void Main1()
        {

            Action<object> objAction1 = Func1;
            Task t1 = new Task(objAction1, "aaa");

            //Task.Run - cannot be used with parameters. 
            //use anonymous methods instead to access variables declared in calling code i.e Main

            string s = "aaa";
            Task.Run(delegate () { Console.WriteLine(s); });

            Action<object> objAction2 = Func2;
            Task t2 = Task.Factory.StartNew(objAction2, "bbb");

            t1.Start();
            //t2.Start();



            Console.ReadLine();
        }
        static void Func1(object obj)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("first Func called {0}{1}", i, obj.ToString());
            }
        }
        static void Func2(object obj)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("second Func called {0},{1}", i, obj.ToString());
            }
        }
    }
}

//calling methods with return type 
namespace Example4
{
    class Program
    {
        static void Main4()
        {

            Func<int> objFunc1 = Func1;
            Task<int> t1 = new Task<int>(objFunc1); //if a method has a return type...then unlike simple 'Task' we use insted 'Task<int>'----Task<int> internally takes parameter as Func<int> because of its acceptance of all datatypes behaviour

            t1.Start();

            Func<object, int> objFunc2 = Func2;
            Task<int> t2 = new Task<int>(objFunc2, "bbb");
            t2.Start();
           

            if (!t1.IsCompleted)
                t1.Wait(); //in Tasks, insted of WaitOne() like threads, we have Wait overhere
            Console.WriteLine(t1.Result); //here Result is returning as <int> because Task is returning string above

            if (!t2.IsCompleted)
                t2.Wait();
            Console.WriteLine(t2.Result);

            Console.ReadLine();
        }
        static int Func1()
        {
            int i;
            for (i = 0; i < 1000; i++)
            {
                Console.WriteLine("first Func called {0}", i);
            }
            return i;
        }
        static int Func2(object obj)
        {
            int i;
            for (i = 0; i < 1000; i++)
            {
                Console.WriteLine("second Func called {0},{1}", i, obj.ToString());
            }
            return i;
        }
    }
}



