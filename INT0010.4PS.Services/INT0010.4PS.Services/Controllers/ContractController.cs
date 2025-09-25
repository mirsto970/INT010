using INT0010._4PS.Services.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INT0010._4PS.Services;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Net;
using Microsoft.AspNetCore.Http;
using INT0010._4PS.Services.CodeBase;

namespace INT0010._4PS.Services.Controllers
{
  
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ADRoleController
    {
        private readonly IConfiguration _config;

        public ContractController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{domain}/{project}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contracts))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get(string domain, string project,string contract)
        {
            //http://BASURL/invo/GetExtensionProject/{domain}/{projectNo}[?contractNo]
            //https://localhost:44354/Contract/NO_VS/3316007475
            CommonParameters common = new CommonParameters(_config, domain);

            ContractCodeBase codeBase = new ContractCodeBase();

            Contracts resultContract = codeBase.GetExtensionProject(common, project,contract);

            if(resultContract == null)
            {
                return NotFound(new ProblemDetails { Title = $"Extension contract for project {project} not found" });
            }
            else
            {
                return Ok(resultContract);
            }
  
        }

        [HttpGet("{domain}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contracts))]
        public ActionResult Get(string domain,DateTime? changedAfter)
        {
            //http://BASURL/invo/GetExtensionProjects/{domain}?changedAfter={changedAfter}
            //https://localhost:44354/Contract/NO_VS?changedAfter=2021-10-26T08:26:00.00Z
            CommonParameters common = new CommonParameters(_config, domain);

            ContractCodeBase codeBase = new ContractCodeBase();

            Contracts resultContracts = codeBase.GetExtensionProjects(common, changedAfter);

            return Ok(resultContracts);
            

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WrappedCreateAndUpdateExtensionContractResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(WrappedCreateAndUpdateExtensionContractResponse))]
        public ActionResult Post(INT0010._4PS.Services.Entity.CreateAndUpdateContractRequest upsertContract)
        {
            CommonParameters common = new CommonParameters(_config);
          
            ContractCodeBase codeBase = new ContractCodeBase();

            CreateAndUpdateExtensionContractResponse response = codeBase.CreateAndUpdateExtensionContract(common, upsertContract.contract);

            WrappedCreateAndUpdateExtensionContractResponse wrappedResponse = new WrappedCreateAndUpdateExtensionContractResponse
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
