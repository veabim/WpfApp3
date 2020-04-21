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
        private ElPanel SelectedPanel;
        MainModel mainModel = new MainModel();
        private ICollectionView root;
        #endregion

        #region Свойства
        public ObservableCollection<ElCircuet> CircuetsProp { get; set; } = new ObservableCollection<ElCircuet>();
        public ICommand OpenSth { get; }
        public ICommand ShowCheck { get; }

        public ICollectionView Root
        {
            get => root;
            set => SetProperty(ref root, value);
        }
        public ElPanel SelectedNode
        {
            get => SelectedPanel;
            set
            {
                SelectedPanel = value;
                //RaisePropertyChanged(nameof(SelectedNode));
                CircuetsProp = SelectedPanel?.ElCircuetsList;
                RaisePropertyChanged(nameof(CircuetsProp));
                //CircuetsProp.Clear();
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
                var realItem = (ElPanel)item;
                return true;
            });
            Root.Refresh();
        }

        public void ShowCheckedItemsCommand()
        {
            var str = new StringBuilder();
            List<ElPanel> items = mainModel.FindCheckedItem();
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
