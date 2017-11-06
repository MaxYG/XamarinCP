using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinCP.Constants;
using XamarinCP.IService;

namespace XamarinCP.Service
{
    public class AccountService:IAccountService
    {
        public bool IsLogin { get; private set; }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var uri = new Uri(ConstantTools.WebApiAddress + "api/account");

            try
            {
                var json = JsonConvert.SerializeObject(new
                {
                    Username = username,
                    Password = password
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await HttpClientService.Instance.PostAsync(uri, content);

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
