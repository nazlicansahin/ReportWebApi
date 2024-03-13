using ReportWebApi.API.Models.LoginModels;
using ReportWebApi.Domain.Identity;

namespace ReportWebApi.API.Service ///namespace service olarak gorunuyor services olarak gorunmesi gerekmiyor mu
{
        public interface IAuthService
        {
            string GenerateTokenString(LoginUser user);
            Task<bool> Login(LoginUser user);
            Task<bool> RegisterUser(LoginUser user);
        }

    }
 