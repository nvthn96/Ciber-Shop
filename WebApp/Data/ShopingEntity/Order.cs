using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data.ShopingEntity
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}