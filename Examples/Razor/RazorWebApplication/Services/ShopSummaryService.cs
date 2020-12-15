using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public class ShopSummaryService : IShopSummaryService
    {
        private HttpClient HttpClient { get; }
        
        public ShopSummaryService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<ShopSummary>> GetShopSummary()
        {
            using var response = await this.HttpClient.GetAsync("shops");

            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<ShopSummary>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}