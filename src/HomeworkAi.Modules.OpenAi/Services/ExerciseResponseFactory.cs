using HomeworkAi.Modules.OpenAi.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.OpenAi.Services;

internal sealed class ExerciseResponseFactory : IExerciseResponseFactory
{
    public ExerciseResponseOld CreateResponse(Exercise exercise, ExercisePromptOld promptOld)
    {
        if (promptOld.GetType() == typeof(OpenAnswerExercisePromptOld))
        {
            var castedPrompt = (OpenAnswerExercisePromptOld)promptOld;
            return new OpenAnswerExerciseResponseOld()
            {
                Exercise = exercise,
                ExerciseType = exercise.GetType().Name,
                ExerciseHeaderInMotherLanguage = promptOld.ExerciseHeaderInMotherLanguage,
                MotherLanguage = promptOld.MotherLanguage,
                TargetLanguage = promptOld.TargetLanguage,
                TargetLanguageLevel = promptOld.TargetLanguageLevel,
                TopicsOfSentences = promptOld.TopicsOfSentences,
                GrammarSection = promptOld.GrammarSection,
                SupportMaterial = promptOld.SupportMaterial,
                AmountOfSentences = castedPrompt.AmountOfSentences,
                AnswersInMotherLanguage = castedPrompt.AnswersInMotherLanguage
            };
        }
        
        if (promptOld.GetType() == typeof(ClosedAnswerExercisePromptOld))
        {
            var castedPrompt = (ClosedAnswerExercisePromptOld)promptOld;
            return new ClosedAnswerExerciseResponseOld()
            {
                Exercise = exercise,
                ExerciseType = exercise.GetType().Name,
                ExerciseHeaderInMotherLanguage = promptOld.ExerciseHeaderInMotherLanguage,
                MotherLanguage = promptOld.MotherLanguage,
                TargetLanguage = promptOld.TargetLanguage,
                TargetLanguageLevel = promptOld.TargetLanguageLevel,
                TopicsOfSentences = promptOld.TopicsOfSentences,
                GrammarSection = promptOld.GrammarSection,
                SupportMaterial = promptOld.SupportMaterial,
                AmountOfSentences = castedPrompt.AmountOfSentences,
                QuestionsInMotherLanguage = castedPrompt.QuestionsInMotherLanguage,
                AnswersInMotherLanguage = castedPrompt.AnswersInMotherLanguage
            };
        }
        
        throw new NotImplementedException($"Exercise type: '{promptOld.GetType().Name}' is not implemented.");
    }
}