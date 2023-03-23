using WebApp.Models.Response.Shoping;

namespace WebApp.Services.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
