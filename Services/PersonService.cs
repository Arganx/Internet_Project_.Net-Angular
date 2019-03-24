using System.Collections.Generic;
using System.Linq;
using Projekt_internety2.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Projekt_internety2.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<PersonModel> _person;
        private readonly IMongoCollection<Usermodel> _users;
        private readonly IMongoCollection<PossitionModel> _possitionss;
        public PersonService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Testdb"));
            var database = client.GetDatabase("Testdb");
            _person = database.GetCollection<PersonModel>("Person");
            _users = database.GetCollection<Usermodel>("Users");
            _possitionss = database.GetCollection<PossitionModel>("Possition");
        }

        public List<PersonModel> Get()
        {
            List<PersonModel> personList = _person.Find(person => true).ToList();
            return personList;
        }

        public class Wrapper
        {
            List<PersonModel> personList;
            List<Usermodel> userList;
            List<PossitionModel> possitionList;
            public Wrapper(List<PersonModel> personList, List<Usermodel> userList, List<PossitionModel> possitionList)
            {
                this.personList=personList;
                this.userList=userList;
                this.possitionList=possitionList;
            }
        }

        public class DetailPerson
        {
            public string Id { get; set; }

            public string FirstName {get;set;}
            public string LastName {get;set;}
            public int Age {get;set;}
            public string Possition_Name {get;set;}
            public double Possition_Income {get;set;}
            public int Possition_leave_days {get;set;}
            public string User_Name {get;set;}

            public DetailPerson(string id,string fn,string ln,int age,string pn,double pi,int pld,string un)
            {
                this.Id=id;
                this.FirstName=fn;
                this.LastName=ln;
                this.Age=age;
                this.Possition_Name=pn;
                this.Possition_Income=pi;
                this.Possition_leave_days=pld;
                this.User_Name=un;
            }
        }

        public List<DetailPerson> GetDetails()
        {
            List<PersonModel> personList = _person.Find(person => true).ToList();
            List<Usermodel> usersList=new List<Usermodel>();
            List<PossitionModel> possitionsList= new List<PossitionModel>();
            List<DetailPerson> detailList = new List<DetailPerson>();
            foreach (PersonModel element in personList)
            {
                Usermodel um = _users.Find<Usermodel>(user => user.id == element.User_id).FirstOrDefault();
                PossitionModel pm = _possitionss.Find<PossitionModel>(possition => possition.Id == element.Possition_id).FirstOrDefault();
                detailList.Add(new DetailPerson(element.Id,element.FirstName,element.LastName,element.Age,pm.name,pm.income,pm.freedays,um.login));
            }
            return detailList;
        }

        public PersonModel Get(string id)
        {
            return _person.Find<PersonModel>(person => person.Id == id).FirstOrDefault();
        }

        public PersonModel Create(PersonModel person)
        {
            _person.InsertOne(person);
            return person;
        }

        public void Update(string id, PersonModel personIn)
        {
            _person.ReplaceOne(person => person.Id == id, personIn);
        }

        public void Remove(PersonModel personIn)
        {
            _person.DeleteOne(person => person.Id == personIn.Id);
        }

        public void Remove(string id)
        {
            _person.DeleteOne(person => person.Id == id);
        }
    }
}