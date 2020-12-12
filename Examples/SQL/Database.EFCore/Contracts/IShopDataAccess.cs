using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Entities;

namespace Database.EFCore.Contracts
{
    public interface IShopDataAccess
    {
        Task<IEnumerable<ShopEntity>> GetAllAsync(CancellationToken ct = default);
    }
}