using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureDataVW.DTO
{
    public class VwTempData
    {
        public VwTempData(ExcelRange range)
        {
            var rowData = range.Select(c => c.Value == null ? string.Empty : c.Value.ToString());
            var rowArr = rowData.ToArray();
            T1 = double.Parse(rowArr[0]);
            T2 = double.Parse(rowArr[1]);
            T3 = double.Parse(rowArr[2]);
            Alarm = rowArr[4] == "Y" ? true : false;
            Date = DateTime.FromOADate(double.Parse(rowArr[3]));
        }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double T3 { get; set; }
        public bool Alarm { get; set; }
        public DateTime Date { get; set; }
    }
}
