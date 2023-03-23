using WebApp.Extension.Pagging;
using WebApp.Models.Request.Shoping;
using WebApp.Models.Response.Shoping;

namespace WebApp.Services.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ViewPagging<ViewOrderResponse>> GetPaggingAsync(ViewPagging<ViewOrderResponse> request, CancellationToken cancellationToken = default);
        Task<OrderResponse> CreateAsync(OrderRequest request, CancellationToken cancellationToken = default);
        Task<OrderResponse> UpdateAsync(OrderRequest request, CancellationToken cancellationToken = default);
    }
}
