using DataAccess;
using Domain;
using MongoDB.Bson;
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

app.MapGet("/mcp/tools", () =>
{
    return Results.Ok(new[]
    {
        new { name = "get-characters", description = "Returns all characters." },
        new { name = "get-character-by-id", description = "Returns one character by id." },
        new { name = "search-characters-by-name", description = "Search characters by name pattern." }
    });
});

app.MapGet("/mcp/get-characters", async (IMongoDbConnectionFactory dbFactory, CancellationToken ct) =>
{
    var collection = dbFactory.GetDatabase().GetCollection<Character>("Characters");
    var result = await collection.Find(Builders<Character>.Filter.Empty).ToListAsync(ct);
    return Results.Ok(result);
});

app.MapGet("/mcp/get-character/{id}", async (Guid id, IMongoDbConnectionFactory dbFactory, CancellationToken ct) =>
{
    var collection = dbFactory.GetDatabase().GetCollection<Character>("Characters");
    var filter = Builders<Character>.Filter.Eq(c => c.Id, id);
    var result = await collection.Find(filter).SingleOrDefaultAsync(ct);

    return result is null ? Results.NotFound() : Results.Ok(result);
});

app.MapGet("/mcp/search", async (string pattern, IMongoDbConnectionFactory dbFactory, CancellationToken ct) =>
{
    var collection = dbFactory.GetDatabase().GetCollection<Character>("Characters");
    var regex = new BsonRegularExpression(pattern, "i");
    var filter = Builders<Character>.Filter.Regex(c => c.Name, regex);
    var result = await collection.Find(filter).ToListAsync(ct);

    return Results.Ok(result);
});

app.Run("http://localhost:5003");