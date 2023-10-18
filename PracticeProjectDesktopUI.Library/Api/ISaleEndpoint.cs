using PracticeProjectDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace PracticeProjectDesktopUI.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}