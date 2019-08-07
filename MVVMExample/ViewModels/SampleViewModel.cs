using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample.ViewModels
{
    using MVVMExample.Models;
    using System.ComponentModel;
    using System.Windows.Input;

    //Button has a Property called Command which specifies what command it executes when the default event of the Button happens: Click.....
    class SampleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> _myAction = null;

        public SampleCommand(Action<object> arg)
        {
            _myAction = arg;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_myAction != null)
                _myAction(parameter);
        }
    }
    class SampleViewModel : INotifyPropertyChanged
    {
        private SampleModel _model = new SampleModel();

        private SampleCommand command;
        public SampleViewModel()
        {
            command = new SampleCommand(saveChanges);
        }
        public string Welcome
        {
            get { return _model.Welcome; }
            set {
                _model.Welcome = value;
                OnPropertyChanged("Welcome");
            }
        }

        public SampleCommand SaveChanges {
            get
            {
                return command;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged !=null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private void saveChanges(object arg)
        {
            //Push the data into the model
            _model.Welcome = arg.ToString();
            //Get the data from the model into the ViewModel
            Welcome = _model.Welcome;
        }
    }
}
