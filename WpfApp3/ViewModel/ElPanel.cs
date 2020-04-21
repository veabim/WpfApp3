using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    public class ElPanel
    {
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
    }
}
