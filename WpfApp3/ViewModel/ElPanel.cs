using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    public class ElPanel : BindableBase
    {
        private double instElPower;

        public string Name { get; set; }
        public ElPanel(string name)
        {
            Name = name;
        }
        public List<ElPanel> Sub { get; set; } = new List<ElPanel>();
        public ElPanel Root { get; set; }
        public string Source { get; set; }
        public bool CheckedItem { get; set; }
        public ObservableCollection<ElCircuet> ElCircuetsList { get; set; } = new ObservableCollection<ElCircuet>();
        public double InstElPower
        {
            get => instElPower;
            set
            {
                instElPower = value;
                RaisePropertyChanged(nameof(InstElPower));
            }
        }
        public double Kc { get; set; }
        public double DesElPower { get; set; }
        public double cosf { get; set; }
        public double DesElCurrent { get; set; }
    }
}
