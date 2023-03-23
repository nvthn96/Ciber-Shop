using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using WebApp.Configuration;
using WebApp.Controllers;
using WebApp.Data;
using WebApp.Data.ShopingEntity;
using WebApp.Extension.Pagging;
using WebApp.Models.Response.Shoping;

namespace WebApp.Services.Implement.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public async Task GetPaggingAsyncTest()
        {
            var options = new DbContextOptionsBuilder<ShoppingDbContext>()
            .UseInMemoryDatabase(databaseName: "ShoppingMockDatabase")
            .Options;

            using (var context = new ShoppingDbContext(options)) {
                context.Orders.Add(new Order { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Amount = 5, OrderDate = new DateTime() });
                context.Orders.Add(new Order { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Amount = 4, OrderDate = new DateTime() });
                context.Orders.Add(new Order { Id = Guid.NewGuid(), CustomerId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Amount = 3, OrderDate = new DateTime() });
                context.SaveChanges();
            }

            using (var context = new ShoppingDbContext(options)) {
                var myProfile = new MappingProfile();
                var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
                IMapper mapper = new Mapper(configuration);

                var service = new OrderService(mapper, context);

                var cts = new CancellationTokenSource();
                var allOrders = await service.GetAllAsync(cts.Token);

                Assert.AreEqual(3, allOrders.Count());
            }
        }
    }
}