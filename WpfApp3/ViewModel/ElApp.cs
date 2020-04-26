using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.ViewModel
{
    public class ElApp
    {
        public ElApp()
        {
            ElAppTypeList.Add("Автоматич. выкл");
            ElAppTypeList.Add("Диф. авт");
            ElAppTypeList.Add("Рубильник");
            ElAppTypeList.Add("Контактор");
        }

        public string ElAppType { get; set; } /*Тип аппарата*/
        public List<string> ElAppTypeList { get; set; } = new List<string>();

        public bool ElAppLock { get; set; } /*Фиксация значений аппарата*/

        public string ElAppNumber { get; set; } /*Номер аппарата QF*/

        public string ElAppName { get; set; } /*Имя аппарата S203 120A C 10кА(текст)*/
        public ObservableCollection<string> ElAuth { get; set; } = new ObservableCollection<string>();
    }
}
