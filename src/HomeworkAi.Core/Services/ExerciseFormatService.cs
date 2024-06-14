using System.Collections.Concurrent;
using HomeworkAi.Core.Cache;

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
                   ?? throw new ArgumentOutOfRangeException();//TODO: custom class

        var sample = objectSamplerService.GetSampleJson(type);
        ExerciseTypes.TryAdd(exerciseType, sample);
        return sample;
    }
}