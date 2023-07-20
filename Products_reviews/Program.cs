using Products_reviews.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<Products_reviewsDatabaseSettings>(builder.Configuration.GetSection("Products_reviewsDatabaseSettings"));
builder.Services.AddSingleton<ReviewsService>();

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.MapGet("/", () => "Rating and Reviews API!");
// endpoint to return all  reviews
app.MapGet("/api/reviews", async(ReviewsService reviewsService) => await reviewsService.Get());
//endpoint to return one review
app.MapGet("/api/reviews/{id}", async (ReviewsService reviewsService, string id) =>
    {
    var review = await reviewsService.Get(id);
        return review is null ? Results.NotFound() : Results.Ok(review);
});


app.MapPost("/api/reviews", async(ReviewsService reviewsService, Reviews reviews) =>
{
    await reviewsService.Create(reviews);
    return Results.Ok();
});

app.MapPut("/api/reviews/{id}", async(ReviewsService reviewsService, string id, Reviews updateReview) =>
{
    var review = await reviewsService.Get(id);
    if (review is null) return Results.NotFound();
    updateReview.RatingId = review.RatingId;
    await reviewsService.Update(id,  updateReview);
    return Results.Ok();
});

app.MapDelete("/api/reviews/{id}", async (ReviewsService reviewsService, string id) =>
{
    var review = await reviewsService.Get(id);
    if (review is null) return Results.NotFound();

    await reviewsService.Remove(review.RatingId);
    return Results.NoContent();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
