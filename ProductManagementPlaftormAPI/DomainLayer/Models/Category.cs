using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductManagementPlaftormAPI.Domain.Models
{
    public class Category
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string CategoryName { get; set; }
        public IEnumerable<Product> ProudctList { get; set; }
            = new List<Product>();
    }
}
