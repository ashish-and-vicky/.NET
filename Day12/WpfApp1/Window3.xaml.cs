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
//Refer Imp Links and Notes File
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstNames.Items.Add("Virat");
            lstNames.Items.Add("Pujara");
            lstNames.Items.Add("Rahane");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(lstNames.Items.Count.ToString());
            //MessageBox.Show(lstNames.SelectedItem.ToString());----SelectedItem returns the collection of objects which the user has chosen
            //MessageBox.Show(lstNames.SelectedIndex.ToString());----SelectedIndex for eg. you select the 1st item then it will show 0----run it till here and check by clicking the iyems in the list box
            foreach (var item in lstNames.SelectedItems) //we have taken SelectedItems as we want only the selected items values to be displayed
            {
                MessageBox.Show(item.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lstNames.Items.RemoveAt(lstNames.SelectedIndex); //RemoveAt takes index to remove a particular object---while only Remove deletes the whole object
        }
    }
}

//Note: While clicking on the button if actions dosen't happens then check the Grid section. In it check the 'Click' attribute available. If not then type it with Click="<function/method name>(like Button_Click_1 above)


//TO DO: Create a WPF with 2 ListBoxes. Put some items in the 1st one. Between the list boxes put '<' for sending one item to another ListBox(Left, Right respectively), '<<' for sending multiple items to another ListBox & '>', '>>' vice versa