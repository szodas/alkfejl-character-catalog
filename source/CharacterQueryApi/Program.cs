using DataAccess;
using Domain;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMongoDbConnectionFactory, MongoDbConnectionFactory>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
});

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

app.MapGet("/character", async (IMongoDbConnectionFactory dbFactory, CancellationToken ct) =>
{
    var collection = dbFactory.GetDatabase().GetCollection<Character>("Characters");
    var result = await collection.Find(Builders<Character>.Filter.Empty).ToListAsync(ct);
    return Results.Ok(result);
});

app.MapGet("/character/{id}", async (Guid id, IMongoDbConnectionFactory dbFactory, CancellationToken ct) =>
{
    var collection = dbFactory.GetDatabase().GetCollection<Character>("Characters");
    var filter = Builders<Character>.Filter.Eq(c => c.Id, id);
    var result = await collection.Find(filter).SingleOrDefaultAsync(ct);

    return result is null ? Results.NotFound() : Results.Ok(result);
});

app.Run("http://localhost:5002");