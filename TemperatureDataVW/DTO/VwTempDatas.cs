using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureDataVW.DTO
{
    public class VwTempDatas
    {
        public IEnumerable<VwTempData> TempDataCollection { get; set; }

        public VwTempDatas(IEnumerable<VwTempData> data)
        {
            TempDataCollection = data;
        }
    }
}
