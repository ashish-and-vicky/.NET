using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

//Reflection is used to display the assembly(classes, methods, parameters etc inside a assembly)
namespace ReflectioExample
{
    class Program
    {
        static void Main()
        {
            //D:\Trainings\JKDec20\Day2\ClassBasics\bin\Debug
            Assembly asm = Assembly.LoadFrom(@"D:\Trainings\JKDec20\Day2\ClassBasics\bin\Debug\ClassBasics.Exe"); //used to load the assembly from a file


            //Console.WriteLine(asm.FullName);
            Console.WriteLine(asm.GetName().Name);

            Type[] arrTypes = asm.GetTypes(); 
            foreach ( Type t in arrTypes) //as we want name of all the classes here and class is a Type, hence Type is taken in foreach
            {
                Console.WriteLine("    " + t.Name); //.Name property prints all the name of the properties
                MethodInfo[] arrMethods = t.GetMethods(); //to get all the methods
                foreach (MethodInfo m in arrMethods) //since we want Methods which are defined inside a class we are using MethodInfo----take the mouse over to know to which assembly it belongs
                {
                    Console.WriteLine("        " +m.Name);
                   ParameterInfo[] para = m.GetParameters();
                    foreach (ParameterInfo p in para)
                    {
                        Console.WriteLine("        " +m.Name);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
