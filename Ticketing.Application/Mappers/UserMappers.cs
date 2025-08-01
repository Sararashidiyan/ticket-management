using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Contract.Authentication.DTOs;
using Ticketing.Domain.Entities.Users;

namespace Ticketing.Application.Mappers
{
    public static class UserMappers
    {
        public static UserDTO Map(User user)
        {
            return new UserDTO
            {
                Id=user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString(),

            };
        }
    }
   
}
