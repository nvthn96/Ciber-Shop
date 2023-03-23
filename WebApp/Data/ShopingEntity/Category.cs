using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data.ShopingEntity
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}