
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Projekt_internety2.Models
{
    public class PossitionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string name {get;set;}
        [BsonElement("Income")]
        public double income {get;set;}
        [BsonElement("Available leave days in a year")]
        public int freedays {get;set;}

        public PossitionModel(string name,double income, int freedays)
        {
            this.name=name;
            this.income=income;
            this.freedays=freedays;
        }
        
    }
}