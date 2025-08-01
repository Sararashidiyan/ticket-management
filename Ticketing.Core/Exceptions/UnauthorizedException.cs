using System.Net;

namespace Ticketing.Core.Exceptions
{
    public class UnauthorizedException : CustomException
    {
        public UnauthorizedException() : base(Convert.ToInt32(HttpStatusCode.Unauthorized), "unauthorized")
        {
        }
    }
}
