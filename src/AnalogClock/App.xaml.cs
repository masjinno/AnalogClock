using AnalogClock.View;
using AnalogClock.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AnalogClock
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private MainWindow view;
        //private MainViewModel viewModel;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            view = new MainWindow();
            //viewModel = new MainViewModel();
            view.Show();
        }
    }
}
