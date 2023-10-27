using PracticeProjectDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeProjectDesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();
    }
}