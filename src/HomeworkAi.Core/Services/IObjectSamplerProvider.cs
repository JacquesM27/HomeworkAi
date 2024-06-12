namespace HomeworkAi.Core.Services;

public interface IObjectSamplerProvider
{
    string GetSampleJson(Type type);
    object GetSampleObject(Type type);
}