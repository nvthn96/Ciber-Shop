using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.ShopingEntity;
using WebApp.Models.Response.Shoping;
using WebApp.Services.Interface;

namespace WebApp.Services.Implement
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingDbContext _shopingDbContext;

        public ProductService(IMapper mapper, ShoppingDbContext shopingDbContext)
        {
            _mapper = mapper;
            _shopingDbContext = shopingDbContext;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            var productTable = _shopingDbContext.Products.AsNoTracking();
            var items = await productTable.ToListAsync();
            var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(items);
            return result;
        }

    }
}
