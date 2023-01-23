using AutoMapper;
using GeekShop.CartApi.DTOs;
using GeekShop.CartApi.Model;

namespace GeekShop.CartApi.Config.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartDto, Cart>();
                config.CreateMap<CartDetailDto, CartDetail>();
                config.CreateMap<CartHeaderDto, CartHeader>();
                config.CreateMap<ProductDto, Product>();
            });
            return mappingConfig;
        }
    }
}
