namespace HomeworkAi.Core.Services;

public interface IObjectSamplerService
{
    string GetSampleJson(Type type);
    object GetSampleObject(Type type);
    string GetStringValues(object? obj);
}