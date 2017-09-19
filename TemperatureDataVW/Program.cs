using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureDataVW.Managers;

namespace TemperatureDataVW
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var sourcePath = "";


            //get excel source filename
            var ofd = new OpenFileDialog()
            {
                Multiselect = false
            };

            if (ofd.ShowDialog()==DialogResult.OK)
            {
                sourcePath = ofd.FileName;
            }

            //parse source data
            var excelManager = new ExcelParseManager(sourcePath);
            var excelData = excelManager.ParseSourceData();

            //generate more data - not required now

            //insert into elasticsearch
            var elastic = new ElasticImportManager(excelData);
            elastic.IndexTempData();


        }
    }
}
