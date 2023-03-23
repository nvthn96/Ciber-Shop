using WebApp.Models.Response.Shoping;

namespace WebApp.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
