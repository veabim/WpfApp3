using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.ViewModel
{
    public class ElPhase : List<string>
    {
        public ElPhase()
        {
            this.Add("A");
            this.Add("B");
            this.Add("C");
            this.Add("ABC");
        }
    }
}
