using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinCP.Constants;
using XamarinCP.IService;
using XamarinCP.Model;

namespace XamarinCP.Service
{
    public class CompanyService:ICompanyService
    {
        public List<Company> Companies { get; private set; }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            Companies = new List<Company>();

            var uri = new Uri(ConstantTools.WebApiAddress + "api/companies");

            try
            {
                var response = await HttpClientService.Instance.GetStringAsync(uri);

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