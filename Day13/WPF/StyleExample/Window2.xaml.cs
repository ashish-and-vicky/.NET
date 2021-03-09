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

namespace StyleExample
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
        private void element_MouseEnter(object sender, MouseEventArgs e) //this is the event written for mouse enter which is called in Handler in Window2.xaml---as sender is the one sending the request object is taken as sender
        {
            ((TextBlock)sender).Background = new SolidColorBrush(Colors.Red); //on mouse enter(hover) the background color becomes Red
        }

        private void element_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = null;
        }
    }
}
