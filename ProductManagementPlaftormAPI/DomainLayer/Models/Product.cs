using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductManagementPlaftormAPI.Domain.Models
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string ProductName { get; set; }

        [BsonRequired]
        public decimal Price { get; set; }

        [BsonRequired]
        public string ProductDescription { get; set; }

        //[BsonIgnoreIfNull]
        //public Category Category { get; set; }
    }
}
