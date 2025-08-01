using Ticketing.Application.Contract.Tickets.DTOs;
using Ticketing.Application.Extensions;
using Ticketing.Domain.Entities.Tickets;
using Ticketing.Domain.Entities.Tickets.TicketStates;
using Ticketing.Domain.Entities.Users;

namespace Ticketing.Application.Mappers
{
    public static class TicketMappers
    {
        public static TicketDTO Map(Ticket ticket, List<UserSummaryInfo> users)
        {
            return new TicketDTO
            {
                Id= ticket.Id,
                Title= ticket.Title,
                Description= ticket.Description,
                AssignedToUserName = users.FirstOrDefault(d=>d.Id==ticket.AssignedToUserId)?.FullName??"" ,
                CreatedAt= ticket.CreatedAt.ToPersianDate(),
                CreatedByUserName = users.FirstOrDefault(d => d.Id == ticket.CreatedByUserId)?.FullName ?? "",
                Status= ticket.StatusState.GetDescription(),
                Priority =ticket.Priority.ToString(),
                UpdatedAt= ticket.UpdatedAt?.ToPersianDate(),
            };
        }

        public static List<TicketDTO> Map(List<Ticket> tickets,List<UserSummaryInfo>users)
        {
            return tickets?.Select(u=>Map(u,users)).ToList();
        }
    }
}
