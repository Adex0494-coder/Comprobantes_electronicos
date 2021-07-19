using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Comprobantes_Electronicos
{
    public static class Helper
    {
        public static async Task<string> GetToken(string certPath,string certPass)
        {
            var restApi = new RestApi(GlobalConstants.testAutSemillaUrl);
            await restApi.GetRequest();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(restApi.response);
            xmlDoc.PreserveWhitespace = false;

            X509Certificate2 cert = new X509Certificate2(certPath, certPass, X509KeyStorageFlags.Exportable);
            var xmlSigned = new XmlSigned(xmlDoc, cert);

            //Save xml file in path
                Console.WriteLine(xmlSigned.xmlDocument.InnerXml);
                xmlSigned.xmlDocument.Save(@"C:\Users\adiaz\Desktop\test.xml");

            restApi.url = GlobalConstants.testAutValSemillaUrl; 
            var response = await restApi.PostRequest(xmlSigned.xmlDocument);

            return response;
        }
    }
}
