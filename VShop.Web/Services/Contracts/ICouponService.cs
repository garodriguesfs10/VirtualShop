using VShop.Web.Models;

namespace VShop.Web.Services.Contracts
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetDiscountCoupon(string coupon, string token);
    }
}
