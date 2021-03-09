using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//calling a method asynchronously using delObj.BeginInvoke(....
namespace AsyncCodeWithDelegates1
{
    class Program
    {
        static void Main1()
        {
            Console.WriteLine("Before");
            Action o = Display;
            o.BeginInvoke(null, null); //this will call the Display function asynchronously as it takes async as a parameter---above action is of no generic parameter. Therefore only null, null is passed in BeginInvoke which are by default values
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static void Display()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display");
        }
    }
}

//calling a method with parameters asynchronously using delegateObj.BeginInvoke(....
namespace AsyncCodeWithDelegates2
{
    class Program
    {
        static void Main2()
        {
            Console.WriteLine("Before");
            Action<string> o = Display;
            o.BeginInvoke("aaa", null, null); //since string is passed inside Action then BeginInvoke will take string as a parameter in it 
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static void Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//also using a callback func
namespace AsyncCodeWithDelegates3
{
    class Program
    {
        static void Main1()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display; //2nd string is of Display function
            o.BeginInvoke("aaa", CallBackFunc, null) ; //the 1st parameter of BeginInvoke is Async Callback which acts as a notifier that the task given has been completed---here we are defining the Callback function which is derived from IAsyncResult interface for giving us the messsage
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }
        
        static void CallBackFunc(IAsyncResult ar) //callback functions require certain parameters therefore we have provided IAsyncResult ar
        {
            Console.WriteLine("callback func called");
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//also using a callback func (as an anon method - to enable us to access objDel in the callback func) 
//get the return value with objDel.EndInvoke
namespace AsyncCodeWithDelegates4
{
    class Program
    {
         static void Main()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display; //1st string is of 'aaa', 2nd is of anonys class
            o.BeginInvoke("aaa", delegate(IAsyncResult ar) //using anonymous function as a callback here----benefit of anonymous methods is that we can access variables defined in the calling code i.e in the main function as it is declared in it('o' in our case)
                                                           //importing  here IAsyncResult ar through anonymous function and then returning the callback below
            {
                Console.WriteLine("callback func called");
                string retval = o.EndInvoke(ar); //to stop the async callback once the task is done
                Console.WriteLine("retval = " + retval); //we are returning the callback to o over here as EndInvoke(ar) is saved in retval
            }, null);
            
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }

        static void CallBackFunc(IAsyncResult ar) //we have passed 'IAsyncResult ar' here because callback inherits from this interface. Therefore the name of this interface is used above to return callback in EndInvoke(). Note: CallBackFunc is just a name of the function here and not the actual callback
        {
            Console.WriteLine("callback func called");
            //we have to end the callback by retuning it to the calling object in async functions i.e o over here
           //we needed to end callback here but we were not able to do that here because Func<...> o was not accessable here which is to whom we need to return the callback. Therefore we used anonymous(delegate) class object which provides us the previllage to access the variables of the calling function i.e Main
        }
    }
}


//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//using a callback func
//pass the delegate object as ar.AsyncState. This allows us to call delObj.EndInvoke to get the return value
namespace AsyncCodeWithDelegates5
{
    class Program
    {
        static void Main1()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display;
            //IAsyncResult ar = o.BeginInvoke("aaa", CallBackFunc, "extra data passed to callback func");-------as 3rd parameter was object, here we are passing the comment inside the object
            IAsyncResult ar = o.BeginInvoke("aaa", CallBackFunc, o); //we can also pass inbuilt delegate method in 3rd para i.e object-----here we are storing the state of callback in 'IAsyncResult ar' which is further passed in the CallBackFunc function because IAsyncResult has some properties. 
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }

        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
            //string extraData = ar.AsyncState.ToString();-----since the object of callback above is getting saved in ar.....then we can access ar here as well using 'AsyncState' which returns an object. Therefore 3rd para of line 128 will come here
            //Console.WriteLine(extraData);
            Func<string, string> o =(Func<string, string>) ar.AsyncState; //just like o in line 129, the last parameter is taken overhere as ar.AsyncState since last parameters can be returned in this. (Func<string, string>) is used for type casting here as it is string
            string retval = o.EndInvoke(ar);
            Console.WriteLine(retval);
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//also using a callback func  
//in the callback func get the delegate object as AsyncResult.AsyncDelegate. This allows us to call delObj.EndInvoke to get the return value
namespace AsyncCodeWithDelegates6
{
    class Program
    {
        static void Main1()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display;
            IAsyncResult ar = o.BeginInvoke("aaa", CallBackFunc, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }

        static void CallBackFunc(IAsyncResult ar)
        {
            AsyncResult result =(AsyncResult)ar;
            

            Console.WriteLine("callback func called");
            //Func<string, string> o = (Func<string, string>)ar.AsyncState;
            //string retval = o.EndInvoke(ar);
            //Console.WriteLine(retval);

            Func<string, string> o = (Func<string, string>)result.AsyncDelegate; //AsyncDelegate returns delagate as an object. Therefore 3rd parameter in line 163 is given null. Typecasting is done since it is an object type
            string retval = o.EndInvoke(ar);
            Console.WriteLine(retval);


        }
    }
}



//calling a method asynchronously using delObj.BeginInvoke(....
namespace AsyncCodeWithDelegates
{
    class Program
    {
        static void Main2()
        {
            Console.WriteLine("Before");
            Action o = Display;
            IAsyncResult ar = o.BeginInvoke(null, null);
            Console.WriteLine("After");

            //while (!ar.IsCompleted) ;----------here it will be checked everytime in a loop weather the callback is completed or not.
            //ar.AsyncWaitHandle.WaitOne();-----------waits for the thread to finish execution when done then it gets over. Like Thread.Join
            //Console.ReadLine();
        }
        static void Display()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display");
        }
    }
}