using Microsoft.Extensions.DependencyInjection;
using Ticketing.Domain.Entities.Users;
using Ticketing.Infrustructure.Repositories;
using Ticketing.Domain.Entities.Tickets;

namespace Ticketing.Infrustructure
{
    public static class InfrustructureServiceRegistration
    {
        public static IServiceCollection RegisterInfrustructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            return services;
        }
    }
}
