using Ticketing.Application.Contract.Tickets.DTOs;
using Ticketing.Domain.Entities.Tickets;

namespace Ticketing.Application.Mappers
{
    public static class TicketMappers
    {
        public static TicketDTO Map(Ticket ticket)
        {
            return new TicketDTO
            {
                Title= ticket.Title,
                Description= ticket.Description,
                AssignedToUserId= ticket.AssignedToUserId,
                CreatedAt= ticket.CreatedAt,
                CreatedByUserId= ticket.CreatedByUserId,
                //Status= ticket.Status,
                Priority=ticket.Priority.ToString(),
                UpdatedAt= ticket.UpdatedAt,
            };
        }

        public static List<TicketDTO> Map(List<Ticket> tickets)
        {
            return tickets?.Select(Map).ToList();
        }
    }
}
