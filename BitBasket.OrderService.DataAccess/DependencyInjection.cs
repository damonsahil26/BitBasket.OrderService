using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.OrderService.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRequiredDataAccessServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionStringTemplate = configuration.GetConnectionString("MongoDB");
            var connectionString = connectionStringTemplate?
                .Replace("$MONGO_HOST", Environment.GetEnvironmentVariable("MONGO_HOST"))
                .Replace("$MONGO_PORT", Environment.GetEnvironmentVariable("MONGO_PORT"));

            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
            services.AddScoped<IMongoDatabase>(provider =>
            {
                var client = provider.GetRequiredService<IMongoClient>();
                return client.GetDatabase("OrdersDatabase");
            });
            return services;
        }
    }
}
