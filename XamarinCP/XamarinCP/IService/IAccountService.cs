using System.Threading.Tasks;

namespace XamarinCP.IService
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}