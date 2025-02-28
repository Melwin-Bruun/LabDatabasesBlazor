using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

// review of the books
namespace LabDatabasesBlazor.Model
{
    public class Review
    {
        [BsonElement("ReviewerName")]
        public string ReviewerName { get; set; } = "";

        [BsonElement("Rating")]
        public int Rating { get; set; } = 0;

        [BsonElement("Comment")]
        public string Comment { get; set; } = "";
    }
}
