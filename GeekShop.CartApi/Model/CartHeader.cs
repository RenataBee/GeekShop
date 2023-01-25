using GeekShop.CartApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.CartApi.Model
{
    public class CartHeader : BaseEntity
    {
        public string UserId { get; set; }

        public string CouponCode { get; set; }
    }
}
