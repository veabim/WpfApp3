using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestNotifyPropertyChange.ViewModel;

namespace TestNotifyPropertyChange.View
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
        }
        _ViewModel ViewModel = new _ViewModel();

        private void CAHHA_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Output = ViewModel.Input;
            MessageBox.Show(ViewModel.Output);
            MessageBox.Show(ViewModel.Input);
        }
    }
}
