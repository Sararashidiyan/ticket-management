using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Contract.Tickets.DTOs;
using Ticketing.Application.Contract.Tickets.Services;
using Ticketing.Application.Mappers;
using Ticketing.Core;
using Ticketing.Core.Exceptions;
using Ticketing.Domain.Entities.Tickets;

namespace Ticketing.Application
{
    public class TicketService(ITicketRepository _repository,IClaimHelper claimHelper) : ITicketService
    {
        public async Task Create(CreateTicketDTO item)
        {
            var newTicket = new Ticket(item.Title, item.Description, item.Priority);
            await _repository.CreateAsync(newTicket);
        }

        public async Task Delete(Guid id)
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var ticket = await _repository.GetAssignedTicketByIdAsync(currentUserId, id);
            GuardAgenstNullValue(ticket);
            await _repository.DeleteAsync(ticket.Id);
        }

        public async Task<List<TicketDTO>> GetAll()
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var tickets = await _repository.GetAssignedTickets(currentUserId);
            return TicketMappers.Map(tickets);
        }

        public async Task<TicketDTO> GetById(Guid id)
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var ticket = await _repository.GetAssignedTicketByIdAsync(currentUserId,id);
            GuardAgenstNullValue(ticket);
            return TicketMappers.Map(ticket);
        }

       
        public async Task<List<TicketDTO>> GetByStatus(string status)
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var tickets = await _repository.GetByStatus(currentUserId,status);
            return TicketMappers.Map(tickets);
        }

        public async Task<TicketDTO> GetEmployeeTicketById(Guid id)
        {
            var currentEmployeeId = claimHelper.GetCurrentUserId();
            var ticket = await _repository.GetEmployeeTicketById(id, currentEmployeeId);
            GuardAgenstNullValue(ticket);
            return TicketMappers.Map(ticket);
        }

        public async Task<List<TicketDTO>> GetEmployeeTickets()
        {
            var currentEmployeeId = claimHelper.GetCurrentUserId();
            var tickets = await _repository.GetEmployeeTickets(currentEmployeeId);
            return TicketMappers.Map(tickets);
        }

        public async Task Update(Guid id)
        {
            var currentEmployeeId = claimHelper.GetCurrentUserId();
            var ticket = await _repository.GetByIdAsync(id);
            GuardAgenstNullValue(ticket);
            ticket.AssignTicketToAdmin(currentEmployeeId);
        }
        private void GuardAgenstNullValue(Ticket ticket)
        {
            if (ticket == null) throw new NotFoundException();
        }

    }
}
