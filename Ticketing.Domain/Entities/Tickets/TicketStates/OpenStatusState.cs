namespace Ticketing.Domain.Entities.Tickets.TicketStates;

[StateValue(1, "Open")]

public class OpenStatusState : TicketStatusState
{
    public override TicketStatusState InProgress()
    {
        return base.InProgress();
    }
}