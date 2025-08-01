using System.Net;

namespace Ticketing.Core.Exceptions
{
    public class UnauthorizedException : BusinessException
    {
        public UnauthorizedException() : base(Convert.ToInt32(HttpStatusCode.Unauthorized), "unauthorized")
        {
        }
    }
}
