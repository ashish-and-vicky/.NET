using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTOSql
{
    public partial class Employee 
    {

        partial void OnEmpNoChanging(int value)
        {
            if (value< 0)
                throw new InvalidEmpNoException("Invalid Employee Number");
        }

        partial void OnBasicChanging(decimal value)
        {
            if (value == 0)
                throw new InvalidBasicException("Invalid Basic");
        }
        partial void OnNameChanging(string value)
        {
            if (value =="" || value==null)
                throw new InvalidNameException("Invalid Name");
        }
        partial void OnDeptNoChanging(int value)
        {
            

        }
    }



}
