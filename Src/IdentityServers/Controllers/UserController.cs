using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServers.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<object> Get()
        {
            //通过ClaimsPrincipal（证件容器载体）获得某些证件的身份元件
            var userId = User.UserId();
            return new
            {
                name = User.Name(),
                userId = userId,
                displayName = User.DisplayName()
            };
        }
    }
}
