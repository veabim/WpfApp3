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

        Circuets circuets1 = new Circuets();
        Circuets circuets2 = new Circuets();
        Circuets circuets3 = new Circuets();
        Circuets circuets4 = new Circuets();
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

            circuets1.Cable = "ВВГнг";
            circuets1.dU = 0.25;
            circuets1.I = 25;
            circuets1.Length = 110;

            circuets2.Cable = "ПуГВ";
            circuets2.dU = 1.05;
            circuets2.I = 40;
            circuets2.Length = 23;


            circuets3.Cable = "FRLS";
            circuets3.dU = 0.15;
            circuets3.I = 0.25;
            circuets3.Length = 150;

            circuets4.Cable = "LSLTx";
            circuets4.dU = 0.75;
            circuets4.I = 78;
            circuets4.Length = 30050;

            item1.ListOfCircuets.Add(circuets1);
            item1.ListOfCircuets.Add(circuets2);
            item1.ListOfCircuets.Add(circuets3);

            item2.ListOfCircuets.Add(circuets2);
            item2.ListOfCircuets.Add(circuets3);

            item3.ListOfCircuets.Add(circuets3);
            item3.ListOfCircuets.Add(circuets2);
            item3.ListOfCircuets.Add(circuets1);
            item3.ListOfCircuets.Add(circuets4);
            #endregion
            return items;
        }
        
        public void GetValue()
        {

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
