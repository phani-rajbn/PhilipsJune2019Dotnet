using Microsoft.Win32;
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
using SampleWpfApp.Models;

namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for NotepadApp.xaml
    /// </summary>
    public partial class NotepadApp : Window
    {
        static string filename = string.Empty;
        public NotepadApp()
        {
            InitializeComponent();
        }
        //This method will be called when the user clicks the Open menu item....
        private void OnOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            filename = dlg.FileName;
            txtContent.Text = FileIO.ReadFile(filename);
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(filename))
            {
                SaveFileDialog dlg = new SaveFileDialog();
                bool? fileInfo = dlg.ShowDialog();
                filename = dlg.FileName;
                if (fileInfo.Value == false)
                    return;
            }
            FileIO.WriteFile(filename, txtContent.Text);
            MessageBox.Show("File saved to the System");
        }

        //Initializing the contents to blank and allowing the user to create new files. 
        private void OnNew(object sender, RoutedEventArgs e)
        {
            filename = string.Empty;
            txtContent.Text = string.Empty;//Clear the old content and make it blank....
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnSaveAs(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Do it urself...");
        }
    }
}
