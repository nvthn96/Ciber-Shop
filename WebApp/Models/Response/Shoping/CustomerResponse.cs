namespace WebApp.Models.Response.Shoping
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<OrderResponse> Orders { get; set; }
    }
}