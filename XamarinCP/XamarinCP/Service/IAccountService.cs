using System.Threading.Tasks;

namespace XamarinCP.Service
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}