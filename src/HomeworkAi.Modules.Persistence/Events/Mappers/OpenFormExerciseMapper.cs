using System.Text.Json;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;

namespace HomeworkAi.Modules.Persistence.Events.Mappers;

public static class OpenFormExerciseMapper
{
    public static OpenFormExerciseEntity Map<TExercise>(this OpenFormExerciseResponse<TExercise> exerciseResponse)
        where TExercise : OpenFormExercise
    {
        var json = JsonSerializer.Serialize(exerciseResponse.Exercise);

        var exerciseType = exerciseResponse.Exercise.GetType().Name;

        var mapped = new OpenFormExerciseEntity()
        {
            Id = Guid.NewGuid(),
            ExerciseHeaderInMotherLanguage = exerciseResponse.ExerciseHeaderInMotherLanguage,
            MotherLanguage = exerciseResponse.MotherLanguage,
            TargetLanguage = exerciseResponse.TargetLanguage,
            TargetLanguageLevel = exerciseResponse.TargetLanguageLevel,
            TopicsOfSentences = exerciseResponse.TopicsOfSentences,
            GrammarSection = exerciseResponse.GrammarSection,
            ExerciseType = exerciseType,
            ExerciseJson = json,
            CheckedByTeacher = false
        };
        return mapped;
    }
}