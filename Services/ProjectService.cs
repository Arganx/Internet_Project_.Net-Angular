using System.Collections.Generic;
using System.Linq;
using Projekt_internety2.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Projekt_internety2.Services
{
    public class ProjectService
    {
        private readonly IMongoCollection<ProjectModel> _projects;

        public ProjectService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Testdb"));
            var database = client.GetDatabase("Testdb");
            _projects = database.GetCollection<ProjectModel>("Projects");
        }

        public List<ProjectModel> Get()
        {
            return _projects.Find(project => true).ToList();
        }

        public ProjectModel Get(string id)
        {
            return _projects.Find<ProjectModel>(project => project.Id == id).FirstOrDefault();
        }

        public ProjectModel Create(ProjectModel project)
        {
            _projects.InsertOne(project);
            return project;
        }

        public void Update(string id, ProjectModel projectIn)
        {
            _projects.ReplaceOne(project => project.Id == id, projectIn);
        }

        public void Remove(ProjectModel projectIn)
        {
            _projects.DeleteOne(project => project.Id == projectIn.Id);
        }

        public void Remove(string id)
        {
            _projects.DeleteOne(project => project.Id == id);
        }
    }
}