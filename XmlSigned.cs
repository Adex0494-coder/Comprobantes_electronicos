using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Comprobantes_Electronicos
{
    public class XmlSigned
    {
        public XmlDocument xmlDocument;
        public X509Certificate2 cert;

        public XmlSigned(XmlDocument xmlDocument, X509Certificate2 cert)
        {
            this.xmlDocument = xmlDocument;
            this.cert = cert;
            SignXmlWithP12();
        }

        private void SignXmlWithP12()
        {

            var privateKey = this.cert.PrivateKey;
            var xmlSigned = new SignedXml(this.xmlDocument);
            xmlSigned.SigningKey = privateKey;

            var reference = new Reference();
            reference.Uri = "";
            var env = new XmlDsigEnvelopedSignatureTransform(true);
            reference.AddTransform(env);

            xmlSigned.AddReference(reference);

            var keyInfo = new KeyInfo();
            var clause = new KeyInfoX509Data();
            clause.AddSubjectName(cert.Subject);
            clause.AddCertificate(cert);
            keyInfo.AddClause(clause);

            xmlSigned.KeyInfo = keyInfo;
            
            xmlSigned.ComputeSignature();

            XmlElement xmlDigitalSignature = xmlSigned.GetXml();

            this.xmlDocument.DocumentElement.AppendChild(xmlDocument.ImportNode(xmlDigitalSignature, true));

        }
    }


}
