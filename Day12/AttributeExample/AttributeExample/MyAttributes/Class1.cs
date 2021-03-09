using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//here we try to create our own attribute eg. Serializable. It is a class which inherits from attribute class 
namespace MyAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Class | //this attribute can be given to a class, method, struct etc.(remove the Class to see more options)---here .AttributeUsage is a class which has .AttributeTargets, AllowMultiple and Inherited in it
                       System.AttributeTargets.Struct, AllowMultiple = true,Inherited = true)] //here we are giving Attribute to Class & Struct---by default it marks to all 
    public class Attribute1 : System.Attribute //here we are creating our own attributes
    {
        public string Name { get; set; }
        public Attribute1(string Name)
        {
            this.Name = Name;
        }
    }
}
