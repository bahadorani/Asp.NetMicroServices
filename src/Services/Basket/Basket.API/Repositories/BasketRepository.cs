using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _rediscache;
        public BasketRepository(IDistributedCache rediscache)
        {
            _rediscache = rediscache;
        }
        public async Task DeleteBasket(string UserName)
        {
            await _rediscache.RemoveAsync(UserName);
        }

        public async Task<ShoppingCart> GetBasket(string UserName)
        {
            var basket = await _rediscache.GetStringAsync(UserName);

            if (String.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _rediscache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.UserName);
        }
    }
}
