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

namespace WpfApp3.ViewModel
{
    class MainViewModel : BindableBase
    {
        #region Конструкторы
        public MainViewModel()
        {
            OpenSth = new DelegateCommand(DisplayItemTree);
            ShowCheck = new DelegateCommand(ShowCheckedItemsCommand);
            DisplayItemTree();
        }
        #endregion

        #region Поля
        private Item item;
        MainModel mainModel = new MainModel();
        private ICollectionView root;
        private string linePhase;
        #endregion

        #region Свойства
        public ObservableCollection<Circuets> CircuetsProp { get; set; } = new ObservableCollection<Circuets>();
        public ICommand OpenSth { get; }
        public ICommand ShowCheck { get; }
        public ICommand Sth { get; }
        public ICollectionView Root
        {
            get => root;
            set => SetProperty(ref root, value);
        }
        public Item SelectedNode
        {
            get => item;
            set
            {
                item = value;
                //RaisePropertyChanged(nameof(SelectedNode));
                CircuetsProp = item?.ListOfCircuets;
                RaisePropertyChanged(nameof(CircuetsProp));
            }
        }
        public string LinePhase
        {
            get => linePhase;
            set
            {
                RaisePropertyChanged(nameof(LinePhase));
                linePhase = value;
            }
        }
        #endregion

        #region Методы
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
        #endregion

    }
}
