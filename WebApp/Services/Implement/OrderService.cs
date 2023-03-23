using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Configuration;
using WebApp.Data;
using WebApp.Data.ShopingEntity;
using WebApp.Exceptions;
using WebApp.Extension;
using WebApp.Extension.Pagging;
using WebApp.Models.Request.Shoping;
using WebApp.Models.Response.Shoping;
using WebApp.Services.Interface;

namespace WebApp.Services.Implement
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingDbContext _shopingDbContext;

        public OrderService(IMapper mapper, ShoppingDbContext shopingDbContext)
        {
            _mapper = mapper;
            _shopingDbContext = shopingDbContext;
        }

        public async Task<IEnumerable<OrderResponse>> GetAllAsync(CancellationToken cancellationToken)
        {
            var viewOrder = _shopingDbContext.Orders;
            var items = await viewOrder.AsNoTracking().ToListAsync();
            var result = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResponse>>(items);

            return result;
        }

        public async Task<ViewPagging<ViewOrderResponse>> GetPaggingAsync(ViewPagging<ViewOrderResponse> request, CancellationToken cancellationToken)
        {
            var viewOrder = _shopingDbContext.ViewOrders;

            var parameters = request.GetPaggingParameters();
            var query = viewOrder.ExecProcedure(UserStoreProcedure.Order.GetPagging, parameters.ToArray());

            var items = await query.ToListAsync(cancellationToken);
            request.Data = _mapper.Map<IEnumerable<ViewOrder>, IEnumerable<ViewOrderResponse>>(items);

            return request;
        }

        public async Task<OrderResponse> CreateAsync(OrderRequest request, CancellationToken cancellationToken)
        {
            var orderTable = _shopingDbContext.Orders;
            var item = await orderTable.AsNoTracking()
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (item != null) {
                throw new OrderDuplicateException(item.Product.Name);
            }

            var newItem = new Order() {
                Id = request.Id,
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                Amount = request.Amount,
                OrderDate = request.OrderDate,
            };

            await orderTable.AddAsync(newItem, cancellationToken);
            await _shopingDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Order, OrderResponse>(newItem);
        }

        public async Task<OrderResponse> UpdateAsync(OrderRequest request, CancellationToken cancellationToken)
        {
            var orderTable = _shopingDbContext.Orders;
            var item = await orderTable.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (item == null) {
                throw new OrderNotFoundException("Order");
            }

            item.CustomerId = request.CustomerId;
            item.ProductId = request.ProductId;
            item.Amount = request.Amount;
            item.OrderDate = request.OrderDate;

            _shopingDbContext.Entry(item).State = EntityState.Modified;
            await _shopingDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Order, OrderResponse>(item);

        }
    }
}
