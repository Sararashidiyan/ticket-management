using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ticketing.Core
{
    public class ClaimHelper: IClaimHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentUserId()
        {
            var userId =_httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(d => d.Type == AppClaimTypes.UserId)?.Value;
            return new Guid(userId);
        }
    }
}
