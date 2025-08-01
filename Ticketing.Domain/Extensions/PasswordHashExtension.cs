using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Domain.Extensions
{
    public static class PasswordHashExtension
    {
        public static string HashPassword(this string password, byte[] salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: 100_000,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: 32);

            return Convert.ToBase64String(salt.Concat(hash).ToArray());
        }
    }
}
