using System.Net;

namespace Ticketing.Core.Exceptions
{
    public class PasswordsDoNotMatchException : BusinessException
    {
        public PasswordsDoNotMatchException() : base(Convert.ToInt32(HttpStatusCode.BadRequest), "passwords do not match")
        {
        }
    }
}
