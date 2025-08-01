using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Ticketing.Core
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IClaimHelper, ClaimHelper>();
            return services;
        }
    }
}
