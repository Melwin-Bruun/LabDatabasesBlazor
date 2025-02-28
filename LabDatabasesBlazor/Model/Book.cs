

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace LabDatabasesBlazor.Model
{
    // the structure of the Book model
public class Book
        {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

            [BsonElement("Title")]
            public string Title { get; set; } = "";

            [BsonElement("Author")]
            public string Author { get; set; } = "";

            [BsonElement("PublishedDate")]
            public DateTime PublishedDate { get; set; }

        [BsonElement("Reviews")]
        public List<Review> Reviews { get; set; } = new List<Review>();
        }

        
    }


