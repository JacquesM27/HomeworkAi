using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Queries.OpenForm;
using Microsoft.AspNetCore.Builder;

namespace HomeworkAi.Modules.OpenAi.Endpoints;

internal static class OpenFormEndpoints
{
    internal static WebApplication AddOpenFormEndpoints(this WebApplication app)
    {
        const string route = "open-form";
        const string tag = "OpenForm";

        app.MapPostEndpoint<MailQuery, OpenFormExerciseResponseMail, Mail>(route, "mail", tag);
        app.MapPostEndpoint<EssayQuery, OpenFormExerciseResponseEssay, Essay>(route, "essay", tag);
        app.MapPostEndpoint<SummaryOfTextQuery, OpenFormExerciseResponseSummaryOfText, SummaryOfText>(route,
            "summary-of-text", tag);

        return app;
    }
}