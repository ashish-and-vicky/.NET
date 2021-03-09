using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            //foreach (string s in e.Args)
            //    MessageBox.Show(s);
        }

        //protected override 
        protected override void OnActivated(EventArgs e)
        {
            //MessageBox.Show("Activated");
            base.OnActivated(e);
        }
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            //if( e.ReasonSessionEnding == ReasonSessionEnding.
            base.OnSessionEnding(e);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            
            MessageBox.Show(e.Exception.Message);
        }

    }
}
