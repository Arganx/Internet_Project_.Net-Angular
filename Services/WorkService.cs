using System.Collections.Generic;
using System.Linq;
using Projekt_internety2.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Projekt_internety2.Services
{
    public class WorkService
    {
        private readonly IMongoCollection<WorkModel> _works;

        public WorkService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Testdb"));
            var database = client.GetDatabase("Testdb");
            _works = database.GetCollection<WorkModel>("Work");
        }

        public List<WorkModel> Get()
        {
            return _works.Find(work => true).ToList();
        }

        public WorkModel Get(string id)
        {
            return _works.Find<WorkModel>(work => work.Id == id).FirstOrDefault();
        }

        public WorkModel Create(WorkModel work)
        {
            _works.InsertOne(work);
            return work;
        }

        public void Update(string id, WorkModel workIn)
        {
            _works.ReplaceOne(work => work.Id == id, workIn);
        }

        public void Remove(WorkModel workIn)
        {
            _works.DeleteOne(work => work.Id == workIn.Id);
        }

        public void Remove(string id)
        {
            _works.DeleteOne(work => work.Id == id);
        }
    }
}