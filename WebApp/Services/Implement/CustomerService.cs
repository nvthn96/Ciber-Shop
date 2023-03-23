using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.ShopingEntity;
using WebApp.Models.Response.Shoping;
using WebApp.Services.Interface;

namespace WebApp.Services.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingDbContext _shopingDbContext;

        public CustomerService(IMapper mapper, ShoppingDbContext shopingDbContext)
        {
            _mapper = mapper;
            _shopingDbContext = shopingDbContext;
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            var customerTable = _shopingDbContext.Customers.AsNoTracking();
            var items = await customerTable.ToListAsync();
            var result = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResponse>>(items);
            return result;
        }

    }
}
