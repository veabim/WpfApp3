using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.ViewModel;

namespace WpfApp3.Model
{

    class MainModel : BindableBase
    {

        List<ElPanel> items = new List<ElPanel>();
        #region
        ElPanel item1 = new ElPanel("Итем 1");
        ElPanel item2 = new ElPanel("Итем 2");
        ElPanel item3 = new ElPanel("Итем 3");

        ElPanel item1_1 = new ElPanel("Итем 1.1");
        ElPanel item1_2 = new ElPanel("Итем 1.2");

        ElPanel item2_1 = new ElPanel("Итем 2.1");
        ElPanel item2_2 = new ElPanel("Итем 2.2");
        ElPanel item2_3 = new ElPanel("Итем 2.3");

        ElPanel item3_1 = new ElPanel("Итем 3.1");
        ElPanel item3_2 = new ElPanel("Итем 3.2");

        ElPanel item2_1_1 = new ElPanel("Итем 2.1.1");

        ElCircuet circuets1_1 = new ElCircuet();
        ElCircuet circuets1_2 = new ElCircuet();
        ElCircuet circuets1_3 = new ElCircuet();


        ElCircuet circuets2_1 = new ElCircuet();
        ElCircuet circuets2_2 = new ElCircuet();


        ElCircuet circuets3_1 = new ElCircuet();
        ElCircuet circuets3_2 = new ElCircuet();
        ElCircuet circuets3_3 = new ElCircuet();
        ElCircuet circuets3_4 = new ElCircuet();
        public List<ElPanel> GetItemsTree()
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

            //circuets1.LineNumber = "Линия 1.1";


            item1.ElCircuetsList.Add(circuets1_1);
            item1.ElCircuetsList.Add(circuets1_2);
            item1.ElCircuetsList.Add(circuets1_3);

            item2.ElCircuetsList.Add(circuets2_1);
            item2.ElCircuetsList.Add(circuets2_2);

            item3.ElCircuetsList.Add(circuets3_1);
            item3.ElCircuetsList.Add(circuets3_2);
            item3.ElCircuetsList.Add(circuets3_3);
            item3.ElCircuetsList.Add(circuets3_4);
            #endregion
            return items;
        }

        public void GetValue()
        {

        }
        public List<ElPanel> FindCheckedItem()
        {
            List<ElPanel> checkedItem = new List<ElPanel>();
            FindCheckedItemInternal(checkedItem, items);
            return checkedItem;
        }

        private void FindCheckedItemInternal(List<ElPanel> checkedItem, List<ElPanel> subItem)
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
