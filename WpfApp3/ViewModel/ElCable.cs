using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.ViewModel
{
    public class ElCable
    {
        public string CableMark { get; set; } /*Марка кабеля*/
        public bool CableLock { get; set; } /*Фиксация занчений кабеля*/
        public string DCable { get; set; } /*Сечение кабеля(кол.во кабелей/жил/сечение)*/
        public double CableFactLegth { get; set; } /*Фактическая длина кабеля*/
        public double KCable { get; set; } /*Коэффициент запаса кабеля*/
        public double CableDesLegth { get; set; } /*Расчетная длина кабеля*/
    }
}
