using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Web Services:-

Data - XML --------------------------means in WS data will go in the form of XML
Envelope - SOAP
Communication - HTTP
 


While extracting information from the Envelope, the information has to be extracted from SOAP using HTTP in the form of XML

WebService Description Language:-

.Wsdl - The things mentioned in this is that it describes of how, when, what should the message be sent, what are the methods in that WebService, the para in that method, its I/O methods
 
- the consumer needs to add a reference of libraries to itself in order to read th data comming from SOAP
- that .Wsdl file needs to be physically copied to the client location, he web ref. libraries then read the data from it


To Create a WebSevice:-

Create a new project---ASP.NET---select Web Forms in the right---Create---
- Now we need to create a class with a method in it and mark it as a Attribute of that method that will be available from the service-

--Goto Project above---in Web in left---search for Web Service (ASMX)---Add---
//-----------------------------------------------------------------------------------------------------------------------------------------------------
 
/*
Now to create a client, we are now going to add a Console App--

        Right click in the right at top in Solution Explorer---Add a new project---select Console App(.Net Framework)---(ClientForWs) over here---
        - Now we need to add a reference to it---in Solution Explorer right click on ClientForWs---Add---Service Reference---a pop up will open---in the bottom click Advanced---in the bottom click Add a Reference---a pop up will open---
          select Web services in this solution---Select the webService here---in the right---Add Reference---this will copy the .Wsdl file in itself and create a Proxy Class(in Web Reference folder localhost is added)---
*/
namespace ClientForWS
{
    class Program
    {
        static void Main1()
        {
            localhost.WebService1 objService = new localhost.WebService1(); //here we are accessing that localhost
            Console.WriteLine(objService.HelloWorld()); //calling that object of HelloWorld form my MyWebService called as Proxy class----when we run this then 'Hello World' O/P will be shown
            Console.WriteLine(objService.Add(10, 20)); //calling another method of from the Web Service 'WebService1' we created
            Console.ReadLine();
        }
        //Threading
        static void Main()
        {
            localhost.WebService1 objService = new localhost.WebService1();
            Console.WriteLine("Before");
            //Console.WriteLine(objService.LomgRunningMethod());

            objService.LomgRunningMethodCompleted += ObjService_LomgRunningMethodCompleted; //Tab + Tab
            objService.LomgRunningMethodAsync(); //when async call gets completed---it then it calls the above completed method after that----a thread of seperate process is created here

            Console.WriteLine("After");
            Console.ReadLine();
        }

        private static void ObjService_LomgRunningMethodCompleted(object sender, localhost.LomgRunningMethodCompletedEventArgs e) //this method is created by Tab+Tab
        {
            Console.WriteLine(e.Result);
        }

        static void Main3() //this method is similar to above async method just in different format
        {
            localhost.WebService1 objService = new localhost.WebService1();
            Console.WriteLine("Before");
            Func<string> oDel = objService.LomgRunningMethod;

            oDel.BeginInvoke(delegate (IAsyncResult ar) 
            {
                Console.WriteLine(oDel.EndInvoke(ar));    
            }, null);

            Console.WriteLine("After");
            Console.ReadLine();

        }
    }
}


//What is the difference between a Thread and a Delegate?

//=>When we call a function in a thread, all of them have a return type of 'void', while in delegate it is 'string' 
