using System.Collections.Concurrent;
using System.Text.Json;
using HomeworkAi.Core.Cache;
using HomeworkAi.Core.Exceptions;
using HomeworkAi.Modules.Contracts;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Core.Services;

public class ExerciseFormatService(
    IObjectSamplerService objectSamplerService,
    IApplicationMemoryCache applicationMemoryCache) : IExerciseFormatService
{
    private static readonly ConcurrentDictionary<string, string> ExerciseTypes = [];
    
    public string FormatType(string exerciseType)
    {
        if (ExerciseTypes.TryGetValue(exerciseType, out var json))
            return json;

        var type = applicationMemoryCache.GetExerciseType(exerciseType)
                   ?? throw new InvalidExerciseTypeException(exerciseType);

        var sample = objectSamplerService.GetSampleJson(type);
        ExerciseTypes.TryAdd(exerciseType, sample);
        return sample;
    }

    public Exercise DeserializeExercise(string json, string exerciseType)
    {
        var type = applicationMemoryCache.GetExerciseType(exerciseType)
            ?? throw new InvalidExerciseTypeException(exerciseType);
        
        var exercise = JsonSerializer.Deserialize(json, type)
            ?? throw new DeserializationException(json);
        
        return (Exercise)exercise;
    }

    public SuspiciousPrompt DeserializeSuspiciousPrompt(string json)
    {
        var response = JsonSerializer.Deserialize<SuspiciousPrompt>(json)
                       ?? throw new DeserializationException(json);
        return response;
    }
}