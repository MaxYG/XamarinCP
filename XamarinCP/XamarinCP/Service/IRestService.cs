using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinCP.Model;

namespace XamarinCP.Service
{
    public interface IRestService
    {
        Task<List<Company>> GetCompaniesAsync();
    }
}