using Ticketing.Domain.Contract.Enums;

namespace Ticketing.Application.Extensions;

public static class EnumExtensions
{
    public static TicketPriority ToEnum(this string input)
    {
        return (TicketPriority)Enum.Parse(typeof(TicketPriority), input, ignoreCase: true);

    }

}