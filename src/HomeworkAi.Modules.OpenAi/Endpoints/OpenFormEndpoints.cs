using HomeworkAi.Modules.OpenAi.Commands.OpenForm;
using HomeworkAi.Modules.Contracts.Exercises;
using Microsoft.AspNetCore.Builder;

namespace HomeworkAi.Modules.OpenAi.Endpoints;

internal static class OpenFormEndpoints
{
    internal static WebApplication AddOpenFormEndpoints(this WebApplication app)
    {
        const string route = "open-form";
        const string tag = "Open Form";
        
        app.MapPostEndpoint<MailQuery, OpenFormExerciseResponse<Mail>, Mail>(route, "mail", tag);
        app.MapPostEndpoint<EssayQuery, OpenFormExerciseResponse<Essay>, Essay>(route, "essay", tag);
        app.MapPostEndpoint<SummaryOfTextQuery, OpenFormExerciseResponse<SummaryOfText>, SummaryOfText>(route, "summary-of-text", tag);
        
        return app;
    }
}