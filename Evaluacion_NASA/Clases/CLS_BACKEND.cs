using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Evaluacion_NASA.Clases
{
    class CLS_BACKEND
    {
        private HttpClient client = new HttpClient();
        public async System.Threading.Tasks.Task<dynamic> ExtracData()
        {
            try
            {
                string url = "http://www.estuder.com.mx/nasa/";
                string date = DateTime.UtcNow.ToString("yyyyMMdd");
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                //HttpClient client = new HttpClient();
                HttpRequestMessage request;
                request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{url}webservice/rest/server.php?wstoken=96a04a26e3f3bbced3255abb919979e3&wsfunction=local_getcoursecreatebydate&startdate=20230101&enddate={date}&moodlewsrestformat=json"),
                };
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    string JObject = await response.Content.ReadAsStringAsync();
                    if (!String.IsNullOrEmpty(JObject))
                    {
                        dynamic data = JsonNode.Parse(JObject);
                        return data;
                    }
                };
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("CLS_BackEndConsoft.GetBookRows(): {0}", ex.Message));
            }
        }
    }
}
