using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    public class ElCircuet
    {
        public string LineNumber { get; set; } /*номер линии*/
        public double InstElPower { get; set; } /*Установленная мощность*/
        public double Кс { get; set; } /*Коэффициент спроса (системный подсчет)*/
        public double Ксp { get; set; } /*Коэффициент спроса (дополнительный подсчет)*/
        public double DesElPower { get; set; } /*Расчетная мощность*/

        public int NPhase { get; set; } /*Кол-во фаз*/
        public bool ActivePhaseLock { get; set; } /*Замок для фазы*/
        public ElPhase elPhase { get; set; } = new ElPhase(); /*Список ваз А В и С*/
        public string ActivePhase { get; set; } /*Активная фаза*/

        public double cosf { get; set; } /*Коэффициент мощности*/
        public double DesElCurrent { get; set; } /*Расчетный ток*/


        public ElApp ElApp1 { get; set; } = new ElApp(); /*Первый аппарат в линии*/
        public ElApp ElApp2 { get; set; } = new ElApp(); /*Второй аппарат в линии*/
        public ElApp ElApp3 { get; set; } = new ElApp(); /*Третий аппарат в линии*/


        public ElCable ElCable1 { get; set; } = new ElCable(); /*Первый кабель в линии*/
        public ElCable ElCable2 { get; set; } = new ElCable(); /*Второй кабель в линии (опционально, при наличии ответвлений)*/


        public double dU { get; set; } /*Потери напряжения*/
        public double ElSCCurrnt { get; set; } /*Ток КЗ*/
        public bool IsCableTray { get; set; } /*Лоток Да/Нет*/
        public string CableLayingMethod { get; set; } /*Способ прокладки кабеля*/

        public double PipeLength { get; set; } /*Длина трубы*/

        #region Нагрузка
        public bool LoadNameLock { get; set; } /*Фиксация значения наименование нагрузки*/
        public string LoadName { get; set; } /*Наименование нагрузки*/
        public string SystemLoadName { get; set; } /*Системное наименование нагрузки*/

        public bool GrapthLock { get; set; } /*Фиксация УГО*/
        public string Grapth { get; set; } /*УГО*/

        public string LoadLocation { get; set; } /*Помещение*/
        #endregion
    }
}
