using Discount.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Repository
{
   public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string ProductName);
        Task<bool> CreateDiscount(Coupon copoun);
        Task<bool> UpdateDiscount(Coupon copoun);
        Task<bool> DeleteDiscount(string ProductName);
    }
}
