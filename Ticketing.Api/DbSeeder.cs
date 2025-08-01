using Ticketing.Domain.Entities.Users;
using Ticketing.Infrustructure;

namespace Ticketing.Api
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    User.CreateAdmin("admin-admin","admin@gmail.com","123456"),
                    User.CreateEmployee("employee-employee","employee@gmail.com","123456")
                );
                context.SaveChanges();
            }
        }
    }
}
