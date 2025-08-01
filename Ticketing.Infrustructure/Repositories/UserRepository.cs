using Microsoft.EntityFrameworkCore;
using Ticketing.Domain.Entities.Users;
using Ticketing.Domain.Extensions;

namespace Ticketing.Infrustructure.Repositories
{
    public class UserRepository(AppDbContext _context) : BaseRepository<AppDbContext, Guid, User>(_context), IUserRepository
    {
        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            var currentUser = await GetByEmail(email);
            if (currentUser == null) return null;
            var hashPassword = password.HashPassword(currentUser.SecurityStamp);
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == hashPassword);
        }
    }
}
