using System.Web.Http;
using XamarinCP.WebApi.Models;

namespace XamarinCP.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        [Route("api/account")]
        [HttpPost]
        public bool Login(LoginUser loginUser)
        {
            if (string.IsNullOrEmpty(loginUser.Username) || string.IsNullOrEmpty(loginUser.Password))
            {
                return false;
            }
            return loginUser.Username.Equals("test") && loginUser.Password.Equals("test");
        }
    }
}