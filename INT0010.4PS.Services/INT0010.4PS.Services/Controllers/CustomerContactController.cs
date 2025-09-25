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
    public class CustomerContactController : ADRoleController
    {
        private readonly IConfiguration _config;

        public CustomerContactController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{domain}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerContacts))]
        public ActionResult Get(string domain,DateTime? changedAfter)
        {
            CommonParameters common = new CommonParameters(_config, domain);

            CustomerContactCodeBase codeBase = new CustomerContactCodeBase();

            CustomerContacts response = codeBase.GetCustomerContactList(common, changedAfter);

            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WrappedCreateAndUpdateCustomerContactResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(WrappedCreateAndUpdateCustomerContactResponse))]
        public ActionResult Post(CustomerContactRequest contact)
        {
            CommonParameters common = new CommonParameters(_config);

            CustomerContactCodeBase codeBase = new CustomerContactCodeBase();

            CreateAndUpdateCustomerContactResponse response = codeBase.CreateAndCustomerContactPerson(common,contact.CustomerContact);

            WrappedCreateAndUpdateCustomerContactResponse wrappedResponse = new WrappedCreateAndUpdateCustomerContactResponse
            {
                Response = response
            };

            if (response.ErrorStatusCode == ((int)HttpStatusCode.OK).ToString())
            {
                return Ok(wrappedResponse);

            }
            else
            {
                return BadRequest(wrappedResponse);

            }
        }
    }
}
