using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Model
{
    public class Circuets : BindableBase
    {
        public Circuets()
        {
            Phase.Add("A");
            Phase.Add("B");
            Phase.Add("C");
        }
        public string Cable { get; set; }
        public double _dU { get; set; }
        public double I { get; set; }
        public double Length { get; set; }


        #region Общая информация о линии
        public string LineNumber { get; set; }
        public double InstElPower { get; set; }
        public double Кс { get; set; }
        public double Ксp { get; set; }
        public double DesElPower { get; set; }

        public List<string> Phase { get; set; } = new List<string>();

        //public int Phase { get; set; }
        public bool ActivePhaseLock { get; set; }
        public string ActivePhase { get; set; }
        public double cosf { get; set; }
        public double DesElCurrent { get; set; }
        #endregion


        #region Электрический аппарат 
        public ElApp ElApp1 { get; set; }
        #endregion



        #region Информация о кабеле
        public string CableMark1 { get; set; }
        public bool CableMark1Lock { get; set; }
        public string CableCut1 { get; set; }
        public double KCableStock1 { get; set; }
        public double FacticCableLegth1 { get; set; }

        public string CableMark2 { get; set; }
        public bool CableMark2Lock { get; set; }
        public string CableCut2 { get; set; }
        public double KCableStock2 { get; set; }
        public double FacticCableLegth2 { get; set; }

        public double DesCableLength { get; set; }
        public double dU { get; set; }
        public double ElSCCurrnt { get; set; }
        public bool IsCableTray { get; set; }
        public string CableLayingMethod { get; set; }

        public double PipeLength { get; set; }

        #endregion

        #region Нагрузка
        public bool LoadNameLock { get; set; }
        public string LoadName { get; set; }
        public string SystemLoadName { get; set; }

        public bool GrapthLock { get; set; }
        public string Grapth { get; set; }

        public string LoadLocation { get; set; }
        #endregion

    }
}
