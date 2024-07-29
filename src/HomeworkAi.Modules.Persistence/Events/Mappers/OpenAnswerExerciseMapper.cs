using System.Text.Json;
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Persistence.DAL.Entities;

namespace HomeworkAi.Modules.Persistence.Events.Mappers;

public static class OpenAnswerExerciseMapper
{
    public static TEntity Map<TExercise, TEntity>(
        this OpenAnswerExerciseResponse<TExercise> exerciseResponse)
        where TExercise : OpenAnswerExercise where TEntity : OpenAnswerExerciseEntity, new()
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
            AmountOfSentences = exerciseResponse.AmountOfSentences,
            TranslateFromMotherLanguage = exerciseResponse.TranslateFromMotherLanguage,
            QuestionsInMotherLanguage = exerciseResponse.QuestionsInMotherLanguage,
            ZeroConditional = exerciseResponse.ZeroConditional,
            FirstConditional = exerciseResponse.FirstConditional,
            SecondConditional = exerciseResponse.SecondConditional,
            ThirdConditional = exerciseResponse.ThirdConditional,
            ShowMotherLanguage = exerciseResponse.ShowMotherLanguage,
            ShowFirstForm = exerciseResponse.ShowFirstForm,
            ExerciseJson = json,
            CheckedByTeacher = false
        };
        return mapped;
    }
    
    public static TResponse Map<TResponse, TExercise, TEntity>(this TEntity entity)
        where TResponse : OpenAnswerExerciseResponse<TExercise>, new()
        where TEntity : OpenAnswerExerciseEntity
        where TExercise : OpenAnswerExercise
    {
        var deserializedExercise = JsonSerializer.Deserialize<TExercise>(entity.ExerciseJson);

        var mapped = new TResponse()
        {
            GrammarSection = entity.GrammarSection,
            AmountOfSentences = entity.AmountOfSentences,
            TranslateFromMotherLanguage = entity.TranslateFromMotherLanguage,
            QuestionsInMotherLanguage = entity.QuestionsInMotherLanguage,
            ZeroConditional = entity.ZeroConditional,
            FirstConditional = entity.FirstConditional,
            SecondConditional = entity.SecondConditional,
            ThirdConditional = entity.ThirdConditional,
            MotherLanguage = entity.MotherLanguage,
            TargetLanguage = entity.TargetLanguage,
            TargetLanguageLevel = entity.TargetLanguageLevel,
            TopicsOfSentences = entity.TopicsOfSentences,
            ExerciseHeaderInMotherLanguage = entity.ExerciseHeaderInMotherLanguage,
            ShowFirstForm = entity.ShowFirstForm,
            ShowMotherLanguage = entity.ShowMotherLanguage,
            Exercise = deserializedExercise!
        };

        return mapped;
    }
}