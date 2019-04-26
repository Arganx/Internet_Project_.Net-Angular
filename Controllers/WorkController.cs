using System.Collections.Generic;
using Projekt_internety2.Models;
using Projekt_internety2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using MongoDB.Bson;

namespace Projekt_internety2.Controllers
{
    [Route("api/[controller]")]
    public class WorkController :  ApiControllerAttribute
    {
        private readonly WorkService _workService;

        public WorkController(WorkService workService)
        {
            _workService = workService;
        }

        [HttpGet("[action]")]
        public ActionResult<List<WorkModel>> GetWorkList()
        {
            return _workService.Get();

            //return users;
        }

        [HttpPost("[action]")]
        public WorkModel insertWork(string description, string type,string client,string project,DateTime start, DateTime finish)
        {
                Console.WriteLine(description);
                Console.WriteLine(type);
                Console.WriteLine(start.ToLocalTime());
                return _workService.Create(new WorkModel(description,type,client,project,start.ToLocalTime(),finish.ToLocalTime()));
        }
/* 
        [HttpGet("[action]")]
        public System.Collections.Generic.IEnumerable<Projekt_internety2.Models.WorkModel> GetWorkersWork(string login,int day, string month,int year)
        {
            var workers =_workService.Get();
            var selected = workers.Where((w)=>w.login==login);
            selected = workers.Where((w)=>w.day==day);
            selected = workers.Where((w)=>w.year==year);
            selected = workers.Where((w)=>w.month.Equals(month));
            return selected;

            //return users;
        }
        */
    }
}