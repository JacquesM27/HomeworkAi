namespace HomeworkAi.Modules.OpenAi.Services;

public interface IObjectSamplerService
{
    string GetSampleJson(Type type);
    object GetSampleObject(Type type);
    string GetStringValues(object? obj);
    IEnumerable<string> GetStringCollectionValues(object? obj);
}