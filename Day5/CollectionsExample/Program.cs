using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExample
{
    class Program
    {
        static void Main()
        {
            ArrayList objArrayList = new ArrayList(); //as soon as the word Collection...Add, Remove, Count should strike your mind
            objArrayList.Add(10);
            objArrayList.Add("aaa");
            objArrayList.Add(10.5);
            objArrayList.Add(true);

            Console.WriteLine(objArrayList.Count);
            objArrayList.Remove("aaa");
            objArrayList.RemoveAt(0);

            foreach (object  o in objArrayList) //here object defines object type
            {
                Console.WriteLine(o);
            }
            //objArrayList.AddRange(obj2)---here eg we want to add second array list

            //objArrayList.Capacity = 100;------it maintains a container. If while adding values to that container suppose the values increase as compared to the container then a new block of 100 comes...
            //objArrayList.TrimToSize();---------therefore to remove those extra spaces, this is used

            //objArrayList.Clear
            // bool isThere = objArrayList.Contains(10);-----if 10 is found then it returns true 
            //objArrayList.CopyTo(arr)------it allows to copy an ArrayList to an array
            //objArrayList.Insert(0, "aa");
            //objArrayList.InsertRange
            //objArrayList.RemoveRange
            //object[] arr = objArrayList.ToArray();----it returns an object in array
            //objArrayList.BinarySearch
            //objArrayList.IndexOf
            //objArrayList.LastIndexOf

            Console.ReadLine();
        }
    }
}







namespace CollectionsExample2
{
    class Program
    {
        static void Main1()
        {
            ArrayList objArrayList = new ArrayList();
            objArrayList.Add(10);
            objArrayList.Add("aaa");
            objArrayList.Add(10.5);
            objArrayList.Add(true);

            Console.WriteLine(objArrayList.Count);
            objArrayList.Remove("aaa");
            objArrayList.RemoveAt(0);

            foreach (object o in objArrayList)
            {
                Console.WriteLine(o);
            }
            //objArrayList.AddRange(obj2)

            //objArrayList.Capacity = 100;
            //objArrayList.TrimToSize()

            //objArrayList.Clear
            // bool isThere = objArrayList.Contains(10);
            //objArrayList.CopyTo(arr)
            //objArrayList.Insert(0, "aa");
            // objArrayList.InsertRange
            //objArrayList.RemoveRange
            //object[] arr = objArrayList.ToArray();
            //objArrayList.BinarySearch
            //objArrayList.IndexOf
            //objArrayList.LastIndexOf

            Console.ReadLine();
        }

        static void Main2()
        {
            //Hashtable objDictionary = new Hashtable();-----in HashTable, the order of insertion is not maintained i.e elements are added anywhere....to do that we should use a SortedList
            SortedList objDictionary = new SortedList(); // maintains insertion order one by one
            objDictionary.Add(10, "abc");
            objDictionary.Add(20, "pqr");
            objDictionary.Add(30, "xyz");

            objDictionary[30] = "new value";// it will update the value at key = 30 above
            objDictionary[40] = "aaaaaaa"; // as this key does not exist above...then it will create it

            objDictionary.Remove(2); // will remove at key 2

            Console.WriteLine(objDictionary.GetByIndex(0));

            //ArrayList objKeys =(ArrayList) objDictionary.GetKeyList();-------GetKeyList() will return list of keys to objKeys which is ArrayList, but it has to be typecasted in ArrayList because operations are done in SortedList

            //TO DO : Try the Dictionary methods


            Console.WriteLine();
            foreach (DictionaryEntry de in objDictionary)
            {
                Console.WriteLine(de.Key);
                Console.WriteLine(de.Value);

            }

            Console.ReadLine();
        }

