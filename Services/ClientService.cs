using System.Collections.Generic;
using System.Linq;
using Projekt_internety2.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Projekt_internety2.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<ClientModel> _clients;

        public ClientService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Testdb"));
            var database = client.GetDatabase("Testdb");
            _clients = database.GetCollection<ClientModel>("Client");
        }

        public List<ClientModel> Get()
        {
            return _clients.Find(client => true).ToList();
        }

        public ClientModel Get(string id)
        {
            return _clients.Find<ClientModel>(client => client.Id == id).FirstOrDefault();
        }

        public ClientModel Create(ClientModel client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public void Update(string id, ClientModel clientIn)
        {
            _clients.ReplaceOne(client => client.Id == id, clientIn);
        }

        public void Remove(ClientModel clientIn)
        {
            _clients.DeleteOne(client => client.Id == clientIn.Id);
        }

        public void Remove(string id)
        {
            _clients.DeleteOne(client => client.Id == id);
        }
    }
}