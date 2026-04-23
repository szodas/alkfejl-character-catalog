using DataAccess;
using Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApi.Repos;

public class McpCharacterRepository : CharacterRepository, IMcpCharacterRepository
{
    public McpCharacterRepository(IMongoDbConnectionFactory dbFactory) : base(dbFactory)
    {
    }

    public async Task<IEnumerable<Character>> GetCharactersByNamePattern(string pattern, CancellationToken ct = default)
    {
        var regex = new BsonRegularExpression(pattern, "i");
        var filter = Builders<Character>.Filter.Regex(character => character.Name, regex);
        FindOptions<Character>? opts = null;

        var cursor = await Collection.FindAsync(filter, opts, ct);

        return await cursor.ToListAsync(ct);
    }
}