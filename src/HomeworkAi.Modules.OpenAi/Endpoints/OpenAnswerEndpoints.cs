using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Commands.OpenAnswer;
using Microsoft.AspNetCore.Builder;

namespace HomeworkAi.Modules.OpenAi.Endpoints;

internal static class OpenAnswerEndpoints
{
    internal static WebApplication AddOpenAnswerEndpoints(this WebApplication app)
    {
        const string route = "open-answer";
        const string tag = "Open Answer";
        
        app.MapPostEndpoint<SentencesTranslationQuery, OpenAnswerExerciseResponse<SentencesTranslation>, SentencesTranslation>(route, "sentences-translation", tag);

        return app;
    }
}