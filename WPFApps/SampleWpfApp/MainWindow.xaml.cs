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

namespace SampleWpfApp
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
        //Function that is invoked when the user clicks the button. 
        private void OnClick(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("I was clicked","My Message", MessageBoxButton.YesNoCancel);
            if (res == MessageBoxResult.Yes)
                MessageBox.Show("Yes was pressed");
            else if (res == MessageBoxResult.No)
                MessageBox.Show("No was pressed");
            else
                MessageBox.Show("Cancel or ESC was pressed");
        }
    }
}
