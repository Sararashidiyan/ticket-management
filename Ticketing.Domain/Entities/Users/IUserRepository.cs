using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Infrustructure.Repositories;

namespace Ticketing.Domain.Entities.Users
{
    public interface IUserRepository : IRepository<Guid, User>
    {
        Task<User> GetByEmailAndPassword(string email, string password);
        Task<User> GetByEmail(string email);
        Task<List<UserSummaryInfo>> GetSummaryInfo();
        Task<List<UserSummaryInfo>> GetSummaryInfoByIds(List<Guid> ids);
    }
}
