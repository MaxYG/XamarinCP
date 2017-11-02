using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinCP.IService;
using XamarinCP.Model;

namespace XamarinCP.Service
{
    public class ServiceManager
    {
        private readonly ICompanyService _companyService;
        private readonly IAccountService _accountService;
        public ServiceManager(ICompanyService companyService,IAccountService accountService)
        {
            _companyService = companyService;
            _accountService = accountService;
        }
        public Task<List<Company>> GetCompaniesAsync()
        {
            return _companyService.GetCompaniesAsync();
        }

        public Task<bool> LoginAsync(string username,string password)
        {
            return _accountService.LoginAsync(username,password);
        }
    }
}
