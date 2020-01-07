using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServicesA.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return $"ServicesA - {Request.Host.Port}";
        }
    }
}