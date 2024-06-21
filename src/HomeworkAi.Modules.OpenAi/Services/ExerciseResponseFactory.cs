using HomeworkAi.Core.Exercises;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Core.Services;

internal sealed class ExerciseResponseFactory : IExerciseResponseFactory
{
    public ExerciseResponseOld CreateResponse(Exercise exercise, ExercisePromptOld promptOld)
    {
        if (promptOld.GetType() == typeof(OpenFormExercisePromptOld))
        {
            var castedPrompt = (OpenFormExercisePromptOld)promptOld;
            return new OpenFormExerciseResponseOld()
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
                DescriptionOfExerciseContent = castedPrompt.DescriptionOfExerciseContent,
                QuestionsInMotherLanguage = castedPrompt.QuestionsInMotherLanguage
            };
        }

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