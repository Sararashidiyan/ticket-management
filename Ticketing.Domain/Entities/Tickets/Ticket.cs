using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Common;
using Ticketing.Domain.Contract.Enums;

namespace Ticketing.Domain.Entities.Tickets
{
    public class Ticket : EntityBase, IAggregateRoot
    {
        public Ticket()
        {
            
        }
        public Ticket(string title,string description, TicketPriority priority)
        {
            CreatedAt = DateTime.Now;
            Title = title;
            Priority = priority;
            Description = description;
            //Status
        }
        public void AssignTicketToAdmin(Guid userId)
        {
            AssignedToUserId = userId;
            UpdatedAt = DateTime.Now;
            //Status

        }
        public string Title { get;private set; }
        public string Description { get;private set; }
        public int Status { get;private set; }
        public TicketPriority Priority { get;private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public Guid? AssignedToUserId { get; private set; }
    }
}
