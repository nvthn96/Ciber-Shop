namespace WebApp.Models.Response.Shoping
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ProductResponse> Products { get; set; }
    }
}