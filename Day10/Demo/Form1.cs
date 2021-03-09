using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        Thread t1;
        WaitHandle wh;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thread Started");
            t1.Start();
        }

        void Func1()
        {
            wh = new AutoResetEvent(false);
            for (long i = 0; i < 1000000; i++)
            {
                if (i % 1000 == 0)
                {
                    MessageBox.Show("WaitOne called : " + i.ToString());
                    wh.WaitOne();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thread Aborted " );

            t1.Abort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(t1.ThreadState.ToString());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Set called ");

            ((AutoResetEvent)wh).Set();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t1 = new Thread(Func1);

        }
    }
}
