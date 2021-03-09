using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main()
        {
			Class1 obj = new Class1(20, 100);
			obj[870] = 876;
			obj[101] = 200;
			obj[102] = 300;
			obj[103] = 400;
			obj[104] = 500;

            Console.WriteLine(obj[100]);
			Console.ReadLine();
		}
    }

	public class Class1
	{
		int[] arr;
		int startPos;
        public Class1(int size, int startPos)
        {
			arr = new int[size];
			this.startPos = startPos;
        }
		//Indexer
		public int this[int index] //suppose this was an integer of Employee array then it would have been 'public Employee this[int index]'
		{
			set
			{
				arr[index - startPos] = value; //we have done this because we want index to start from some position other than zero
			}
			get
			{
				return arr[index-startPos];
			}
		}
	}
}


/*
   public int this[int index]
		{
			set
			{
				arr[index] = value;
			}
			get
			{
				return arr[index];
			}
		}
 * 
 * Main(){
 * 
 *		Class1 obj = new Class();
 *		obj[0] = 10;	this [0] = 10;		obj.arr[0];-------------here obj[0] = 10; is getting internally converted to obj.arr[0]; actually -----we are achiving this in the top line of the function by this[int index]
 *		cw( obj[0] );		cw( obj.arr[0] )
 * 
 * }
 */