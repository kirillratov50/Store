using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Store.ViewModel;
using Store.View;

namespace Store.Model
{
    internal class CreateWindow
    {
        public static void CreateMessageBox(string message)
        {
            MessageBox.Show(message);
        }
        public static void CreateMainWindow(MainViewModel mainViewModel)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = mainViewModel;
            mainWindow.Visibility = Visibility.Visible;
            Application.Current.MainWindow = mainWindow;   
        }
    }
}
