using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp3.Model;

namespace WpfApp3.ViewModel //ShowCheck
{
    class MainViewModel : BindableBase
    {
        MainModel mainModel = new MainModel();
        private ICollectionView root;
        public MainViewModel()
        {
            OpenSth = new DelegateCommand(DisplayItemTree);
            ShowCheck = new DelegateCommand(ShowCheckedItemsCommand);
        }
        public ICommand OpenSth { get; }
        public ICommand ShowCheck { get; }
        public void DisplayItemTree()
        {
            var itemTree = mainModel.GetItemsTree();
            Root = CollectionViewSource.GetDefaultView(itemTree);
            Root.Refresh();
        }
        public ICollectionView Root
        {
            get => root;
            set => SetProperty(ref root, value);
        }
        public void ShowCheckedItemsCommand()
        {
            var str = new StringBuilder();
            List<Item> items = mainModel.FindCheckedItem();
            if (items.Count == 0)
            {
                str.Append("No selected items");
            }
            else
            {
                foreach(var item in items)
                {
                    str.Append(item.Name);
                }
            }
            MessageBox.Show(str.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
