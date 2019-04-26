using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Projekt_internety2.Models
{
    public class WorkModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Start")]
        public BsonDateTime start {get;set;}
        [BsonElement("Finish")]
        public BsonDateTime finish {get;set;}
        [BsonElement("Description")]
        public string description {get;set;}
        [BsonElement("Client")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string client { get; set; }
        [BsonElement("Project")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string project { get; set; }
        [BsonElement("Type")]
        public string type {get;set;}

        public WorkModel(string description, string type,string client,string project,BsonDateTime start, BsonDateTime finish)
        {
            this.description=description;
            this.type=type;
            this.client=client;
            this.project=project;
            this.start=start;
            this.finish=finish;
        }
        
        
    }
}