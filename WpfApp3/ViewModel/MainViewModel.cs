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
            Sth = new DelegateCommand(Changetext);
            TextChengedCommand = new DelegateCommand<object>(textChange);
        }
        public ICommand OpenSth { get; }
        public ICommand ShowCheck { get; }
        public ICommand Sth { get; }
        public ICommand TextChengedCommand { get; }

        private void textChange(object obj)
        {
            var str = obj as string;
        }
        public void DisplayItemTree()
        {
            var itemTree = mainModel.GetItemsTree();
            Root = CollectionViewSource.GetDefaultView(itemTree);
            Root.Filter = new Predicate<object>((item) =>
            {
                var realItem = (Item)item;
                return true;
            });
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
                foreach (var item in items)
                {
                    str.Append(item.Name);
                }
            }
            MessageBox.Show(str.ToString());
        }

        private string _name;
        public string TextText
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("TextText");
            }
        }

        public void Changetext()
        {
            TextText = "dggg";
        }

    }
}
