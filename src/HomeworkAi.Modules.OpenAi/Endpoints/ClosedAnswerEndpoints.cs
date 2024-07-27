using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.OpenAi.Queries.ClosedAnswer;
using Microsoft.AspNetCore.Builder;

namespace HomeworkAi.Modules.OpenAi.Endpoints;

internal static class ClosedAnswerEndpoints
{
    internal static WebApplication AddClosedAnswerEndpoints(this WebApplication app)
    {
        const string route = "closed-answer";
        const string tag = "ClosedAnswer";

        app.MapPostEndpoint<AnswerToQuestionClosedQuery, ClosedAnswerExerciseResponseAnswerToQuestion,
            AnswerToQuestionClosed>(route, "answer-to-question", tag);
        app.MapPostEndpoint<ConditionalClosedQuery, ClosedAnswerExerciseResponseConditional, ConditionalClosed>(route,
            "conditional", tag);
        app.MapPostEndpoint<MissingPhrasalVerbClosedQuery, ClosedAnswerExerciseResponseMissingPhrasalVerb,
            MissingPhrasalVerbClosed>(route, "missing-phrasal-verb", tag);
        app.MapPostEndpoint<MissingWordOrExpressionClosedQuery, ClosedAnswerExerciseResponseMissingWordOrExpression,
            MissingWordOrExpressionClosed>(route, "missing-word-or-expression", tag);
        app.MapPostEndpoint<ParaphrasingClosedQuery, ClosedAnswerExerciseResponseParaphrasing, ParaphrasingClosed>(
            route, "paraphrasing", tag);
        app.MapPostEndpoint<PassiveSideClosedQuery, ClosedAnswerExerciseResponsePassiveSide, PassiveSideClosed>(route,
            "passive-side", tag);
        app.MapPostEndpoint<QuestionsToTextClosedQuery, ClosedAnswerExerciseResponseQuestionsToText,
            QuestionsToTextClosed>(route, "questions-to-text", tag);
        app.MapPostEndpoint<WordMeaningClosedQuery, ClosedAnswerExerciseResponseWordMeaning, WordMeaningClosed>(route,
            "word-meaning", tag);

        return app;
    }
}