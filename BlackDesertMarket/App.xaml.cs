using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BlackDesertMarket
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow _main;
            if (e.Args.Length > 0)
            {
                if (e.Args[0] =="1")
                {
                  _main  = new MainWindow(true);
                    return;
                }
            }

            _main = new MainWindow();
            _main.Show();
        }
    }
}
