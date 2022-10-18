using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "swn", FirstName = "TestuserFName", LastName = "TestuserSName", EmailAddress = "somemail@gmail.com", AddressLine = "TestAddres", Country = "TestCounty", TotalPrice = 350 },
                new Order() {UserName = "swn", FirstName = "TestuserFName", LastName = "TestuserSName", EmailAddress = "somemail@gmail.com", AddressLine = "TestAddres", Country = "TestCounty", TotalPrice = 450 }
            };
        }
    }
}