using System.Collections.Concurrent;
using HomeworkAi.Core.Cache;

namespace HomeworkAi.Core.Services;

public interface IExerciseFormatProvider
{
    public string FormatType(string exerciseType);
}

public class ExerciseFormatProvider(
    IObjectSamplerProvider objectSamplerProvider,
    IApplicationMemoryCache applicationMemoryCache) : IExerciseFormatProvider
{
    private static readonly ConcurrentDictionary<string, string> ExerciseTypes = [];
    
    public string FormatType(string exerciseType)
    {
        if (ExerciseTypes.TryGetValue(exerciseType, out var json))
            return json;

        var type = applicationMemoryCache.GetExerciseType(exerciseType)
            ?? throw new ArgumentOutOfRangeException();//TODO: custom class

        var sample = objectSamplerProvider.GetSampleJson(type);
        ExerciseTypes.TryAdd(exerciseType, sample);
        return sample;
    }
}