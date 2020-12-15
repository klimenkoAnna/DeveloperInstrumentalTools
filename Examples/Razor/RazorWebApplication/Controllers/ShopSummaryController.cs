using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Controllers
{
    public class ShopSummaryController : Controller
    {
        private IShopSummaryService ShopSummaryService { get; }
        
        public ShopSummaryController(IShopSummaryService shopSummaryService)
        {
            ShopSummaryService = shopSummaryService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await ShopSummaryService.GetShopSummary());
        }

        public IActionResult Details(ShopSummary model)
        {
            return this.View(model);
        }
    }
}