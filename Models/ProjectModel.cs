using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Projekt_internety2.Models
{
    public class ProjectModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string name {get;set;}
        [BsonElement("duration")]
        public int duration {get;set;}
        [BsonElement("priority")]
        public int priority {get;set;}

        
    }
}