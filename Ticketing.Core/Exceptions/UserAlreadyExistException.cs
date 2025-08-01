using System.Net;

namespace Ticketing.Core.Exceptions
{
    public class UserAlreadyExistException : BusinessException
    {
        public UserAlreadyExistException() : base(Convert.ToInt32(HttpStatusCode.Conflict), "User already exists")
        {
        }
    }
}
