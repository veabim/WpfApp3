using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Model
{
    public class Item
    {
        public string Name { get; set; }
        public Item(string name)
        {
            Name = name;
        }
        public List<Item> Sub { get; set; } = new List<Item>();
        public Item Root { get; set; }
        public string Source { get; set; }
        public bool CheckedItem { get; set; }
    }
}
