using Microsoft.EntityFrameworkCore;

namespace WebApp.Data.ShopingEntity
{
    [Keyless]
    public class ViewOrder
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
    }
}
