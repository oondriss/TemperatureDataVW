using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureDataVW.DTO;

namespace TemperatureDataVW.Managers
{
    public class ElasticImportManager
    {
        VwTempDatas _data;
        ElasticClient _client;

        public ElasticImportManager(VwTempDatas vwTempDatas)
        {
            _data = vwTempDatas;

            var node = new Uri("http://elastic:changeme@elasticstack.northeurope.cloudapp.azure.com:9200");

            var connectionSettings = new ConnectionSettings(node)
                .InferMappingFor<VwTempData>(i => i.IndexName("vwtempdata").TypeName("vwtempdata"))
                .RequestTimeout(TimeSpan.FromMinutes(2));
            //.EnableDebugMode()
            //.PrettyJson()

            _client = new ElasticClient(connectionSettings);
        }

        public void IndexTempData()
        {
            var i = 1;
            var cnt = _data.TempDataCollection.Count();

            foreach (var item in _data.TempDataCollection)
            {
                var a = _client.Index(item, idx => idx.Index("vwtempdata"));

                Console.WriteLine($"sending: - {i}/{cnt}");
                i++;
            }
        }
    }
}
