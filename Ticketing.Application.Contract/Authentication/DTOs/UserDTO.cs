using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Contract.Enums;

namespace Ticketing.Application.Contract.Authentication.DTOs
{
    public class UserDTO
    {
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public string Role { get;  set; }
        public Guid Id { get;  set; }
    }
}
