using MongoDB.Bson.Serialization.Attributes;

namespace Products_reviews.Model
{
    public class Reviews
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string RatingId { get; set; }
        public string ItemId { get; set; }
        public string UserId { get; set; }
        public string RatingNumber { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
    }

}
