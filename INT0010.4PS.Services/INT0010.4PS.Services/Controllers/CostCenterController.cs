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
    public class CostCenterController : ADRoleController
    {
        private readonly IConfiguration _config;

        public CostCenterController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{domain}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CostCenters))]
        public ActionResult Get(string domain)
        {
            CommonParameters common = new CommonParameters(_config, domain);

            CostCenterCodeBase codeBase = new CostCenterCodeBase();

            CostCenters response = codeBase.GetCostCenterList(common);

            return Ok(response);
        }
    }
}
