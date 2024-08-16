namespace HomeworkAi.Infrastructure.Cache;

public interface ICacheStorage
{
    void Set<T>(string key, T value, TimeSpan? duration = null);
    T? Get<T>(string key);
}