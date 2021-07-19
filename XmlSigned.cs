using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            //var privateKey = this.cert.PrivateKey; 
            // Export private key from cert.PrivateKey and import into a PROV_RSA_AES provider:
            var exportedKeyMaterial = cert.PrivateKey.ToXmlString( /* includePrivateParameters = */ true);
            var key = new RSACryptoServiceProvider(new CspParameters(24 /* PROV_RSA_AES */));
            key.PersistKeyInCsp = false;
            key.FromXmlString(exportedKeyMaterial);

            //Create SignedXml object
            var xmlSigned = new SignedXml(this.xmlDocument);
            xmlSigned.SigningKey = key;
            xmlSigned.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

            //Create a reference of the document to be signed 
            var reference = new Reference();
            reference.Uri = "";//This references the whole document
            var env = new XmlDsigEnvelopedSignatureTransform(true);
            reference.AddTransform(env);

            xmlSigned.AddReference(reference);

            //Set KeyInfo
            var keyInfo = new KeyInfo();
            var clause = new KeyInfoX509Data();
            //clause.AddSubjectName(cert.Subject);
            clause.AddCertificate(cert);
            keyInfo.AddClause(clause);

            //Assign the KeyInfo the SignedXml object
            xmlSigned.KeyInfo = keyInfo;
            
            
            xmlSigned.ComputeSignature();

            XmlElement xmlDigitalSignature = xmlSigned.GetXml();

            //Append the signature to this xml document
            this.xmlDocument.DocumentElement.AppendChild(xmlDocument.ImportNode(xmlDigitalSignature, true));

        }
    }

}
