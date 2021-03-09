using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExample
{
    public class MyErrorHandler : HandleErrorAttribute //Exception, ExceptionContext comes from  HandleErrorAttribute which inherits from IException interface
    {
        public override void OnException(ExceptionContext filterContext) //
        {
            Log(filterContext.Exception); //the below function is called in this----this gives us details about which exception could occur 

            base.OnException(filterContext);
        }

        private void Log(Exception exception)
        {

            //write code here to log error to db/mail/text file etc
            Debug.Write("my handler ...." + exception.Message);
        }
    }
}


/*
 for this example to run we create directly a class  or  a folder and a class in it---right click on FilterExamplr(through over all project above)---Add---Class()---give name of class as MyErrorHandler (for folder rename as MyFilter)---
 */