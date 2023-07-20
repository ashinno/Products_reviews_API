# Product Review API Readme

This is a product review API built in C# and MongoDB. The API allows you to perform CRUD operations on product reviews.

## Requirements

- C# 
- MongoDB

## Installation

1. Clone the repository
2. Install the required packages using NuGet package manager
3. Update the `appsettings.json` file with your MongoDB connection string and database name.

## Usage

The API has the following endpoints:

- `GET /reviews` - Returns all reviews
- `GET /reviews/{id}` - Returns a specific review by ID
- `POST /reviews` - Creates a new review
- `PUT /reviews/{id}` - Updates an existing review by ID
- `DELETE /reviews/{id}` - Deletes a review by ID

## Configuration

The API uses `Products_reviewsDatabaseSettings` class to read the MongoDB connection string and database name from the `appsettings.json` file. 

```csharp
public class ReviewsService
{
    private readonly IMongoCollection<Reviews> _Reviews;
    
    public ReviewsService(IOptions<Products_reviewsDatabaseSettings> options)
    { 
        var mongoClient = new MongoClient(options.Value.ConnectionString);

        _Reviews = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Reviews>(options.Value.DatabaseName);
    }
}
```

