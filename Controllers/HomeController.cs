using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Projekt_internety2.Models;

using System.Data.SqlClient;
using System.Data;
using Projekt_internety2.Services;

namespace Projekt_internety2.Controllers
{
    [Route("api/[controller]")]
    public class HomeController :  ApiControllerAttribute
    {
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet("[action]")]
        //public IEnumerable<Usermodel> GetUsermodels()
        public ActionResult<List<Usermodel>> GetUsermodels()
        {
            return _userService.Get();

            //return users;
        }

        [HttpGet("[action]")]
        public Object GetUser(string login)
        {
            var users = _userService.Get();;
            var user = users.FirstOrDefault((p)=> p.login == login);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        [HttpGet("[action]")]
        public int Login(string login, string password)
        {
            var users = _userService.Get();;
            var user = users.FirstOrDefault((p)=> p.login == login);
            if (user == null)
            {
                return -1;
            }
            else if(user.password != password)
            {
                return 0;
            }
            return 1;
        }

        [HttpPost("[action]")]
        public Usermodel CreateUser(string login,string password)
        {
            
            if(login == null || password==null)
            {
                return new Usermodel("Error","Error");
            }
            return _userService.Create(new Usermodel(login,password));
            
        }
        

    }
}