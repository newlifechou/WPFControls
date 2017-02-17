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

namespace BindableCSVTableTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt.CSVContent = @"No., Cu Atm %, In Atm %, Ga Atm %, Se Atm %
11,22.89,20.12,7.01,49.98
12,22.71,19.91,7.04,50.34
13,23.16,20.17,6.69,49.98
14,22.79,19.81,6.82,50.58
15,22.22,20.22,6.89,50.68
Average,22.75,20.05,6.89,50.31";
        }
    }
}
