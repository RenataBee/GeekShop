﻿namespace GeekShop.CartApi.DTOs
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailDto> CartDetails { get; set; }
    }
}
