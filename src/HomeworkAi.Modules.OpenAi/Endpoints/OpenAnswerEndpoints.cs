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
        
        app.MapPostEndpoint<AnswerToQuestionOpenQuery, OpenAnswerExerciseResponse<AnswerToQuestionOpen>, AnswerToQuestionOpen>(route, "answer-to-question", tag);
        app.MapPostEndpoint<ConditionalOpenQuery, OpenAnswerExerciseResponse<ConditionalOpen>, ConditionalOpen>(route, "conditional", tag);
        app.MapPostEndpoint<IrregularVerbsQuery, OpenAnswerExerciseResponse<IrregularVerbs>, IrregularVerbs>(route, "irregular-verbs", tag);
        app.MapPostEndpoint<MissingPhrasalVerbOpenQuery, OpenAnswerExerciseResponse<MissingPhrasalVerbOpen>, MissingPhrasalVerbOpen>(route, "missing-phrasal-verb", tag);
        app.MapPostEndpoint<MissingWordOrExpressionOpenQuery, OpenAnswerExerciseResponse<MissingWordOrExpressionOpen>, MissingWordOrExpressionOpen>(route, "missing-word-or-expression", tag);
        app.MapPostEndpoint<ParaphrasingOpenQuery, OpenAnswerExerciseResponse<ParaphrasingOpen>, ParaphrasingOpen>(route, "paraphrasing", tag);
        app.MapPostEndpoint<PassiveSideOpenQuery, OpenAnswerExerciseResponse<PassiveSideOpen>, PassiveSideOpen>(route, "passive-side", tag);
        app.MapPostEndpoint<QuestionsToTextOpenQuery, OpenAnswerExerciseResponse<QuestionsToTextOpen>, QuestionsToTextOpen>(route, "questions-to-text", tag);
        app.MapPostEndpoint<SentencesTranslationQuery, OpenAnswerExerciseResponse<SentencesTranslation>, SentencesTranslation>(route, "sentences-translation", tag);
        app.MapPostEndpoint<SentenceWithVerbToCompleteBasedOnInfinitiveQuery, OpenAnswerExerciseResponse<SentenceWithVerbToCompleteBasedOnInfinitive>, SentenceWithVerbToCompleteBasedOnInfinitive>(route, "sentences-with-verb-to-complete-based-on-infinitive", tag);

        return app;
    }
}