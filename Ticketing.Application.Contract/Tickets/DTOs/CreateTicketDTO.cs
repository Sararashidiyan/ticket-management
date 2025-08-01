using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Contract.Enums;

namespace Ticketing.Application.Contract.Tickets.DTOs
{
    public class CreateTicketDTO
    {
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string Priority { get;  set; }
    }
}
