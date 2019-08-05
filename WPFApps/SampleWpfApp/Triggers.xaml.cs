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
//Triggers are sp kind of actions done on the Elements of the Window. With Trigger we could anticipate the action and perform some changes to the UI of the Window.
/*
 * There are 3 kinds of triggers:
 * Property Triggers: Raised when a certain property changes
 * Event Triggers: Actions are done on the object
 * Data Triggers: When the associated source of data modifies. 
 */
namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for Triggers.xaml
    /// </summary>
    public partial class Triggers : Window
    {
        public Triggers()
        {
            InitializeComponent();
        }
    }
}
