namespace WebApp.Models.Request.Shoping
{
    public class OrderRequest
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}