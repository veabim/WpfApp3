using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.ViewModel
{
    public class ElApp
    {
        public string ElAppType { get; set; } /*Тип аппарата*/
        public bool ElAppLock { get; set; } /*Фиксация значений аппарата*/
        public string ElAppNumber { get; set; } /*Номер аппарата QF*/
        public string ElAppName { get; set; } /*Имя аппарата S203 120A C 10кА(текст)*/
    }
}
