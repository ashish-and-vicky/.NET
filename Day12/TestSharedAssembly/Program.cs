using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JKSharedAssembly;

namespace TestSharedAssembly
{
    class Program
    {
        static void Main()
        {
            Class1 obj = new Class1();
            Console.WriteLine(obj.Hello());
            Console.ReadLine();
        }
    }
}
