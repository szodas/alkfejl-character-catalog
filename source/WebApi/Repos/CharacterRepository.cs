using DataAccess;
using Domain;
using MongoDB.Driver;

namespace WebApi.Repos;

public class CharacterRepository : ICharacterRepository
{
    private readonly IMongoDbConnectionFactory dbFactory;

    public CharacterRepository(IMongoDbConnectionFactory dbFactory)
    {
        this.dbFactory = dbFactory;
    }

    protected IMongoCollection<Character> Collection => dbFactory.GetDatabase().GetCollection<Character>("Characters");

    public async Task<Character?> GetCharacter(Guid id, CancellationToken ct = default)
    {
        var filter = Builders<Character>.Filter.Eq(character => character.Id, id);
        FindOptions<Character>? opts = null;

        var cursor = await Collection.FindAsync(filter, opts, ct);

        return await cursor.SingleOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<Character>> GetCharacters(CancellationToken ct = default)
    {
        var filter = Builders<Character>.Filter.Empty;
        FindOptions<Character>? opts = null;

        var cursor = await Collection.FindAsync(filter, opts, ct);

        return await cursor.ToListAsync(ct);
    }

    public async Task<Guid> CreateCharacter(Character character, CancellationToken ct = default)
    {
        InsertOneOptions? opts = null;

        await Collection.InsertOneAsync(character, opts, ct);

        return character.Id;
    }

    public async Task<bool> UpdateCharacter(Character character, CancellationToken ct = default)
    {
        var filter = Builders<Character>.Filter.Eq(c => c.Id, character.Id);
        var opts = new ReplaceOptions { IsUpsert = true };

        var result = await Collection.ReplaceOneAsync(filter, character, opts, ct);

        return result.IsAcknowledged && result.IsModifiedCountAvailable && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteCharacter(Guid id, CancellationToken ct = default)
    {
        var filter = Builders<Character>.Filter.Eq(c => c.Id, id);
        DeleteOptions? opts = null;

        var result = await Collection.DeleteManyAsync(filter, opts, ct);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}