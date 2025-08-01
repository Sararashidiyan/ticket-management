using System.Net;

namespace Ticketing.Core.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException() : base(Convert.ToInt32(HttpStatusCode.NotFound), "not found!!!!!!!")
        {
        }
    }
}
