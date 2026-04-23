using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain;

public record Character
{
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public required Guid Id { get; init; }

    public required string Name { get; init; }
}