using System.Text.Json;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;

namespace HomeworkAi.Modules.Persistence.Events.Mappers;

public static class OpenFormExerciseMapper
{
    public static TEntity Map<TExercise, TEntity>(this OpenFormExerciseResponse<TExercise> exerciseResponse)
        where TExercise : OpenFormExercise where TEntity : OpenFormExerciseEntity, new()
    {
        var json = JsonSerializer.Serialize(exerciseResponse.Exercise);

        var mapped = new TEntity()
        {
            Id = exerciseResponse.Id,
            ExerciseHeaderInMotherLanguage = exerciseResponse.ExerciseHeaderInMotherLanguage,
            MotherLanguage = exerciseResponse.MotherLanguage,
            TargetLanguage = exerciseResponse.TargetLanguage,
            TargetLanguageLevel = exerciseResponse.TargetLanguageLevel,
            TopicsOfSentences = exerciseResponse.TopicsOfSentences,
            GrammarSection = exerciseResponse.GrammarSection,
            ExerciseJson = json,
            CheckedByTeacher = false
        };
        return mapped;
    }

    public static TResponse Map<TResponse, TExercise, TEntity>(this TEntity entity)
        where TResponse : OpenFormExerciseResponse<TExercise>, new()
        where TEntity : OpenFormExerciseEntity
        where TExercise : OpenFormExercise
    {
        var deserializedExercise = JsonSerializer.Deserialize<TExercise>(entity.ExerciseJson);

        var mapped = new TResponse()
        {
            Exercise = deserializedExercise!,
            GrammarSection = entity.GrammarSection,
            ExerciseHeaderInMotherLanguage = entity.ExerciseHeaderInMotherLanguage,
            MotherLanguage = entity.MotherLanguage,
            TargetLanguage = entity.MotherLanguage,
            TargetLanguageLevel = entity.TargetLanguageLevel,
            TopicsOfSentences = entity.TopicsOfSentences
        };

        return mapped;
    }
}