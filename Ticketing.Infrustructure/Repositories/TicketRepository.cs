using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ticketing.Domain.Entities.Tickets;
using Ticketing.Domain.Entities.Tickets.TicketStates;

namespace Ticketing.Infrustructure.Repositories
{
    public class TicketRepository(AppDbContext _context) : BaseRepository<AppDbContext, Guid, Ticket>(_context), ITicketRepository
    {
        public async Task<int> GetCountByStatus(Guid currentUserId, string status)
        {
            var statusId = TicketStatusFactory.GetTicketStatusState(status);
            return await _context.Tickets.Where(d => 
                d.AssignedToUserId == currentUserId && 
                (statusId == null || d.Status == statusId)).CountAsync();
        }

        public async Task<Ticket> GetEmployeeTicketById(Guid id, Guid currentEmployeeId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(d => d.Id == id && d.CreatedByUserId == currentEmployeeId);
        }

        public async Task<List<Ticket>> GetEmployeeTickets(Guid currentEmployeeId)
        {
            return await _context.Tickets.Where(d => d.CreatedByUserId == currentEmployeeId).ToListAsync();
        }

        public async Task<Ticket> GetAssignedTicketByIdAsync(Guid currentUserId, Guid id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(d => d.Id == id && d.AssignedToUserId == currentUserId);
        }

        public async Task<List<Ticket>> GetAssignedTickets(Guid currentUserId)
        {
            return await _context.Tickets.Where(d => d.AssignedToUserId == currentUserId).ToListAsync();
        }
    }
}
