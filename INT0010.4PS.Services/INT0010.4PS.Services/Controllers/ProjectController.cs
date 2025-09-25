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
using System.ServiceModel;
using Assemblin.BizTalk.InvoDAL.InvoWS;

namespace INT0010._4PS.Services.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ADRoleController
    {
        private readonly IConfiguration _config;

        public ProjectController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("{domain}/{project}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projects))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get(string domain, string project)
        {
            
            CommonParameters common = new CommonParameters(_config, domain);

            ProjectCodeBase codeBase = new ProjectCodeBase();

            Projects resultProject = codeBase.GetProject(common, project);

            if (resultProject == null)
            {
                return NotFound(new ProblemDetails { Title = $"Project {project} not found" });
            }
            else
            {
                return Ok(resultProject);
            }

        }

        [HttpGet("{domain}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projects))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get(string domain, DateTime? changedAfter)
        {
            //https://localhost:44354/invo/Project/NO_VS?changedAfter=2021-11-30T22:29:00.00Z
            CommonParameters common = new CommonParameters(_config, domain);

            ProjectCodeBase codeBase = new ProjectCodeBase();

            Projects resultProjects = codeBase.GetProjects(common, changedAfter);

            if (resultProjects.ProjectListResponse.Count == 0)
            {
                return NotFound(new ProblemDetails { Title = $"No projects found after {changedAfter.ToString()}" });
            }
            else
            {
                return Ok(resultProjects);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WrappedCreateAndUpdateProjectResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(WrappedCreateAndUpdateProjectResponse))]
        public ActionResult Post(INT0010._4PS.Services.Entity.CreateAndUpdateProjectRequest upsertproject)
        {
            CommonParameters common = new CommonParameters(_config);

            ProjectCodeBase codeBase = new ProjectCodeBase();

            CreateAndUpdateProjectResponse response = codeBase.CreateAndUpdateProject(common, upsertproject.project);

            WrappedCreateAndUpdateProjectResponse wrappedResponse = new WrappedCreateAndUpdateProjectResponse
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
