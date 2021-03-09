using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableExample
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();

            o.Display();

            o.Dispose();

            o.Display();

            Console.ReadLine();
        }
        static void Main()
        {
            using (Class1 o = new Class1()) // using is added to implement Display() & Dispose() together....which means destructor will not be called up before all the functions are runned
                                           // Note: Destructor is a function which gets called when memory is freed...it itself does not free the memory
            {
                o.Display();
            }
            Console.ReadLine();
        }
    }

    public class Class1 : IDisposable // IDisposable is used as a Destructor to free up memory 
    {
        public void Display()
        {
            CheckForDisposed();
            Console.WriteLine("Display");
        }

        private void CheckForDisposed()
        {
            if (isDisposed)
                throw new ObjectDisposedException("Class1");
        }

        private bool isDisposed=false; // we are doing this because in case if we don't want to call Display function after Dispose method in the Main above
                                      // initially the value of bool is false

        public void Dispose()
        {
            Console.WriteLine("dispose called free resources here");
            isDisposed = true;
        }
    }
}
