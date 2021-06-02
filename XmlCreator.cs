using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//https://www.c-sharpcorner.com/UploadFile/mahesh/create-xml-in-C-Sharp/

namespace Comprobantes_Electronicos
{
    class XmlCreator
    {
        public string xmlString;
        public XmlCreator() {
            this.xmlString= createXml();
        }
        public string createXml()
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {

                writer.WriteStartElement("book");
                writer.WriteElementString("title", "Graphics Programming using GDI+");
                writer.WriteElementString("author", "Mahesh Chand");
                writer.WriteElementString("publisher", "Addison-Wesley");
                writer.WriteElementString("price", "64.95");
                writer.WriteEndElement();
                writer.Flush();
            }

            return doc.InnerXml;
        }
    }

}
