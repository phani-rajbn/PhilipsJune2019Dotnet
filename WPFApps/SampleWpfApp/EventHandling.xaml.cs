using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for EventHandling.xaml
    /// </summary>
    public partial class EventHandling : Window
    {
        private int eventCounter = 0;
        public EventHandling()
        {
            InitializeComponent();
        }
        //Events in WPF are of 2 types: Bubbling and Tunnelling. Bubbling is more like a wate bubble which funnels up to the Above Element while it handles in the current. The Opposite of it is tunnelling where the Event is triggered from the top to the bottom. 
        //Bubbling is more like a water bubble which moves towards the upper direction, so that event is called as Bubbling Event. All Events in WPF are bubbling Events. Tunnelling events are those with a prefix called Preview.
        //All Events are instances of a Delegate called RoutedEvent..
        //RoutedEvent has 2 parameters: object sender and RoutedEventArgs called e. e will determine whether to funnel it further or not along with other read only properties thro which we could understand the source of the event, its source deep down or its Original Source.
        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            eventCounter++;
            string msg = string.Format($"Counter#{eventCounter}:\r\n");
            msg += string.Format("Sender:{0}\r\nSource:{1}\r\nOriginalSource:{2}\r\n\n", sender, e.Source, e.OriginalSource);
            lstMessages.Items.Add(msg);
            e.Handled = (bool)ckHandled.IsChecked;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Clear();
            eventCounter = 0;
        }

        private void beforeMouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("About to Click the " + e.Source);
            Thread.Sleep(1000);
        }
    }
}
