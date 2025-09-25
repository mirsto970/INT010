using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SystemController : Controller
    {

        private readonly IConfiguration _config;

        public SystemController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get()
        {

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return Ok(environment);
        }

    }
}
