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
    public class PossitionController :  ApiControllerAttribute
    {
        private readonly PossitionService _possitionService;

        public PossitionController(PossitionService possitionService)
        {
            _possitionService = possitionService;
        }

        [HttpGet("[action]")]
        public ActionResult<List<PossitionModel>> GetAllPossitions()
        {
            return _possitionService.Get();

            //return users;
        }
    }
}