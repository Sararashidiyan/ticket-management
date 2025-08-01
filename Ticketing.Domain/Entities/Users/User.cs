using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Common;
using Ticketing.Domain.Contract.Enums;
using Ticketing.Domain.Extensions;

namespace Ticketing.Domain.Entities.Users
{
    public class User : EntityBase, IAggregateRoot
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public byte[] SecurityStamp { get; private set; }
        public UserRole Role { get; private set; }
        public User()
        {

        }
        private User(string fullName, string email, string password, UserRole role)
        {
            FullName = fullName;
            Email = email;
            SecurityStamp = RandomNumberGenerator.GetBytes(16);
            PasswordHash = password.HashPassword(SecurityStamp);
            Role = role;
        }
        public static User CreateAdmin(string fullName, string email, string password)
        {
            return new User(fullName, email, password, UserRole.Admin);
        }
        public static User CreateEmployee(string fullName, string email, string password)
        {
            return new User(fullName, email, password, UserRole.Employee);
        }
      
    }
}
