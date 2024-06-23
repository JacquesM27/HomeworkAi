using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Queries.OpenAnswer;
using Microsoft.AspNetCore.Builder;

namespace HomeworkAi.Modules.OpenAi.Endpoints;

internal static class OpenAnswerEndpoints
{
    internal static WebApplication AddOpenAnswerEndpoints(this WebApplication app)
    {
        const string route = "open-answer";
        const string tag = "Open Answer";
        
        app.MapPostEndpoint<SentencesTranslationQuery, OpenAnswerExerciseResponse<SentencesTranslation>, SentencesTranslation>(route, "sentences-translation", tag);
        app.MapPostEndpoint<SentenceWithVerbToCompleteBasedOnInfinitiveQuery, OpenAnswerExerciseResponse<SentenceWithVerbToCompleteBasedOnInfinitive>, SentenceWithVerbToCompleteBasedOnInfinitive>(route, "sentences-with-verb-to-complete-based-on-infinitive", tag);

        return app;
    }
}