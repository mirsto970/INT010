using INT0010._4PS.Services.CodeBase;
using INT0010._4PS.Services.Entity;
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
    public class LookupController : ADRoleController
    {
        private readonly IConfiguration _config;

        public LookupController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{domain}/{operation}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LookupTable))]
        public ActionResult Get(string domain,TableType operation)
        {
            CommonParameters common = new CommonParameters(_config, domain);

            LookupTableCodeBase codeBase = new LookupTableCodeBase();

            LookupTable response = codeBase.GetLookupTable(common,operation);

            return Ok(response);
        }
    }
}
