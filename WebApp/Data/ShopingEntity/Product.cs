using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data.ShopingEntity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}