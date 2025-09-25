using INT0010._4PS.Services.CodeBase;
using INT0010._4PS.Services.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VendorController : ADRoleController
    {
        private readonly IConfiguration _config;

        public VendorController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{domain}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Vendors))]
        public ActionResult Get(string domain,DateTime? changedAfter)
        {
            CommonParameters common = new CommonParameters(_config, domain);

            VendorCodeBase codeBase = new VendorCodeBase();

            Vendors response = codeBase.GetVendorList(common, changedAfter);

            return Ok(response);
        }

       
    }
}
