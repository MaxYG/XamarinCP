using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCP.Model;

namespace XamarinCP.IService
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompaniesAsync();
    }
}