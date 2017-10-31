using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinCP.Model;

namespace XamarinCP.Service
{
    public class RestService : IRestService
    {
        readonly HttpClient _client;
        public List<Company> Companies { get; private set; }
        public RestService()
        {
            if(_client==null)
                _client = new HttpClient {MaxResponseContentBufferSize = 256000,Timeout = new TimeSpan(0,0,0,10)};
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            Companies = new List<Company>();
            
            var uri = new Uri("http://192.168.1.55:80/api/companies");

            try
            {
                var response = await _client.GetStringAsync(uri);
               
                Companies = JsonConvert.DeserializeObject<List<Company>>(response);
               
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Companies;
        }
    }
}