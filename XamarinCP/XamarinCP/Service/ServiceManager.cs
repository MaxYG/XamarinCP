using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinCP.Model;

namespace XamarinCP.Service
{
    public class ServiceManager
    {
        readonly IRestService _restService;
        public ServiceManager(IRestService service)
        {
            _restService = service;
        }
        public Task<List<Company>> GetCompaniesAsync()
        {
            return _restService.GetCompaniesAsync();
        }
    }
}
