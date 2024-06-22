using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace HomeworkAi.Modules.OpenAi.Endpoints;

internal static class Extensions
{
    internal static void MapPostEndpoint<TQuery, TResponse, TExercise>(this IEndpointRouteBuilder app, string route, string endpoint, string tag)
        where TQuery : class, IQuery<TResponse> where TResponse : ExerciseResponse<TExercise>
    {
        app.MapPost($"/{route}/{endpoint}", async (TQuery query, IQueryDispatcher queryDispatcher) =>
            {
                var response = await queryDispatcher.QueryAsync(query);
                return Results.Ok(response);
            })
            .Produces<TResponse>()
            .WithTags(tag);
    }
}