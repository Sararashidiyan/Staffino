using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace LeaveManagementSystem.Core
{
    public static class ClaimHelper
    {
        public static Guid GetCurrentUser()
        {
            var result = Guid.Empty;
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            //if (!(Thread.CurrentPrincipal is { Identity: ClaimsIdentity identity })) return result;
            var id = identity.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
            if (id != null)
                Guid.TryParse(id.Value, out result);
            return result;
        }
    }
}
