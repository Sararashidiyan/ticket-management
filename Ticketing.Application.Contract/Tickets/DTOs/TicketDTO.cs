namespace Ticketing.Application.Contract.Tickets.DTOs
{
    public class TicketDTO
    {
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string Status { get;  set; }
        public string Priority { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime? UpdatedAt { get;  set; }
        public Guid CreatedByUserId { get;  set; }
        public Guid? AssignedToUserId { get;  set; }
    }
}
