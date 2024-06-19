using HomeworkAi.Core.DTO.Exercises;

namespace HomeworkAi.Core.Services;

internal sealed class ExerciseResponseFactory : IExerciseResponseFactory
{
    public ExerciseResponse CreateResponse(Exercise exercise, ExercisePrompt prompt)
    {
        if (prompt.GetType() == typeof(OpenFormExercisePrompt))
        {
            var castedPrompt = (OpenFormExercisePrompt)prompt;
            return new OpenFormExerciseResponse()
            {
                Exercise = exercise,
                ExerciseType = exercise.GetType().Name,
                ExerciseHeaderInMotherLanguage = prompt.ExerciseHeaderInMotherLanguage,
                MotherLanguage = prompt.MotherLanguage,
                TargetLanguage = prompt.TargetLanguage,
                TargetLanguageLevel = prompt.TargetLanguageLevel,
                TopicsOfSentences = prompt.TopicsOfSentences,
                GrammarSection = prompt.GrammarSection,
                SupportMaterial = prompt.SupportMaterial,
                DescriptionOfExerciseContent = castedPrompt.DescriptionOfExerciseContent,
                QuestionsInMotherLanguage = castedPrompt.QuestionsInMotherLanguage
            };
        }

        if (prompt.GetType() == typeof(OpenAnswerExercisePrompt))
        {
            var castedPrompt = (OpenAnswerExercisePrompt)prompt;
            return new OpenAnswerExerciseResponse()
            {
                Exercise = exercise,
                ExerciseType = exercise.GetType().Name,
                ExerciseHeaderInMotherLanguage = prompt.ExerciseHeaderInMotherLanguage,
                MotherLanguage = prompt.MotherLanguage,
                TargetLanguage = prompt.TargetLanguage,
                TargetLanguageLevel = prompt.TargetLanguageLevel,
                TopicsOfSentences = prompt.TopicsOfSentences,
                GrammarSection = prompt.GrammarSection,
                SupportMaterial = prompt.SupportMaterial,
                AmountOfSentences = castedPrompt.AmountOfSentences,
                AnswersInMotherLanguage = castedPrompt.AnswersInMotherLanguage
            };
        }
        
        if (prompt.GetType() == typeof(ClosedAnswerExercisePrompt))
        {
            var castedPrompt = (ClosedAnswerExercisePrompt)prompt;
            return new ClosedAnswerExerciseResponse()
            {
                Exercise = exercise,
                ExerciseType = exercise.GetType().Name,
                ExerciseHeaderInMotherLanguage = prompt.ExerciseHeaderInMotherLanguage,
                MotherLanguage = prompt.MotherLanguage,
                TargetLanguage = prompt.TargetLanguage,
                TargetLanguageLevel = prompt.TargetLanguageLevel,
                TopicsOfSentences = prompt.TopicsOfSentences,
                GrammarSection = prompt.GrammarSection,
                SupportMaterial = prompt.SupportMaterial,
                AmountOfSentences = castedPrompt.AmountOfSentences,
                QuestionsInMotherLanguage = castedPrompt.QuestionsInMotherLanguage,
                AnswersInMotherLanguage = castedPrompt.AnswersInMotherLanguage
            };
        }
        
        throw new NotImplementedException($"Exercise type: '{prompt.GetType().Name}' is not implemented.");
    }
}