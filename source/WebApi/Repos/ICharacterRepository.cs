using Domain;

namespace WebApi.Repos;

public interface ICharacterRepository
{
    Task<Character?> GetCharacter(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Character>> GetCharacters(CancellationToken ct = default);
    Task<Guid> CreateCharacter(Character character, CancellationToken ct = default);
    Task<bool> UpdateCharacter(Character character, CancellationToken ct = default);
    Task<bool> DeleteCharacter(Guid id, CancellationToken ct = default);
}