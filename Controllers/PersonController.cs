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
    public class PersonController :  ApiControllerAttribute
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("[action]")]
        public ActionResult<List<PersonModel>> GetAllPeople()
        {
            return _personService.Get();
        }

        [HttpGet("[action]")]
        public Object GetAllPeopleDetails()
        {
            return _personService.GetDetails();
        }
    }
}