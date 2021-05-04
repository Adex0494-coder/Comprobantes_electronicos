using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Comprobantes_Electronicos
{
    public class SemillaModel
    {
        public string valor;
        public string fecha; 

        public SemillaModel(string valor, string fecha)
            {
                this.valor = valor;
                this.fecha = fecha;
            }

        private SemillaModel()
        {

        }

        //Convertir de xml string a objeto SemillaModel
        public static SemillaModel XmlToObject(string xml)
        {
            var xmlDocumnet = XDocument.Parse(xml);
            var xmlSerializer = new XmlSerializer(typeof(SemillaModel));
            var semillaModel = (SemillaModel)xmlSerializer.Deserialize(xmlDocumnet.CreateReader());
            return semillaModel;
        }

    }
}
