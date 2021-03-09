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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnShowMessage_Click(object sender, RoutedEventArgs e)
        {

            //The below parameters are created in the Grid section
            //Name.Content = value;  or can be called as  -------------value can pe passed of any type -----this code is for the condition if we want to print "Hello World"
            //control.Property = value;

            //lblMessage.Content returns an object
            if (lblMessage.Content.ToString() == "Hello World") //this code is for the condition that if btn is clicked and if "Label" is there then print. If "Hello World" is there then print "Good afternoon" and if "Good afternoon" then "Hello World", further repetetion of the same process
                lblMessage.Content = "Good afternoon";
            else
                lblMessage.Content = "Hello World";

        }

        private void lblMessage_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
