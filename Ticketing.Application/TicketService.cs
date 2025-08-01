using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Contract.Tickets.DTOs;
using Ticketing.Application.Contract.Tickets.Services;
using Ticketing.Application.Extensions;
using Ticketing.Application.Mappers;
using Ticketing.Core;
using Ticketing.Core.Exceptions;
using Ticketing.Domain.Entities.Tickets;
using Ticketing.Domain.Entities.Users;

namespace Ticketing.Application
{
    public class TicketService(ITicketRepository _ticketRepository, IUserRepository _userRepository, IClaimHelper claimHelper) : ITicketService
    {
        public async Task Create(CreateTicketDTO item)
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var newTicket = new Ticket(item.Title, item.Description, item.Priority.ToEnum(), currentUserId);
            await _ticketRepository.CreateAsync(newTicket);
        }

        public async Task Delete(Guid id)
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var ticket = await _ticketRepository.GetAssignedTicketByIdAsync(currentUserId, id);
            GuardAgainstNullValue(ticket);
            await _ticketRepository.DeleteAsync(ticket);
        }

        public async Task<List<TicketDTO>> GetAll()
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var tickets = await _ticketRepository.GetAssignedTickets(currentUserId);
            var usersSummaryInfo =await _userRepository.GetSummaryInfo();
            return TicketMappers.Map(tickets, usersSummaryInfo);
        }

        public async Task<TicketDTO> GetById(Guid id)
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var ticket = await _ticketRepository.GetAssignedTicketByIdAsync(currentUserId,id);
            GuardAgainstNullValue(ticket);
            var usersSummaryInfo = await GetUsersSummaryInfo(ticket);
            return TicketMappers.Map(ticket, usersSummaryInfo);
        }

       
        public async Task<int> GetCountByStatus(string status)
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            return await _ticketRepository.GetCountByStatus(currentUserId,status);
        }

        public async Task<TicketDTO> GetEmployeeTicketById(Guid id)
        {
            var currentEmployeeId = claimHelper.GetCurrentUserId();
            var ticket = await _ticketRepository.GetEmployeeTicketById(id, currentEmployeeId);
            GuardAgainstNullValue(ticket);
            var usersSummaryInfo = await GetUsersSummaryInfo(ticket);
            return TicketMappers.Map(ticket, usersSummaryInfo);
        }

        private async Task<List<UserSummaryInfo>> GetUsersSummaryInfo(Ticket ticket)
        {
            var userIds = new List<Guid>() { ticket.CreatedByUserId };
            if(ticket.AssignedToUserId!=null)
                userIds.Add(ticket.AssignedToUserId.Value);
            var usersSummaryInfo = await _userRepository.GetSummaryInfoByIds(userIds);
            return usersSummaryInfo;
        }

        public async Task<List<TicketDTO>> GetEmployeeTickets()
        {
            var currentEmployeeId = claimHelper.GetCurrentUserId();
            var tickets = await _ticketRepository.GetEmployeeTickets(currentEmployeeId);
            var usersSummaryInfo = await _userRepository.GetSummaryInfo();
            return TicketMappers.Map(tickets, usersSummaryInfo);
        }

        public async Task Update(Guid id)
        {
            var currentUserId = claimHelper.GetCurrentUserId();
            var ticket = await _ticketRepository.GetByIdAsync(id);
            GuardAgainstNullValue(ticket);
            ticket.AssignTicketToAdmin(currentUserId);
            await _ticketRepository.UpdateAsync(ticket);
        }
        private void GuardAgainstNullValue(Ticket ticket)
        {
            if (ticket == null) throw new NotFoundException();
        }

    }
}
