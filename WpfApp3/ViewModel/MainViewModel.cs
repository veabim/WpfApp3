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
        private ObservableCollection<ElCircuet> circuetsProp = new ObservableCollection<ElCircuet>();
        #endregion

        #region Свойства
        public double InstElPowerElPannel { get; set; }
        public ObservableCollection<ElCircuet> CircuetsProp
        {
            get => circuetsProp;
            set
            {
                circuetsProp = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
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
                CircuetsProp = SelectedPanel?.ElCircuetsList;
                //InstElPowerElPannel = SumInstElPower(CircuetsProp);
                SumInstElPower(CircuetsProp);
                RaisePropertyChanged(nameof(CircuetsProp));
                RaisePropertyChanged(nameof(InstElPowerElPannel));
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
        public void SumInstElPower(ObservableCollection<ElCircuet> elCircuets)
        {
            double instElPower = 0;
            foreach (ElCircuet elCirc in elCircuets)
            {
                instElPower = instElPower + elCirc.InstElPower;
            }
            InstElPowerElPannel = instElPower;
            RaisePropertyChanged(nameof(InstElPowerElPannel));
        }
    }
}
