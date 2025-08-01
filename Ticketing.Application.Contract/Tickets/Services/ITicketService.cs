using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Contract.Tickets.DTOs;

namespace Ticketing.Application.Contract.Tickets.Services
{
    public interface ITicketService
    {
        Task Create(CreateTicketDTO item);
        Task Delete(Guid id);
        Task<List<TicketDTO>> GetAll();
        Task<TicketDTO> GetById(Guid id);
        Task<List<TicketDTO>> GetByStatus(string status);
        Task<TicketDTO> GetEmployeeTicketById(Guid id);
        Task<List<TicketDTO>> GetEmployeeTickets();
        Task Update(Guid id);
    }
}
