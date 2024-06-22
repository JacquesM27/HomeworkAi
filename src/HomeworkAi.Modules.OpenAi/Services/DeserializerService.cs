using System.Collections.Concurrent;
using System.Text.Json;
using HomeworkAi.Modules.OpenAi.Cache;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.Contracts;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.OpenAi.Services;

public class DeserializerService(
    IObjectSamplerService objectSamplerService,
    IApplicationMemoryCache applicationMemoryCache) : IDeserializerService
{
    private static readonly ConcurrentDictionary<string, string> ExerciseTypes = [];
    
    //TODO: remove
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

    //TODO: remove
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
        var result = Deserialize<SuspiciousPrompt>(json);
        return result;
    }

    public T Deserialize<T>(string json)
    {
        var result = JsonSerializer.Deserialize<T>(json)
                     ?? throw new DeserializationException(json);
        return result;
    }
}