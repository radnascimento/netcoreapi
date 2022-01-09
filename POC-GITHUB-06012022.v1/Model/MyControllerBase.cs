using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Model
{
    public class MyControllerBase : ControllerBase
    {
        public long IdAuthenticated
        {
            get
            {
                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

                if (userId != null)
                {
                    return Convert.ToInt64(userId);
                }
                else
                {
                    return 0;
                }
            }

        }
    }
}
