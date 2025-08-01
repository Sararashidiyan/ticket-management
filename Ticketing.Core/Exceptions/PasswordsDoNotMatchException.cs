using System.Net;

namespace Ticketing.Core.Exceptions
{
    public class PasswordsDoNotMatchException : CustomException
    {
        public PasswordsDoNotMatchException() : base(Convert.ToInt32(HttpStatusCode.BadRequest), "passwords do not match")
        {
        }
    }
}
