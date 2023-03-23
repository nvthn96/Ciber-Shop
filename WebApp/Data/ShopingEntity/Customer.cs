using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data.ShopingEntity
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}