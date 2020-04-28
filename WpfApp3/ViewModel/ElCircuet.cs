using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    public class ElCircuet : BindableBase
    {
        //public void SomeAction()
        //{
        //    CallBack?.Invoke(this);
        //}

        //public event Action CallBack;



        private double desElPower;
        private double instElPower;
        private double кс;
        private double ксp;
        private int nPhase;
        private double desElCurrent;
        private double cosf1;

        public ElCircuet()
        {
            elPhase.Add("A");
            elPhase.Add("B");
            elPhase.Add("C");
            elPhase.Add("ABC");
        }

        public string LineNumber { get; set; } /*номер линии*/
        public double InstElPower /*Установленная мощность*/
        {
            get => instElPower;
            set
            {
                instElPower = value;
                desElPower = Math.Round((InstElPower * Кс * Ксp), 2);
                RaisePropertyChanged(nameof(DesElPower));
            }
        }
        public double Кс /*Коэффициент спроса (системный подсчет)*/
        {
            get => кс;
            set
            {
                кс = value;
                desElPower = Math.Round((InstElPower * Кс * Ксp), 2);
                RaisePropertyChanged(nameof(DesElPower));
            }
        }
        public double Ксp /*Коэффициент спроса (дополнительный подсчет)*/
        {
            get => ксp;
            set
            {
                ксp = value;
                desElPower = Math.Round((InstElPower * Кс * Ксp), 2);
                RaisePropertyChanged(nameof(DesElPower));
            }
        }
        public double DesElPower /*Расчетная мощность*/
        {
            get
            {
                return desElPower;
            }

            set
            {
                desElPower = value;
                desElPower = InstElPower * Кс * Ксp;
            }

        }

        public int NPhase /*Кол-во фаз*/
        {
            get => nPhase;
            set
            {
                if (value == 3)
                {
                    nPhase = value;
                    desElCurrent = Math.Round((DesElPower / Math.Sqrt(3) / 0.38 / cosf), 2);
                    RaisePropertyChanged(nameof(DesElCurrent));
                }
                else if (value == 1)
                {
                    nPhase = value;
                    desElCurrent = Math.Round((DesElPower / 0.22 / cosf), 2);
                    RaisePropertyChanged(nameof(DesElCurrent));
                }
                else
                {
                    nPhase = 0;
                }
            }
        }
        public bool ActivePhaseLock { get; set; } /*Замок для фазы*/
        public List<string> elPhase { get; set; } = new List<string>(); /*Список ваз А В и С*/
        public string ActivePhase { get; set; } /*Активная фаза*/

        public double cosf /*Коэффициент мощности*/
        {
            get => cosf1;
            set
            {
                cosf1 = value;
                if (NPhase == 3)
                {
                    desElCurrent = Math.Round((DesElPower / Math.Sqrt(3) / 0.38 / cosf), 2);
                    RaisePropertyChanged(nameof(DesElCurrent));
                }
                if (NPhase == 1)
                {
                    desElCurrent = Math.Round((DesElPower / 0.22 / cosf), 2);
                    RaisePropertyChanged(nameof(DesElCurrent));
                }

            }
        }
        public double DesElCurrent /*Расчетный ток*/
        {
            get => desElCurrent;
            set
            {
                desElCurrent = value;
            }
        }


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
