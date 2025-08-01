using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Domain.Entities.Tickets.TicketStates
{
    public abstract class TicketStatusState
    {
        public virtual TicketStatusState Open()
        {
            throw new NotSupportedException();
        }
        public virtual TicketStatusState InProgress()
        {
            throw new NotSupportedException();
        }
        public virtual TicketStatusState Closed()
        {
            throw new NotSupportedException();
        }
    }

    public static class TicketStatusFactory
    {
        static List<TicketStatusState> states = new List<TicketStatusState>();

        static TicketStatusFactory()
        {
            states.Add(new OpenStatusState());
            states.Add(new InProgressStatusState());
            states.Add(new ClosedStatusState());
        }
        public static TicketStatusState Create(int stateType)
        {
            var item =
                states.First(a => a.GetType().GetCustomAttributes(typeof(StateValue), true).OfType<StateValue>().First().Value == stateType);

            return item;
        }
        public static int Create(TicketStatusState statusState)
        {
            var item = statusState.GetType().GetCustomAttributes<StateValue>().First().Value;
            return item;
        }
        public static string GetDescription(this TicketStatusState statusState)
        {
            var res = statusState.GetType().GetCustomAttributes(typeof(StateValue), true)
                .OfType<StateValue>().First().Text;
            return res;
        }

        public static int? GetTicketStatusState(string state)
        {
            return states.FirstOrDefault(statusState=>statusState.GetType().GetCustomAttributes(typeof(StateValue), true)
                .OfType<StateValue>().First().Text== state)?.GetType().GetCustomAttributes(typeof(StateValue), true)
                .OfType<StateValue>().First().Value;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class StateValue : Attribute
    {
        public int Value { get; private set; }
        public string Text { get; private set; }
        public StateValue(int value, string text)
        {
            Value = value;
            Text = text;
        }

    }
}
