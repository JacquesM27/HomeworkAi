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
        
        app.MapPostEndpoint<AnswerToQuestionOpenQuery, OpenAnswerExerciseResponseAnswerToQuestion, AnswerToQuestionOpen>(route, "answer-to-question", tag);
        app.MapPostEndpoint<ConditionalOpenQuery, OpenAnswerExerciseResponseConditional, ConditionalOpen>(route, "conditional", tag);
        app.MapPostEndpoint<IrregularVerbsQuery, OpenAnswerExerciseResponseIrregularVerbs, IrregularVerbs>(route, "irregular-verbs", tag);
        app.MapPostEndpoint<MissingPhrasalVerbOpenQuery, OpenAnswerExerciseResponseMissingPhrasalVerb, MissingPhrasalVerbOpen>(route, "missing-phrasal-verb", tag);
        app.MapPostEndpoint<MissingWordOrExpressionOpenQuery, OpenAnswerExerciseResponseMissingWordOrExpression, MissingWordOrExpressionOpen>(route, "missing-word-or-expression", tag);
        app.MapPostEndpoint<ParaphrasingOpenQuery, OpenAnswerExerciseResponseParaphrasing, ParaphrasingOpen>(route, "paraphrasing", tag);
        app.MapPostEndpoint<PassiveSideOpenQuery, OpenAnswerExerciseResponsePassiveSide, PassiveSideOpen>(route, "passive-side", tag);
        app.MapPostEndpoint<QuestionsToTextOpenQuery, OpenAnswerExerciseResponseQuestionsToText, QuestionsToTextOpen>(route, "questions-to-text", tag);
        app.MapPostEndpoint<SentencesTranslationQuery, OpenAnswerExerciseResponseSentencesTranslation, SentencesTranslation>(route, "sentences-translation", tag);
        app.MapPostEndpoint<SentenceWithVerbToCompleteBasedOnInfinitiveQuery, OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitive, SentenceWithVerbToCompleteBasedOnInfinitive>(route, "sentences-with-verb-to-complete-based-on-infinitive", tag);
        app.MapPostEndpoint<WordMeaningOpenQuery, OpenAnswerExerciseResponseWordMeaning, WordMeaningOpen>(route, "word-meaning", tag);
        
        return app;
    }
}