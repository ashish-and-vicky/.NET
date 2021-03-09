using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class Class1 //:ISerializable -----ISerializable is used for custom serialization-----when we use this then GetObjectData function gets created where we tell which object to serialize (private variables also because by default private variables are not serialized)
    {
        private int private_data;
        public int i;
        [XmlElement] //As for P1 XmlElement is given which serializes only Element eg. P1=100 and not its further details
        public string P1
        {
            get;
            set;
        }


        private int mP2;
        [XmlAttribute] //As for mP2 XmlAttribute is given which serializes the Attribute eg. mP2=100 which is of type int and its further details
        public int P2
        {
            get { return mP2; }
            set { mP2 = value; }
        }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("i", i);
        //    info.AddValue("P1", P1);
        //}
    }
}
