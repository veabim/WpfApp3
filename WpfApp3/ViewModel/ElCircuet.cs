using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    public class ElCircuet : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged realise
        public event PropertyChangedEventHandler PropertyChanged;
        public int GetPropertyChangedSubscribledLenght()
        {
            return PropertyChanged?.GetInvocationList()?.Length ?? 0;
        }
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            RaisePropertyChanged(propertyName);

            return true;
        }
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
        #endregion


        public event Action<object> Changed;

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
        public string Load_Type { get; set; } /*Тип нагрузки*/
        public string Load_Name { get; set; } /*Наименование нагрузки*/
        public string Load_Mode_Operating { get; set; } /*Режим учета нагрузки*/
        public string Load_Winter_Summer { get; set; } /*Режим работы Зима/лето*/
        public string Name_Line { get; set; } /*Обозначение кабеля(номер линии)*/
        public string Calculated_Р { get; set; } /*Расчетная мощность, Рр, кВт*/
        public string Number_Of_Phase { get; set; } /*Количества фаз*/
        public string Connection_Phase { get; set; } /*Фаза подключения*/
        public string COS { get; set; } /*Коэффициент мощности, cоsϕ*/
        public string Calculated_I { get; set; } /*Расчетный ток, Iр (А)*/
        public string Device_Type_1 { get; set; } /*Тип аппарата 1*/
        public string Device_Number_1 { get; set; } /*Номер аппарата 1*/
        public string Device_1 { get; set; }/*Аппарат  1*/
        public string Device_Type_2 { get; set; } /*Тип аппарата 2*/
        public string Device_Number_2 { get; set; } /*Номер аппарата2*/
        public string Device_2 { get; set; } /*Аппарат  2*/
        public string Device_Type_3 { get; set; } /*Тип аппарата 3*/
        public string Device_Number_3 { get; set; } /*Номер аппарата 3*/
        public string Device_3 { get; set; }/*Аппарат  3*/
        public string Cable_Mark_1 { get; set; } /*Марка кабеля 1*/
        public string Сable_S_1 { get; set; } /*Сечение кабеля (кол.во кабелей/жил/сечение) 1*/
        public string Cable_L_1 { get; set; } /*Фактическая длина кабеля Lф 1*/
        public string Сable_S_2 { get; set; }/*Сечение кабеля (кол.во кабелей/жил/сечение) 2*/
        public string Cable_L_2 { get; set; } /*Фактическая длина кабеля Lф 2*/
        public string Calculated_Cable_L_1 { get; set; } /*Расчетная длина кабеля Lр 1*/
        public string Max_dU { get; set; } /*Допустимые потери на участке dUдоп*/
        public string Calculated_dU { get; set; } /*Расчетные потери напряжения на участке dUр*/
        public string Ik_End_Line { get; set; } /*Ток КЗ в конце линии, I1фкз, кА*/
        public string Сable_In_Tray { get; set; } /*Способ прокладки Лоток (Да/Нет)*/
        public string Сable_In_Pipe { get; set; } /*Способ прокладки (дополнительный) Варианты труб*/
        public string Pipe_D { get; set; } /*Диаметры труб*/
        public string Pipe_L { get; set; } /*Длина труб, м */
        public string Comment { get; set; } /*Согласно проекту*/










        public string LineNumber { get; set; } /*номер линии*/
        public double InstElPower /*Установленная мощность*/
        {
            get => instElPower;
            set
            {
                instElPower = value;
                if (LockTest == false) 
                {
                    DesElPower = Math.Round((InstElPower * Кс * Ксp), 2);
                }
                Changed?.Invoke(this);
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
                Changed?.Invoke(this);
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
                Changed?.Invoke(this);
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
                if (LockTest == false)
                {
                    desElPower = Math.Round((InstElPower * Кс * Ксp), 2);
                }
                else
                {
                    desElPower = value;
                }
                RaisePropertyChanged(nameof(DesElPower));
            }

        }


        public bool lockTest;
        public bool LockTest
        {
            get => lockTest;
            set
            {
                lockTest = value;
                RaisePropertyChanged(nameof(LockTest));


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
                Changed?.Invoke(this);
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
                Changed?.Invoke(this);
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
