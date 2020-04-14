using Core;
using IdentityModel;
using IdentityServers.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServers.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            AuthenticationProperties props = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(1))
            };
            var claimIdentity = new ClaimsIdentity();
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            claimIdentity.AddClaim(new Claim(EnumUserClaim.DisplayName, user.UserName));
            claimIdentity.AddClaim(new Claim(EnumUserClaim.UserId, user.SubjectId));
            claimIdentity.AddClaim(new Claim(JwtClaimTypes.Role, user.Role.ToString()));
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(user.SubjectId.ToString(), claimsPrincipal, props);
            return View();
        }
    }
}
