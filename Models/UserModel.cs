using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Projekt_internety2.Models
{
    public class Usermodel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}
        [BsonElement("login")]
        public string login {get;set;}
        [BsonElement("password")]
        public string password {get;set;}
         [BsonElement("salt")]
        public string salt {get;set;}

        public Usermodel(string login,string password, string salt)
        {
            this.login = login;
            this.password = password;
            this.salt=salt;
        }
        
    }
}