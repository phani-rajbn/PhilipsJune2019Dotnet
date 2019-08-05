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
//Resources in WPF are external files or data that is used to enhance the look and the feel of the Application. 
/*
 * Resources are of 2 types: Object Resources and Assembly Resources. 
 * Object Resources are reusable components or objects that can be used across the Application like objects of a class. U could create an instance and associate its property thro Path. 
 * Assembly Resouces are the Resources that are a part of the Assembly and will be loaded by the WPF before the Application is Executed. All XAML Files will be Assembly Resources. The XAML files are compiled to BAML Files(Binary Markup language files) which are loaded as Assembly resources for the Application. 
 * Among Object Resources, U could create a resource in 2 ways: Static and Dynamic. 
 * Static  Resources are created at compile Time whereas Dynamic Resources are generated thro CODE at runtime. Dynamic Resources are slow but will allow to load the resources at runtime. Static are fast and will be associated to the app even before the App begins its execution. 
 */
namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for Resources.xaml
    /// </summary>
    public partial class Resources : Window
    {
        public Resources()
        {
            InitializeComponent();
        }
    }
}
