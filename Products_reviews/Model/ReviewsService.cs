using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Products_reviews.Model
{
    public class ReviewsService
    {
        private readonly IMongoCollection<Reviews> _Reviews;
        
        public ReviewsService(IOptions<Products_reviewsDatabaseSettings> options)
        { 
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _Reviews = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Reviews>(options.Value.DatabaseName);
        }

        public async Task<List<Reviews>> Get() =>
            await _Reviews.Find(_ => true).ToListAsync();
        public async Task<Reviews> Get(string id) =>
             await _Reviews.Find(m => m.RatingId == id).FirstOrDefaultAsync();

        public async Task Create(Reviews newReviews) =>
            await _Reviews.InsertOneAsync(newReviews);

        public async Task Update(string id,Reviews updateReviews) =>
           await _Reviews.ReplaceOneAsync(m => m.RatingId == id, updateReviews);
        public async Task Remove(string id) =>
           await _Reviews.DeleteOneAsync(m => m.RatingId == id);
    }
}
