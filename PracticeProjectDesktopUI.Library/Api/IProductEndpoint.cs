using PracticeProjectDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeProjectDesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}