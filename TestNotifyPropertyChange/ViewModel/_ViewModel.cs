using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestNotifyPropertyChange.ViewModel
{
    class _ViewModel : BindableBase
    {
        private string input;

        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
                RaisePropertyChanged("Input");
            }
        }

        private string output;

        public string Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
                RaisePropertyChanged("Output");
            }
        }

        public ICommand ChangeText { get; set; }
        public _ViewModel()
        {
            ChangeText = new DelegateCommand(resses);
        }
        public void resses()
        {
            Output = Input;
        }

    }
}
