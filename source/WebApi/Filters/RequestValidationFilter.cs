using Domain;

namespace WebApi.Filters;

public class RequestValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        Character character = context.Arguments.OfType<Character>().Single();

        if (character.Id == Guid.Empty ||
            string.IsNullOrWhiteSpace(character.Name))
        {
            return Results.BadRequest("Incorrect character data.");
        }

        object? result = await next(context);
        return result;
    }
}