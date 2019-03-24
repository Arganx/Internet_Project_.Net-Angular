using System.Collections.Generic;
using System.Linq;
using Projekt_internety2.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Projekt_internety2.Services
{
    public class PossitionService
    {
        private readonly IMongoCollection<PossitionModel> _possitions;

        public PossitionService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Testdb"));
            var database = client.GetDatabase("Testdb");
            _possitions = database.GetCollection<PossitionModel>("Possition");
        }

        public List<PossitionModel> Get()
        {
            return _possitions.Find(possition => true).ToList();
        }

        public PossitionModel Get(string id)
        {
            return _possitions.Find<PossitionModel>(possition => possition.Id == id).FirstOrDefault();
        }

        public PossitionModel Create(PossitionModel possition)
        {
            _possitions.InsertOne(possition);
            return possition;
        }

        public void Update(string id, PossitionModel possitionIn)
        {
            _possitions.ReplaceOne(possition => possition.Id == id, possitionIn);
        }

        public void Remove(PossitionModel possitionIn)
        {
            _possitions.DeleteOne(possition => possition.Id == possitionIn.Id);
        }

        public void Remove(string id)
        {
            _possitions.DeleteOne(possition => possition.Id == id);
        }
    }
}