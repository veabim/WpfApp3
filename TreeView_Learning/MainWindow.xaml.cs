using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeView_Learning
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }

    class ViewModel
    {
        private ObservableCollection<Node> myVar;

        public ObservableCollection<Node> NodeList
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public DelegateCommand<Node> TreeNodeDoubleClickevent { get; set; }

        public ViewModel()
        {
            NodeList = new ObservableCollection<Node>();
            Node nd = new Node();
            nd.NodeName = "Item 1.1";
            Node nd1 = new Node();
            nd1.NodeName = "Item 1.2";
            Node nd2 = new Node();
            nd2.NodeName = "Item 1";
            nd2.Children.Add(nd);
            nd2.Children.Add(nd1);
            NodeList.Add(nd2);
            TreeNodeDoubleClickevent = new DelegateCommand<Node>(MouseDoubleClick);
        }

        private void MouseDoubleClick(Node obj)
        {
            MessageBox.Show(obj.NodeName);
        }
    }

    class Node
    {
        private string nodeName;

        public string NodeName
        {
            get { return nodeName; }
            set { nodeName = value; }
        }

        private ObservableCollection<Node> myVar = new ObservableCollection<Node>();

        public ObservableCollection<Node> Children
        {
            get { return myVar; }
            set { myVar = value; }
        }
        public class BindableSelectedItemBehavior : Behavior<TreeView>
        {

            public object SelectedItem
            {
                get { return GetValue(SelectedItemProperty); }
                set { SetValue(SelectedItemProperty, value); }
            }

            public static readonly DependencyProperty SelectedItemProperty =
                DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(BindableSelectedItemBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));

            private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                var item = e.NewValue as TreeViewItem;
                if (item != null)
                {
                    item.SetValue(TreeViewItem.IsSelectedProperty, true);
                }
            }

            protected override void OnAttached()
            {
                base.OnAttached();

                AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
            }

            protected override void OnDetaching()
            {
                base.OnDetaching();

                if (AssociatedObject != null)
                {
                    AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
                }
            }

            private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
            {
                SelectedItem = e.NewValue;
            }
        }
    }
}
