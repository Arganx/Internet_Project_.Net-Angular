using System.Collections.Generic;
using Projekt_internety2.Models;
using Projekt_internety2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Projekt_internety2.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController :  ApiControllerAttribute
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("[action]")]
        public ActionResult<List<ProjectModel>> GetProjectsList()
        {
            return _projectService.Get();

            //return users;
        }
    }
}