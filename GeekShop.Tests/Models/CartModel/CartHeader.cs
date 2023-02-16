﻿namespace GeekShop.Tests.Models.CartModel
{
    public class CartHeader
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }

        public decimal DiscountAmount { get; set; }
    }
}
