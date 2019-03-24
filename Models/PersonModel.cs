
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Projekt_internety2.Models
{
    public class PersonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName {get;set;}
        [BsonElement("LastName")]
        public string LastName {get;set;}
        [BsonElement("Age")]
        public int Age {get;set;}
        [BsonElement("Possition_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Possition_id {get;set;}
        [BsonElement("User_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string User_id {get;set;}

        

        public PersonModel(string name,string lastName, int age, string possition_id,string user_id)
        {
            this.FirstName=name;
            this.LastName=lastName;
            this.Age=age;
            this.Possition_id=possition_id;
            this.User_id=user_id;
        }
        
    }
}