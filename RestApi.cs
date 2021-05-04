using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

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
    }
}
