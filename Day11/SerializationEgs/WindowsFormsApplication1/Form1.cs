using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//Serialization is the process of converting an object into a stream of bytes to store the object or transmit it to memory, a database, or a file. Its main purpose is to save the state of an object in order to be able to recreate it when needed.
//Deserialization means restoring that data or reading that stored data

//In Binary Format:-
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 o = new Class1();
            o.i = 100;
            o.P1 = "aaa";
            o.P2 = 200;
            BinaryFormatter bf = new BinaryFormatter(); //we are 1st instanting so as to store any type of code in a file in Binary Format
            Stream s = new FileStream("C:\\o.dat", FileMode.Create); //then taking the file in a stream------here object of Stream is taken as FileStream as it an object of derived class and Stream is a abstract class (we can't create an object of abstract class)
            bf.Serialize(s, o); //hence we are serializing the object in a file
            s.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream s = new FileStream("C:\\o.dat", FileMode.Open); //creating a stream of the file
            Class1 o= (Class1)bf.Deserialize(s); //Deserialize takes a stream as a parameter and returns an object----here Deserialize returns an object, hence typecasted
            s.Close();

            MessageBox.Show(o.i.ToString());
            MessageBox.Show(o.P1);
            MessageBox.Show(o.P2.ToString());
        }

//SOAP - It is a format which is accessable in all platforms. It is an XML based protocol----previously it was called as Simple Object Access Protocol, but now it is simply called as SOAP 
//In SOAP Format:- Similar to Binary Format
        private void button4_Click(object sender, EventArgs e)
        {
            Class1 o = new Class1();
            o.i = 100;
            o.P1 = "aaa";
            o.P2 = 200;
            SoapFormatter sf= new SoapFormatter();
            Stream s = new FileStream("C:\\o.soap", FileMode.Create);
            sf.Serialize(s, o);
            s.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SoapFormatter sf = new SoapFormatter();
            Stream s = new FileStream("C:\\o.soap", FileMode.Open);

            Class1 o = (Class1)sf.Deserialize(s);
            s.Close();
            MessageBox.Show(o.i.ToString());
            MessageBox.Show(o.P1);
            MessageBox.Show(o.P2.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1 o = new Class1();
            o.i = 100;
            o.P1 = "aaa";
            o.P2 = 200;
            XmlSerializer xs = new XmlSerializer(typeof(Class1) ); //XmlSerializer takes type as a parameter-----Note: XML only serializes the public member of that class
            Stream s = new FileStream("C:\\o.xml", FileMode.Create);
            xs.Serialize(s, o);
            s.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Class1));
            Stream s = new FileStream("C:\\o.xml", FileMode.Open);
            Class1 o = (Class1)xs.Deserialize(s);
            s.Close();
            MessageBox.Show(o.i.ToString());
            MessageBox.Show(o.P1);
            MessageBox.Show(o.P2.ToString());

        }
    }
}
