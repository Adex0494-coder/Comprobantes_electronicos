using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Comprobantes_Electronicos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var restApi = new RestApi(GlobalConstants.testAutSemillaUrl);
            await restApi.GetRequest();

            //Crear objeto semillaModel usando la respuesta al GetRequest, que tiene formato xml
            var semillaModel = SemillaModel.XmlToObject(restApi.response);


            Console.WriteLine(semillaModel.valor + semillaModel.fecha);
            Console.ReadLine();
        }
    }
}
