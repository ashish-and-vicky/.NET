using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqTOSql
{
    class InvalidEmpNoException : Exception
    {

        public InvalidEmpNoException(string Message) : base(Message) { }
        
    }

    class InvalidBasicException : Exception
        {
        public InvalidBasicException(string Message) : base(Message) { }
        }

    class InvalidNameException : Exception
    {
        public InvalidNameException(string Message) : base(Message) { }
    }

}
