using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Contract.Authentication.DTOs;

namespace Ticketing.Application.Contract.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task AdminRegister(RegisterDTO item);
        Task EmployeeRegister(RegisterDTO item);
        Task<UserDTO> Authenticate(string email, string password);
    }
}
