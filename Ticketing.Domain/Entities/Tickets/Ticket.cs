using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Common;
using Ticketing.Domain.Contract.Enums;
using Ticketing.Domain.Entities.Tickets.TicketStates;

namespace Ticketing.Domain.Entities.Tickets
{
    public class Ticket : EntityBase, IAggregateRoot
    {
        public Ticket()
        {
            
        }
        public Ticket(string title,string description, TicketPriority priority,Guid createdByUserId)
        {
            CreatedAt = DateTime.Now;
            Title = title;
            Priority = priority;
            Description = description;
            CreatedByUserId = createdByUserId;
            StatusState = new OpenStatusState();
        }
        public void AssignTicketToAdmin(Guid userId)
        {
            AssignedToUserId = userId;
            UpdatedAt = DateTime.Now;
            StatusState = new InProgressStatusState();

        }
        public string Title { get;private set; }
        public string Description { get;private set; }
        public int Status { get;private set; }
        public TicketStatusState StatusState
        {
            get => TicketStatusFactory.Create(Status);
            private set => Status = TicketStatusFactory.Create(value);
        }
        public TicketPriority Priority { get;private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public Guid? AssignedToUserId { get; private set; }
    }
}
