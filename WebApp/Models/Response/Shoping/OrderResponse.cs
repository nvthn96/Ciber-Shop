namespace WebApp.Models.Response.Shoping
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }

        public CustomerResponse Customer { get; set; }
        public ProductResponse Product { get; set; }
    }
}