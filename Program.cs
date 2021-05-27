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
            //1)----------------------------Create SemillaModel object from a get request--------------------------------------------

            //var restApi = new RestApi(GlobalConstants.testAutSemillaUrl);
            //await restApi.GetRequest();


            ////Crear objeto semillaModel usando la respuesta del GetRequest, que tiene formato xml
            //var semillaModel = SemillaModel.XmlToObject(restApi.response);


            //Console.WriteLine(semillaModel.valor + semillaModel.fecha);
            //Console.ReadLine();


            //2)---------------------------------Sign xml doc using a digital certificate-------------------------------------------------

            //X509Certificate2 cert = new X509Certificate2(@"C:\Users\adiaz\Desktop\Ariangel\Work\ComprobantesElectrónicos\AriangelDazEspaillat-2021-05-05-085635.p12", "password", X509KeyStorageFlags.Exportable);
            //Console.WriteLine(cert);

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(@"C:\Users\adiaz\Desktop\Ariangel\Work\ComprobantesElectrónicos\response_1620235881248.xml");
            //xmlDoc.PreserveWhitespace = false;

            //var xmlSigned = new XmlSigned(xmlDoc, cert);
            //Console.WriteLine(xmlSigned.xmlDocument.InnerXml);

            //Console.ReadLine();


            //3-----------------------------------Get a SemillaModel xtml and send it signed------------------------------------------

            //var restApi = new RestApi(GlobalConstants.testAutSemillaUrl);
            //await restApi.GetRequest();
            ////var xmlDocumnet = XDocument.Parse(restApi.response);
            ////Console.WriteLine(xmlDocumnet);

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(restApi.response);
            //xmlDoc.PreserveWhitespace = false;

            //X509Certificate2 cert = new X509Certificate2(@"C:\Users\adiaz\Desktop\Ariangel\Work\ComprobantesElectrónicos\AriangelDazEspaillat-2021-05-05-085635.p12", "password", X509KeyStorageFlags.Exportable);

            //var xmlSigned = new XmlSigned(xmlDoc, cert);
            ////Console.WriteLine(xmlSigned.xmlDocument.InnerXml);

            //restApi = new RestApi(GlobalConstants.testAutValSemillaUrl);

            //////XmlDocument xmlDoc = new XmlDocument();
            //////xmlDoc.LoadXml(restApi.response);
            //////xmlDoc.PreserveWhitespace = false;

            ////XmlTextReader reader = new XmlTextReader("C:\\Users\\adiaz\\Desktop\\Ariangel\\Work\\ComprobantesElectrónicos\\response_signed.xml");
            ////XmlDocument xmlDoc = new XmlDocument();
            ////xmlDoc.Load(reader);
            ////xmlDoc.PreserveWhitespace = false;
            ////reader.Close();

            //////var xmlDocumnet = XDocument.Parse(xmlSigned.xmlDocument.InnerXml);

            //restApi.PostRequest(xmlSigned.xmlDocument);
            //////Console.WriteLine(restApi.response);
            //Console.ReadLine();
            var response = await Helper.GetToken(@"C:\Users\adiaz\Desktop\Ariangel\Work\ComprobantesElectrónicos\AriangelDazEspaillat-2021-05-05-085635.p12", "password");
            Console.WriteLine(response);


            Console.ReadLine();
        }
    }
}
