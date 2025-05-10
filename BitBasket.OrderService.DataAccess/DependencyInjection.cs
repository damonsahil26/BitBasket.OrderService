using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.OrderService.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRequiredDataAccessServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
