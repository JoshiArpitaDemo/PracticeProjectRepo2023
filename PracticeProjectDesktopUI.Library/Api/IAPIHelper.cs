using PracticeProjectWPFUI.Models;
using System.Threading.Tasks;

namespace PracticeProjectDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}