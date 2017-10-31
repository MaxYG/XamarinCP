using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinCP.Constants;
using XamarinCP.Model;

namespace XamarinCP.Service
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;
        public List<Company> Companies { get; private set; }
        public bool IsLogin { get; private set; }
        public RestService()
        {
            if(_client==null)
                _client = new HttpClient {MaxResponseContentBufferSize = 256000,Timeout = new TimeSpan(0,0,0,10)};
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            Companies = new List<Company>();
            
            var uri = new Uri(ConstantTools.WebApiAddress+"api/companies");

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
        
        public async Task<bool> LoginAsync(string username,string password)
        {
            var uri = new Uri(ConstantTools.WebApiAddress + "api/account");

            try
            {
                var json = JsonConvert.SerializeObject(new
                {
                    Username= username,
                    Password= password
                });
                var content=new StringContent(json,Encoding.UTF8,"application/json");
                var response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var contentReturn = response.Content.ReadAsStringAsync();
                    IsLogin = JsonConvert.DeserializeObject<bool>(contentReturn.Result);
                }
                
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return IsLogin;
        }
    }
}