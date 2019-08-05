using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleWpfApp.Infrastructure
{
    public static class MyCommands
    {
        private static RoutedUICommand _saveAs;//my custom command....

        //Invoked once and only once during the execution of the program...
        static MyCommands()
        {
            InputGestureCollection collection = new InputGestureCollection();
            collection.Add(new KeyGesture(Key.B, ModifierKeys.Control, "Ctrl+B"));
            _saveAs = new RoutedUICommand("Save As", "SaveAs", typeof(MyCommands), collection);
        }


        public static RoutedUICommand SaveAs => _saveAs;
        
    }
}
