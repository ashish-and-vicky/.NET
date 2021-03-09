using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main()
        {
            //short? s = 0;

            int? i = 10; // ? for assigning value to null variable
            //Nullable<int> i = 10;----this is behind the scenes of the above code

            //i = null;---as directly it can't be assigned

            int j = 0;
            if (i != null)
                j = (int)i; // as j is of type 'int' and i of null so type casting is needed.
            else
                j = 0;

            if (i.HasValue) // means if i is not null 
                j = i.Value;
            else
                j = 0;

            j = i.GetValueOrDefault(); //here by default value of i is '0'
            j = i.GetValueOrDefault(10); // here we have overloaded the default value as '0'
            j = i ?? 10;  //null coalescing operator...same as the above line
            Console.WriteLine(j);


            Console.ReadLine();
        }
    }
}
