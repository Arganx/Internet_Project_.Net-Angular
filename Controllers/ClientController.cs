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
    public class ClientController :  ApiControllerAttribute
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("[action]")]
        public ActionResult<List<ClientModel>> GetAllClients()
        {
            Console.WriteLine("In");
            return _clientService.Get();
        }

        [HttpGet("[action]")]
        public Object GetClient(string full_name)
        {
            var clients = _clientService.Get();;
            var client = clients.FirstOrDefault((p)=> p.full_name == full_name);
            if (client == null)
            {
                return null;
            }
            return client;
        }
    }
}