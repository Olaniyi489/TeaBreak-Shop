using API.Models;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly AppDbContext _appDbContext;

        public CoffeeShopService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CoffeeShopDto>> List()
        {
            var coffeeShops = await (from shop in _appDbContext.CoffeeShops
                                     select new CoffeeShopDto()
                                     {
                                         Id = shop.Id,
                                         Name = shop.Name,
                                         OpeningHours = shop.OpeningHours,
                                         Address = shop.Address,
                                     }).ToListAsync();
            return coffeeShops;
        }
    }


}

