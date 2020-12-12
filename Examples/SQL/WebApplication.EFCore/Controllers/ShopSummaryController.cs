using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.EFCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.EFCore.Controllers
{
    [ApiController]
    [Route("shops")]
    public class ShopSummaryController : ControllerBase
    {
        private ILogger<ShopSummaryController> Logger { get; }
        private IShopDataAccess ShopDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public ShopSummaryController(ILogger<ShopSummaryController> logger, IShopDataAccess shopDataAccess, IMapper mapper)
        {
            Logger = logger;
            ShopDataAccess = shopDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ShopSummary>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(ShopSummaryController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<ShopSummary>>(await this.ShopDataAccess.GetAllAsync(ct));
        }
    }
}