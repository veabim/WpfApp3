using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Model
{
    
    class MainModel : BindableBase
    {
        
        List<Item> items = new List<Item>();
        #region
        Item item1 = new Item("Итем 1");
        Item item2 = new Item("Итем 2");
        Item item3 = new Item("Итем 3");

        Item item1_1 = new Item("Итем 1.1");
        Item item1_2 = new Item("Итем 1.2");

        Item item2_1 = new Item("Итем 2.1");
        Item item2_2 = new Item("Итем 2.2");
        Item item2_3 = new Item("Итем 2.3");

        Item item3_1 = new Item("Итем 3.1");
        Item item3_2 = new Item("Итем 3.2");

        Item item2_1_1 = new Item("Итем 2.1.1");
        public List<Item> GetItemsTree()
        {
            item1.Root = null;
            item2.Root = null;
            item3.Root = null;

            item1_1.Root = item1;
            item1_2.Root = item1;

            item2_1.Root = item2;
            item2_2.Root = item2;
            item2_3.Root = item2;

            item3_1.Root = item3;
            item3_2.Root = item3;

            item2_1_1.Root = item2_1;

            item1.Sub.Add(item1_1);
            item1.Sub.Add(item1_2);

            item2.Sub.Add(item2_1);
            item2.Sub.Add(item2_2);
            item2.Sub.Add(item2_3);

            item3.Sub.Add(item3_1);
            item3.Sub.Add(item3_2);

            item2_1.Sub.Add(item2_1_1);

            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            #endregion
            return items;
        }
        

        public List<Item> FindCheckedItem()
        {
            List<Item> checkedItem = new List<Item>();
            FindCheckedItemInternal(checkedItem, items);
            return checkedItem;
        }

        private void FindCheckedItemInternal(List<Item> checkedItem, List<Item> subItem)
        {
            foreach (var item in subItem)
            {
                if (item.CheckedItem)
                {
                    checkedItem.Add(item);
                }
                FindCheckedItemInternal(checkedItem, item.Sub);
            }
        }

    }
}
