using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class ShopDataAccess : IShopDataAccess
    {
        private ExampleContext ExampleContext { get; }
        
        public ShopDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<ShopEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Shops
                .Include(x => x.Category)
                .OrderBy(x => x.Rating)
                .ToListAsync(ct);
        }
    }
}