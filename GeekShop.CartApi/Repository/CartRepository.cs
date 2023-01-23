using AutoMapper;
using GeekShop.CartApi.DTOs;
using GeekShop.CartApi.IRepository;
using GeekShop.CartApi.Model;
using GeekShop.CartApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.CartApi.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CartRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _dataContext.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId);

            if(cartHeader != null)
            {
                _dataContext.CartDetails.RemoveRange(_dataContext.CartDetails.
                    Where(c => c.CartHeaderId == cartHeader.Id));

                _dataContext.CartHeaders.Remove(cartHeader);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartDto> FindCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _dataContext.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId),
            };
            cart.CartDetails = _dataContext.CartDetails.
                Where(c => c.CartHeaderId == cart.CartHeader.Id).Include(c => c.Product);

            return _mapper.Map<CartDto>(cart);

        }

        public async Task<bool> RemoveFromCart(int cartDetailId)
        {
            try
            {
                CartDetail cartDetail = await _dataContext.CartDetails.FirstOrDefaultAsync(c => c.CartHeaderId == cartDetailId);
                int total = _dataContext.CartDetails.
                    Where(c => c.CartHeaderId == cartDetail.CartHeaderId).Count();

                _dataContext.CartDetails.Remove(cartDetail);

                if (total == 1)
                {
                    var cartHeaderToRemove = await _dataContext.CartHeaders.FirstOrDefaultAsync(c => c.Id == cartDetail.CartHeaderId);
                    if(cartHeaderToRemove != null) _dataContext.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }        

        public async Task<CartDto> SaveOrUpdateCart(CartDto cartDto)
        {
            Cart cart = _mapper.Map<Cart>(cartDto);

            //Checks if the product is already saved in the database if it does not exist then save
            var product = await _dataContext.Products.
                FirstOrDefaultAsync(p => p.Id == cartDto.CartDetails.FirstOrDefault().ProductId);

            if (product == null)
            {
                _dataContext.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await _dataContext.SaveChangesAsync();
            }

            //Check if CartHeader is null
            var cartHeader = await _dataContext.CartHeaders.AsNoTracking().
                FirstOrDefaultAsync(c => c.UserId == cart.CartHeader.UserId);

            if (cartHeader == null)
            {
                //Create CartHeader
                _dataContext.CartHeaders.Add(cart.CartHeader);
                await _dataContext.SaveChangesAsync();

                //Create CartDetails
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                _dataContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _dataContext.SaveChangesAsync();
            }
            else
            {
                //If CartHeader is not null
                //Check if CartDetails has same product
                var cartDetail = await _dataContext.CartDetails.AsNoTracking().
                    FirstOrDefaultAsync(p => p.ProductId == cartDto.CartDetails.
                    FirstOrDefault().ProductId && p.CartHeaderId == cartHeader.Id);

                if (cartDetail == null)
                {
                    //Create CartDetails
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _dataContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _dataContext.SaveChangesAsync();
                }
                else
                {
                    //Update product count and CartDetails
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;

                    _dataContext.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await _dataContext.SaveChangesAsync();
                }
            }
            return _mapper.Map<CartDto>(cart);
        }
    }
}