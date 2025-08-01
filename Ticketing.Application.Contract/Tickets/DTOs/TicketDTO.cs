namespace Ticketing.Application.Contract.Tickets.DTOs
{
    public class TicketDTO
    {
        public Guid Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string Status { get;  set; }
        public string Priority { get;  set; }
        public string CreatedAt { get;  set; }
        public string? UpdatedAt { get;  set; }
        public string CreatedByUserName { get;  set; }
        public string? AssignedToUserName { get;  set; }
    }
}
