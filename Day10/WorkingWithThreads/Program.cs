using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//Note: All Threads by default are Foreground Threads.
      //Threads do not have a callback value. Therefore we have to use delegates for that.

namespace WorkingWithThreads
{
    class Program
    {
        static void Main1()
        {
            Thread t1 = new Thread(new ThreadStart(Func1)); //Thread is a inbuilt delegate class---ThreadStart is also a class that takes 'void Functions' as a parameter------Threads are alloted so as they can process seperate execution i.e Asynchronous Execution without stopping/waiting the other
            Thread t2 = new Thread(Func2); //the above code is just the demonstration that in Thread class delegate, internally ThreadStart runs....otherwise function can also be directly be passed in Thread
            //t1.Priority = ThreadPriority.Highest;------threads can also be runned with priority of which to be executed 1st or last
            //t1.IsBackground = true;-----to run thread in background state
            //t2.IsBackground = true;   
            t1.Start(); //to run the thread we need to start it by using Start()
            t2.Start();

            //t1.Abort();----to stop running the process

            //instead of suspend, use this
            WaitHandle wh = new AutoResetEvent(false); //insted of suspend which is not allowed in ThreadState, use this
            wh.WaitOne(); //it is like a join----insted of using a suspend we are doing a join

            //instead of resume, use this
            ((AutoResetEvent)wh).Set(); //insted of resume which is not allowed in ThreadState, use this
           


            //t1.IsAlive-----tells if a thread is running or not
            //t1.Join(); -----Wait for the thread to complete. The is a waiting call----here unless thread 1 is over, next thread one will not execute

            //t1.Name();-----to give name to a thread

            //if( t1.ThreadState == ThreadState.

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
                //Thread.Sleep(1000);
            }
            //Console.ReadLine();
           
        }
        static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First : " + i);
                //Thread.Sleep(1000);-----pauses execution of the thread
            }
            
        }
        static void Func2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second : " + i);
                //Thread.Sleep(1000);
            }
        
        }
    }
}


namespace ThreadingExamples2
{
    class Program1
    {
        static void Main2()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1)); //ParameterizedThreadStart is the function which we are calling has a parameter
            //Thread t2 = new Thread(new ParameterizedThreadStart(Func2));
            Thread t2 = new Thread(Func2);
            t1.Start("o1"); //now we are able to pass the values
            t2.Start("o2");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            Console.ReadLine();
        }

        //TO DO : Pass 2 values to the func.
        //Hint : Create a class that has 2 properties and pass an object of the class
        static void Func1(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Thread " + i.ToString() + o.ToString());
            }
        }
        static void Func2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString() + o.ToString());
            }
        }
    }
}



//ThreadPool
namespace ThreadingExamples3
{
    class MainClass
    {
        static void PoolFunc1(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Thread " + i.ToString() + o.ToString());
            }
        }
        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString());
            }
        }
        static void Main()
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1), "aaa");
            ThreadPool.QueueUserWorkItem(PoolFunc1, "aaa");
            ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc2));


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }


            int workerthreads, iothreads;

            ThreadPool.GetAvailableThreads(out workerthreads, out iothreads); //shows the threads which are available for use----we are using workerthreads, iothreads are used for input output
            //ThreadPool.SetMinThreads----we can even set the max and min threads
            //ThreadPool.SetMaxThreads
            //ThreadPool.GetMinThreads
            Console.WriteLine(workerthreads);
            Console.WriteLine(iothreads);

            Console.ReadLine();
        }
    }
}


//Synchronization
namespace Eg3
{
    class MainClass
    {
        static object lockObject = new object(); //lockObject acts like a token here-----as soon as it is found in another method, then it will start execution from there----it is only available in C#----in other .NET languages it is Monitor.Enter/Monitor.Exit. Therefore 'lock' is used to maintain sync between 2 functions
        static int i = 0;
        static void Main4()
        {
            Thread t1 = new Thread(new ThreadStart(FuncLock));
            //Thread t2 = new Thread(new ThreadStart(FuncMonitor));
            //Thread t3 = new Thread(new ThreadStart(FuncInterlocked));
            t1.Start();
            //t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            Console.WriteLine("Finished Main");
            Console.ReadLine();
        }
        static void FuncLock()
        {
            lock (lockObject) //Monitor.Enter(lockObject)
            {
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
            }
        }

        static void FuncMonitor()
        {
            Monitor.Enter(lockObject);
            {
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
            }
            Monitor.Exit(lockObject);

        }

        static void FuncInterlocked() //Interlocked is also a method to achive sync-------internally it uses a lock statement to achive sync----it was designed so that we don't need to put lock statement again and again
        {

            Interlocked.Add(ref i, 10);   //i+=10
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Increment(ref i); //++i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Decrement(ref i); //--i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Exchange(ref i, 100); //i = 100;
            Console.WriteLine("Third Interlocked " + i.ToString());
        }

    }
}