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
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(user.Id.ToString(), claimsPrincipal, props);
            return View();
        }
    }
}
