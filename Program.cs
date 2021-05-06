using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Comprobantes_Electronicos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //1)
            //var restApi = new RestApi(GlobalConstants.testAutSemillaUrl);
            //await restApi.GetRequest();

            ////Crear objeto semillaModel usando la respuesta del GetRequest, que tiene formato xml
            //var semillaModel = SemillaModel.XmlToObject(restApi.response);


            //Console.WriteLine(semillaModel.valor + semillaModel.fecha);
            //Console.ReadLine();

            //2)
            X509Certificate2 cert = new X509Certificate2(@"C:\Users\adiaz\Desktop\Ariangel\Work\ComprobantesElectrónicos\AriangelDazEspaillat-2021-05-05-085635.p12", "password", X509KeyStorageFlags.Exportable);
            Console.WriteLine(cert);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Users\adiaz\Desktop\Ariangel\Work\ComprobantesElectrónicos\response_1620235881248.xml");
            xmlDoc.PreserveWhitespace = false;

            var xmlSigned = new XmlSigned(xmlDoc, cert);
            Console.WriteLine(xmlSigned.xmlDocument.InnerXml);

            Console.ReadLine();
        }
    }
}
