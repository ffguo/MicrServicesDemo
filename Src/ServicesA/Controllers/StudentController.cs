using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.IdentityServer;

namespace ServicesA.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = nameof(EnumUserRole.SupperManage))]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            var userId = User.UserId();
            return new
            {
                name = User.Name(),
                userId = userId,
                displayName = User.DisplayName(),
                ServiceState = $"ServicesA - {Request.Host.Port}"
            };
            //return $"ServicesA - {Request.Host.Port}";
        }
    }
}