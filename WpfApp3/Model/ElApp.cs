using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Model
{
    public class ElApp : BindableBase
    {
        public ElApp()
        {
            LineNameList.Add("A");
            LineNameList.Add("B");
            LineNameList.Add("C");
        }
        public List<string> LineNameList { get; set; } = new List<string>();
        public string ElAppType { get; set; }
        public string ElAppNumber { get; set; }
        public string ElAppName { get; set; }
    }
}
