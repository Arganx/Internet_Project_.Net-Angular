
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Projekt_internety2.Models
{
    public class ClientModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Full Name")]
        public string full_name {get;set;}
        [BsonElement("Short Name")]
        public string short_name {get;set;}
        [BsonElement("Adress")]
        public string Adress {get;set;}
        [BsonElement("Phone")]
        public string phone {get;set;}
        
    }
}