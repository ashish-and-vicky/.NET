using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void txtNum1_KeyDown(object sender, KeyEventArgs e) //here problem statement is when an input is put in the input boxes then it should validate for integer type values
        {
            MessageBox.Show(KeyInterop.VirtualKeyFromKey(e.Key).ToString()); //KeyInterop converts to Int32, VirtualKeyFromKey takes the ascii value if any char is entered

            //MessageBox.Show(e.Key.ToString());
            e.Handled = true; //Handled is a boolean value that reads our input in char, means if char/keys are in the ascii value range then allow---we have kept it true which means to appear

        }
    }
}

//TO DO: 1) Only Numeric keys allowed in the textbox, 2) When values entered in the textboxes the its sub should be displayed in 'sum' in real time
