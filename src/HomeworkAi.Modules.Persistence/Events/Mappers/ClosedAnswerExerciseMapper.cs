using System.Text.Json;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;

namespace HomeworkAi.Modules.Persistence.Events.Mappers;

internal static class ClosedAnswerExerciseMapper
{
    public static ClosedAnswerExerciseEntity Map<TExercise>(this ClosedAnswerExerciseResponse<TExercise> exerciseResponse) 
        where TExercise : ClosedAnswerExercise
    {
        var json = JsonSerializer.Serialize(exerciseResponse.Exercise);

        var exerciseType = exerciseResponse.Exercise.GetType().Name;
        
        var mapped = new ClosedAnswerExerciseEntity
        {
            Id = Guid.NewGuid(),
            ExerciseHeaderInMotherLanguage = exerciseResponse.ExerciseHeaderInMotherLanguage,
            MotherLanguage = exerciseResponse.MotherLanguage,
            TargetLanguage = exerciseResponse.TargetLanguage,
            TargetLanguageLevel = exerciseResponse.TargetLanguageLevel,
            TopicsOfSentences = exerciseResponse.TopicsOfSentences,
            GrammarSection = exerciseResponse.GrammarSection,
            AmountOfSentences = exerciseResponse.AmountOfSentences,
            TranslateFromMotherLanguage = exerciseResponse.TranslateFromMotherLanguage,
            QuestionsInMotherLanguage = exerciseResponse.QuestionsInMotherLanguage,
            ZeroConditional = exerciseResponse.ZeroConditional,
            FirstConditional = exerciseResponse.FirstConditional,
            SecondConditional = exerciseResponse.SecondConditional,
            ThirdConditional = exerciseResponse.ThirdConditional,
            DescriptionInMotherLanguage = exerciseResponse.DescriptionInMotherLanguage,
            ExerciseType = exerciseType,
            ExerciseJson = json,
            CheckedByTeacher = false
        };
        return mapped;
    }
}