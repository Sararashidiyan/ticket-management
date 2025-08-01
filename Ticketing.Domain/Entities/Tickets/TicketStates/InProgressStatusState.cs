namespace Ticketing.Domain.Entities.Tickets.TicketStates;

[StateValue(2, "InProgress")]

public class InProgressStatusState : TicketStatusState
{
    public override TicketStatusState Closed()
    {
        return base.Closed();
    }
}