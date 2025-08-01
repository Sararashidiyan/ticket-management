using System.Net;

namespace Ticketing.Core.Exceptions
{
    public class UserAlreadyExistException : CustomException
    {
        public UserAlreadyExistException() : base(Convert.ToInt32(HttpStatusCode.Conflict), "User already exists")
        {
        }
    }
}
