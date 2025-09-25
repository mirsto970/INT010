using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INT0010._4PS.Services.Controllers
{
    
    [Authorize(Policy = "ADRoleOnly")]
    public class ADRoleController: Controller
    {
    }
}
