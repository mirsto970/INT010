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
    public class CustomerController : ADRoleController
    {
        private readonly IConfiguration _config;

        public CustomerController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{domain}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customers))]
        public ActionResult Get(string domain,DateTime changedAfter)
        {
            CommonParameters common = new CommonParameters(_config, domain);

            CustomerCodeBase codeBase = new CustomerCodeBase();

            Customers response = codeBase.GetCustomerList(common, changedAfter);

            return Ok(response);
        }
    }
}
