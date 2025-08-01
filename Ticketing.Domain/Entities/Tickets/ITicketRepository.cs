using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Infrustructure.Repositories;

namespace Ticketing.Domain.Entities.Tickets
{
    public interface ITicketRepository : IRepository<Guid, Ticket>
    {
        Task<Ticket> GetAssignedTicketByIdAsync(Guid currentUserId, Guid id);
        Task<int> GetCountByStatus(Guid currentUserId, string status);
        Task<Ticket> GetEmployeeTicketById(Guid id, Guid currentEmployeeId);
        Task<List<Ticket>> GetEmployeeTickets(Guid currentEmployeeId);
        Task<List<Ticket>> GetAssignedTickets(Guid currentUserId);
    }
}
