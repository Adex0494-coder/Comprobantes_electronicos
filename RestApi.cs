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
using System.Net.Http.Headers;

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
        public async Task GetRequest(string token,string trackId)
        {

            var client = new HttpClient();
            if (trackId == null)
            {
                client.DefaultRequestHeaders.Add("Accept", "application/xml");
            }
            else
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }

            if (trackId != null)
            {
                client.DefaultRequestHeaders.Add("authorization", "Bearer " + token);
                url += "?TrackId=" + trackId;
            }

            this.response = await client.GetStringAsync(url);
            client.Dispose();
        }

        //public async Task<string> PostRequest(XmlDocument xmlDoc)
        public async Task<string> PostRequest(string path, string token, string trackId)
        {
            try
            {
                HttpClient apiCallClient = new HttpClient();

               
                string restCallURL = url;

                HttpRequestMessage apirequest = new HttpRequestMessage(HttpMethod.Post, restCallURL); // post
                apirequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if(token !=null)
                {
                    string authorization = "Bearer " + token;
                    apirequest.Headers.Add("authorization", authorization);
                }

                    MultipartFormDataContent test = new MultipartFormDataContent();
                    //test.Add(new StringContent("Bad"), "tags");
                    //test.Add(new StringContent("true"), "displayreferencetext");
                    //test.Add(new StringContent("0.63"), "similaritythreshold");
                    test.Add(new StreamContent(File.OpenRead(path)), "xml", (new FileInfo(path).Name));
                    apirequest.Content = test;
   

                HttpResponseMessage apiCallResponse = await apiCallClient.SendAsync(apirequest);

                Stream s = await apiCallResponse.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(s);
                string responseString = reader.ReadToEnd();


                dynamic json = JsonConvert.DeserializeObject(responseString);

                if (token == null)
                {
                    string tokenGot = json.token;
                    return tokenGot;
                }
                //byte[] doc = null;
                //MemoryStream ms = new MemoryStream();
                //s.CopyTo(ms);
                //doc = ms.ToArray();
                //Console.WriteLine(doc);
                //Console.WriteLine(ms);
                //File.WriteAllBytes(@"C:\Users\adiaz\Desktop\rez.docx", doc);

                return json.trackId;
            }
            catch
            {
                return "error in post request";
            }
        }
        }

            
    }

