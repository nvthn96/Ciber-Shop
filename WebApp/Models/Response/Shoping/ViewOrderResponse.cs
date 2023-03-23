using System.ComponentModel;

namespace WebApp.Models.Response.Shoping
{
    public class ViewOrderResponse
    {
        public Guid OrderId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
    }
}
