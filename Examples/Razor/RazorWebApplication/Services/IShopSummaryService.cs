using System.Collections.Generic;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public interface IShopSummaryService
    {
        Task<IEnumerable<ShopSummary>> GetShopSummary();
    }
}