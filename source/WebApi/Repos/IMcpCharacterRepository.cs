using Domain;

namespace WebApi.Repos;

public interface IMcpCharacterRepository : ICharacterRepository
{
    Task<IEnumerable<Character>> GetCharactersByNamePattern(string pattern, CancellationToken ct = default);
}