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
            var restApi = new RestApi(GlobalConstants.certAutSemillaUrl);
            await restApi.GetRequest(null,null);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(restApi.response);
            xmlDoc.PreserveWhitespace = false;

            X509Certificate2 cert = new X509Certificate2(certPath, certPass, X509KeyStorageFlags.Exportable);
            var xmlSigned = new XmlSigned(xmlDoc, cert);

            //Save xml file in path
                //Console.WriteLine(xmlSigned.xmlDocument.InnerXml);
                xmlSigned.xmlDocument.Save(@"C:\Users\adiaz\Desktop\test.xml");

            restApi.url = GlobalConstants.certAutValSemillaUrl; 
            var response = await restApi.PostRequest((@"C:\Users\adiaz\Desktop\test.xml"),null,null);

            return response;
        }

        public static async Task<string> SignSendXmlNcf(string certPath, string certPass, string xmlPath, string token, string xmlToSavePath)
        {
           
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            xmlDoc.PreserveWhitespace = false;

            X509Certificate2 cert = new X509Certificate2(certPath, certPass, X509KeyStorageFlags.Exportable);
            var xmlSigned = new XmlSigned(xmlDoc, cert);

            //Save xml file in path
            //Console.WriteLine(xmlSigned.xmlDocument.InnerXml);
            xmlSigned.xmlDocument.Save(xmlToSavePath);

            var restApi = new RestApi(GlobalConstants.certReceNcf);
            var response = await restApi.PostRequest(xmlToSavePath,token,null);

            return response;
        }

        public static async Task<string> ConsultEncfState(string token, string trackId)
        {
            var restApi = new RestApi(GlobalConstants.certConsultaResultado);
            await restApi.GetRequest(token, trackId);

            return restApi.response;
        }
    }
}