        static void Main3()
        {
            Stack objStack = new Stack();
            objStack.Push(1000);
            objStack.Push(2000);
            objStack.Push(3000);
            Console.WriteLine(objStack.Peek());

            Console.WriteLine(objStack.Pop());

            Queue objQ = new Queue();
            objQ.Enqueue(1111);
            Console.WriteLine(objQ.Peek());

            Console.WriteLine(objQ.Dequeue());


        }

        static void Main4()
        {
            List<int> objList = new List<int>();
            objList.Add(10);
            foreach (int x in objList)
            {
                Console.WriteLine(x);
            }
        }
        static void Main5()
        {
            SortedList<int, string> objDictionary = new SortedList<int, string>(); //key, value pair
            objDictionary.Add(10, "aaa");
            objDictionary[20] = "bb";

            foreach (KeyValuePair<int, string> kvp in objDictionary) //for setting key, value pair in Generic types...just like in line no. 115
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value);
            }
        }
        //TO DO --> try Stack<T> and Queue<T>

        static void Main6()
        {
            List<Employee> objEmps = new List<Employee>();
            //Employee obj = new Employee();
            //obj.EmpNo = 1;
            //obj.Name = "V";
            //obj.Basic = 12345;
            //obj.DeptNo = 10;
            //objEmps.Add(obj);

            //object initializer
            objEmps.Add(new Employee { EmpNo = 1, Name = "V", Basic = 12345, DeptNo = 10 }); // The above lines of code were too long so we used this....here 'new Employee' is calling a constructor.
            objEmps.Add(new Employee { EmpNo = 2, Name = "S", Basic = 12345, DeptNo = 10 });
            objEmps.Add(new Employee { EmpNo = 3, Name = "H", Basic = 12345, DeptNo = 10 });
            objEmps.Add(new Employee { EmpNo = 4, Name = "A", Basic = 12345, DeptNo = 10 });
            objEmps.Add(new Employee(5, "new") { Basic = 12345, DeptNo = 10 }); // this is calling line no. 225..and Basic, DeptNo is calling the set method
            //above line is an eg of object initializer and calling a parameterized constructor

            foreach (Employee obj in objEmps)
            {
                Console.WriteLine(obj.Name);
            }
        }
        static void Main7()
        {
            SortedList<int, Employee> objEmps = new SortedList<int, Employee>(); //since we are taking EmpNo here as key... we have kept <int> in it.
            objEmps.Add(1, new Employee { EmpNo = 1, Name = "V", Basic = 12345, DeptNo = 10 });
            objEmps.Add(2, new Employee { EmpNo = 2, Name = "S", Basic = 12345, DeptNo = 10 });
            objEmps.Add(3, new Employee { EmpNo = 3, Name = "H", Basic = 12345, DeptNo = 10 });
            objEmps.Add(4, new Employee { EmpNo = 4, Name = "A", Basic = 12345, DeptNo = 10 });

            foreach (KeyValuePair<int, Employee> kvp in objEmps)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value.Name);
            }

        }
        static void Main()
        {
            //List<Employee> objEmps = new List<Employee>();
            Employees objEmps = new Employees(); //as we want to make the above line code to be written in this format...we have created class of Employees i.e line no 212 with List of Employee

        }
    }
    public class Employees : List<Employee>
    {
        //we can add some more elements in this list here
    }

    //TO DO : Try creating Employees class based on SortedList<...>...here if we want to create this..line 212 needs to be written with <int, Employee>
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }

        public Employee(int EmpNo = 1, string Name = "aaa")
        {
            this.EmpNo = EmpNo;
            this.Name = Name;
        }
    }
}


/*
 Boxing 

int i = 100;
object o;
o = i; //BOXING------as 'o' is reference type and 'i' is value type therefore i is formed in Heap memory...so as o is refering to i, then o is also placed in heap.

//storing a value type into a reference type is called BOXING a value type

//the value type on the stack is copied to the heap and a ref to that is created.


Unboxing

int j;
j = (int)o; //UNBOXING
//Getting the value from a  boxed reference type is called Unboxing

//the boxed value is copied from the heap to the stack

 */