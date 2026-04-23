using Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Repos;

namespace WebApi.Endpoints;

internal static class CharacterHandlers
{
    internal static RouteGroupBuilder MapCharacterEndpoints(this RouteGroupBuilder routes)
    {
        routes.MapGet("", async ([FromServices] ICharacterRepository repo, CancellationToken ct) =>
        {
            var result = await repo.GetCharacters(ct);
            return Results.Ok(result);
        })
        .WithName("GetCharacters");

        routes.MapGet("/{id}", async ([FromRoute] Guid id, [FromServices] ICharacterRepository repo, CancellationToken ct) =>
        {
            return await repo.GetCharacter(id, ct) is Character character
                ? Results.Ok(character)
                : Results.NotFound();
        }).WithName("GetCharacter");

        routes.MapPost("", async ([FromBody] Character character, [FromServices] ICharacterRepository repo, CancellationToken ct) =>
        {
            Guid characterId = await repo.CreateCharacter(character, ct);
            return Results.Created($"/{characterId}", character);
        }).AddEndpointFilter<RequestValidationFilter>().WithName("CreateCharacter");

        routes.MapPut("/{id}", async ([FromRoute] Guid id, [FromBody] Character character, [FromServices] ICharacterRepository repo, CancellationToken ct) =>
        {
            if (id != character.Id) return Results.BadRequest("ID mismatch.");
            bool updated = await repo.UpdateCharacter(character, ct);
            return Results.Ok(new { id, updated });
        }).AddEndpointFilter<RequestValidationFilter>().WithName("UpdateCharacter");

        routes.MapDelete("/{id}", async ([FromRoute] Guid id, [FromServices] ICharacterRepository repo, CancellationToken ct) =>
        {
            bool deleted = await repo.DeleteCharacter(id, ct);
            return Results.Ok(new { id, deleted });
        }).WithName("DeleteCharacter");

        return routes;
    }
}