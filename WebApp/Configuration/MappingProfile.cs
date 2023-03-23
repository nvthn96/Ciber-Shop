using AutoMapper;
using WebApp.Data.ShopingEntity;
using WebApp.Models.Response.Shoping;

namespace WebApp.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // mapping shopping models
            CreateMap<Product, ProductResponse>();
            CreateMap<Customer, CustomerResponse>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<Order, OrderResponse>();
            // end mapping shopping models

            // mapping shopping query
            CreateMap<ViewOrder, ViewOrderResponse>();
            // end mapping shopping query
        }
    }
}
