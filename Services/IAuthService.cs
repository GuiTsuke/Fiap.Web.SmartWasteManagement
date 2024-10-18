using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }

}
