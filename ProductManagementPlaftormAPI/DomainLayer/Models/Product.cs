using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductManagementPlaftormAPI.Domain.Models
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }

        //[BsonIgnoreIfNull]
        //public Category Category { get; set; }
    }
}
