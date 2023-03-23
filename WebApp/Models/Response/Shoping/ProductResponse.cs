namespace WebApp.Models.Response.Shoping
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }

        public CategoryResponse Category { get; set; }
        public ICollection<OrderResponse> Orders { get; set; }
    }
}