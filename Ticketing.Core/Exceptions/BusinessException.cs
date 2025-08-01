using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Exceptions
{
    public class BusinessException:Exception
    {
        public int StatusCode { get; private set; }
        public string Message { get;private set; }
        public BusinessException(int statusCode,string message)
        {
            StatusCode = StatusCode;
            Message = message;
        }
    }
}
