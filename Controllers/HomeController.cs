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
            Console.WriteLine("Hi");
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
            if(login== "admin" && password == "admin")
            {
                return 2;
            }

            var users = _userService.Get();;
            var user = users.FirstOrDefault((p)=> p.login == login);
            if (user == null || user.salt==null)
            {
                return -1;
            }
            
            string saltS = user.salt;
            byte[] salt = Convert.FromBase64String(saltS);
            string EnteredPasswordHashed = Convert.ToBase64String(Encryption.PasswordHasher.ComputeHash(password,salt));

            if(user.password != EnteredPasswordHashed)
            {
                return 0;
            }
            return 1;
        }

        [HttpPost("[action]")]
        public Usermodel CreateUser(string login,string password)
        {
            byte[] salt = Encryption.PasswordHasher.GenerateSalt();
            byte[] hashed = Encryption.PasswordHasher.ComputeHash(password,salt);
            string saltS = Convert.ToBase64String(salt);
            string has = Convert.ToBase64String(hashed);
            Console.WriteLine("HIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIi");
            Console.WriteLine("Hashed :"+ has);
            if(login == null || password==null)
            {
                return new Usermodel("Error","Error","Error");
            }
            
            return _userService.Create(new Usermodel(login,has,saltS));
            
        }
        

    }
}