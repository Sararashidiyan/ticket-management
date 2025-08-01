using System.Net;

namespace Ticketing.Core.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException() : base(Convert.ToInt32(HttpStatusCode.NotFound), "not found!!!!!!!")
        {
        }
    }
}
