using System.Collections.Generic;
using System.Linq;
using Projekt_internety2.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Projekt_internety2.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Usermodel> _books;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Testdb"));
            var database = client.GetDatabase("Testdb");
            _books = database.GetCollection<Usermodel>("Users");
        }

        public List<Usermodel> Get()
        {
            return _books.Find(book => true).ToList();
        }

        public Usermodel Get(string id)
        {
            return _books.Find<Usermodel>(book => book.id == id).FirstOrDefault();
        }

        public Usermodel Create(Usermodel book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Usermodel bookIn)
        {
            _books.ReplaceOne(book => book.id == id, bookIn);
        }

        public void Remove(Usermodel bookIn)
        {
            _books.DeleteOne(book => book.id == bookIn.id);
        }

        public void Remove(string id)
        {
            _books.DeleteOne(book => book.id == id);
        }
    }
}