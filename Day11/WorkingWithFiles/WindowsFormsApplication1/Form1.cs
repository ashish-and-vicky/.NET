using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//A stream is a chunk of bytes
//for file handling----right click on VS and open as administrator

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

            //Directory.CreateDirectory("C:\\aaa"); ------used for creating a directory

            Directory.CreateDirectory(@"C:\aaaa"); ---//while creating directory, the compiler should not treat 'aaa' as a special char, we use '@' symbol or '//' symbol
          

            //DirectoryInfo dir = new DirectoryInfo("C:\\aaaa");
            //dir.

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            File.Create("C:\\aaaa\\a.txt"); //to create a file

            //FileInfo file = new FileInfo("C:\\aaaa\\a.txt");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DriveInfo drive = new DriveInfo("C"); //use to create drive eg C drive,  D drive
           //drive.
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string s = "Hello World";
            //byte[] arr = Encoding.Default.GetBytes(s);-----this method returns a byte array in arr which we are using below


            //FileStream stream = File.Open("C:\\aaaa\\a.txt", FileMode.Create);---------to do operations on the file this is done------there are more methods than FileMode.Create try with FileMode-----through FileStream, the file is converted into byte array

            //stream.Write(arr, 0, arr.Length);

            ////stream.Length();------------------tells the size of that stream
            ////stream.Read();
            ////To Do : write code to read from a stream

            //stream.Close();

            StreamWriter writer = File.CreateText("C:\\aaaa\\a.txt"); //used to write something to the file (only text)
            
            writer.WriteLine("Hello World");
            writer.WriteLine("Line 2");
            writer.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s;
            StreamReader reader = File.OpenText("C:\\aaaa\\a.txt"); //used to read something to the file (only text)
            while ((s = reader.ReadLine())!= null)
            {
                MessageBox.Show(s);
            }
            reader.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = "Hello";
            int i = 100;
            bool b = true;

            FileInfo f = new FileInfo("C:\\aaaa\\a.dat"); //we have taken FileInfo over here, because we need that in BinaryWriter

            BinaryWriter binary_writer = new BinaryWriter(f.OpenWrite()); //we have taken that 'FileInfo f' because we need that in BinaryWriter----Through BinaryWriter we can write any datatype in a file
            binary_writer.Write(s);
            binary_writer.Write(i);
            binary_writer.Write(b);
            binary_writer.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string s ;
            int i ;
            bool b ;
            FileInfo f = new FileInfo("C:\\aaaa\\a.dat");
            BinaryReader binary_reader = new BinaryReader(f.OpenRead()); //read other datatypes from the created file
            s = binary_reader.ReadString();
            i = binary_reader.ReadInt32();
            b = binary_reader.ReadBoolean();

            MessageBox.Show(s);
            MessageBox.Show(i.ToString());
            MessageBox.Show(b.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
