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
                _client = new HttpClient {MaxResponseContentBufferSize = 256000,Timeout = new TimeSpan(0,0,5,0)};
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            Companies = new List<Company>();
            
            var uri = new Uri("http://192.168.1.55:8084/api/company");

            try
            {
                var response = await _client.GetStringAsync(uri);
               
                    var content = response;
                    Companies = JsonConvert.DeserializeObject<List<Company>>(content);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Companies;
        }
    }
}