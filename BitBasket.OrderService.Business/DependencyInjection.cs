using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.OrderService.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRequiredBusinessServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
