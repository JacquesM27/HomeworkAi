using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;
using Microsoft.AspNetCore.Builder;

namespace HomeworkAi.Modules.OpenAi.Endpoints;

internal static class ClosedAnswerEndpoints
{
    internal static WebApplication AddClosedAnswerEndpoints(this WebApplication app)
    {
        const string route = "closed-answer";
        const string tag = "Closed Answer";
        
        app.MapPostEndpoint<AnswerToQuestionClosedQuery, ClosedAnswerExerciseResponse<AnswerToQuestionClosed>, AnswerToQuestionClosed>(route, "answer-to-question", tag);
        app.MapPostEndpoint<ConditionalClosedQuery, ClosedAnswerExerciseResponse<ConditionalClosed>, ConditionalClosed>(route, "conditional", tag);
        app.MapPostEndpoint<MissingPhrasalVerbClosedQuery, ClosedAnswerExerciseResponse<MissingPhrasalVerbClosed>, MissingPhrasalVerbClosed>(route, "missing-phrasal-verb", tag);
        app.MapPostEndpoint<MissingWordOrExpressionClosedQuery, ClosedAnswerExerciseResponse<MissingWordOrExpressionClosed>, MissingWordOrExpressionClosed>(route, "missing-word-or-expression", tag);
        app.MapPostEndpoint<ParaphrasingClosedQuery, ClosedAnswerExerciseResponse<ParaphrasingClosed>, ParaphrasingClosed>(route, "paraphrasing", tag);
        app.MapPostEndpoint<PassiveSideClosedQuery, ClosedAnswerExerciseResponse<PassiveSideClosed>, PassiveSideClosed>(route, "passive-side", tag);
        app.MapPostEndpoint<QuestionsToTextClosedQuery, ClosedAnswerExerciseResponse<QuestionsToTextClosed>, QuestionsToTextClosed>(route, "questions-to-text", tag);
        app.MapPostEndpoint<WordMeaningQuery, ClosedAnswerExerciseResponse<WordMeaning>, WordMeaning>(route, "word-meaning", tag);

        return app;
    }
}