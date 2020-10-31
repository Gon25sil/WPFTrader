using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        public async Task<T> GetAsync<T>(string uri)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("GET"), uri))
            {
                request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                HttpResponseMessage response = await SendAsync(request);

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T[]>(jsonResponse).FirstOrDefault();

            }
        }
    }
}
