using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace Comprobantes_Electronicos
{
    public class RestApi
    {
        public string url;
        public string response;

        public RestApi(string url)
        {
            this.url = url;
        }

        //Get Request usando la url y guardando la respuesta en la propiedad response.
        public async Task GetRequest()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/xml");

            this.response = await client.GetStringAsync(url);
            client.Dispose();
        }

        public async Task<string> PostRequest(XmlDocument xmlDoc)
        {
            //1
            //string json = JsonConvert.SerializeXmlNode(xmlDoc);

            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Content-Type", "multipart/form-data");

            //var data = new StringContent(json, Encoding.UTF8, "text/xml");

            //var response = await client.PostAsync(url, data);

            //this.response = response.Content.ReadAsStringAsync().Result;
            //client.Dispose();


            //string json = JsonConvert.SerializeXmlNode(xmlDoc);

            //2
            //var data = new StringContent(xmlDoc.InnerXml, Encoding.UTF8, "text/xml");


            //Console.WriteLine(xmlDoc.InnerXml);

            //var client = new HttpClient();

            //var response = await client.PostAsync(this.url, data);

            //string result = response.Content.ReadAsStringAsync().Result;


            //3
            //HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(this.url);
            //httpRequest.Method = "POST";
            //httpRequest.ContentType = "text/xml";


            //string data = xmlDoc.InnerXml;
            //byte[] bytedata = Encoding.UTF8.GetBytes(data);
            //// Get the request stream.
            //Stream requestStream = httpRequest.GetRequestStream();
            //// Write the data to the request stream.
            //requestStream.Write(bytedata, 0, bytedata.Length);
            //requestStream.Close();
            //HttpWebResponse httpResponse = null; ;
            ////Get Response
            //try
            //{
            //     httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            //}
            //catch (WebException ex)
            //{
            //    var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            //    Console.WriteLine(resp);
            //}

            //4 

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.url);
            //request.Method = "POST";
            //request.KeepAlive = true;

            //FileStream file = File.OpenRead("C:\\Users\\adiaz\\Desktop\\Ariangel\\Work\\ComprobantesElectrónicos\\response_signed.xml");
            //FileInfo info = new FileInfo(file.Name);

            //request.ContentLength = file.Length;
            //Console.WriteLine(request.ContentLength);
            //request.ContentType = "multipart/form-data";

            //request.Accept = "application/json";

            //file.Seek(0, SeekOrigin.Begin);
            //file.CopyTo(request.GetRequestStream());

            //try
            //{
            //    HttpWebResponse response = (request.GetResponse() as HttpWebResponse);
            //}
            //catch (WebException ex)
            //{
            //    //var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            //    //Console.WriteLine(resp);

            //    StreamReader reader = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8);

            //}




            //5

            //FileStream file = File.OpenRead("C:\\Users\\adiaz\\Desktop\\Ariangel\\Work\\ComprobantesElectrónicos\\response_signed.xml");

            //var client = new HttpClient();
            //var content = new MultipartFormDataContent();

            //byte[] Bytes = new byte[file.Length];
            //file.Read(Bytes, 0, Bytes.Length);
            //var fileContent = new ByteArrayContent(Bytes);
            ////fileContent.Headers.ContentDisposition = new System.Net.Http
            //content.Add(fileContent);
            //Task<HttpResponseMessage> httpResponse = client.PostAsync(this.url, content);



            //Console.WriteLine(httpResponse.Result.Content.ReadAsStringAsync().Result);


            //6
            try
            {
                var client = new HttpClient();
                var content = new MultipartFormDataContent();


                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "text/form-data");



                //FileStream file = File.OpenRead("C:\\Users\\adiaz\\Desktop\\Ariangel\\Work\\ComprobantesElectrónicos\\response_signed.xml");
                FileStream fs = new FileStream("theXml.xml", FileMode.Create);
                xmlDoc.Save(fs);

                byte[] Bytes = new byte[fs.Length];
                fs.Read(Bytes, 0, Bytes.Length);
                var fileContent = new ByteArrayContent(Bytes);
                //fileContent.Headers.ContentDisposition = new System.Net.Http
                content.Add(fileContent);

                var response = await client.PostAsync(url, content);


                this.response = response.Content.ReadAsStringAsync().Result;
                client.Dispose();

                Console.WriteLine(xmlDoc.InnerXml);

                return this.response;
            }
            catch (Exception e) {
                return e.Message;
            }

            

        }
        }

            
    }

