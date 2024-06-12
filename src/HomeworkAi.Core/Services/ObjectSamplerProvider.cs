using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;

namespace HomeworkAi.Core.Services;

public class ObjectSamplerProvider : IObjectSamplerProvider
{
    private readonly ConcurrentDictionary<Type, object> _samples = [];
    
    public string GetSampleJson(Type type)
    {
        if (_samples.TryGetValue(type, out var readySample))
            return SerializeToJson(readySample);

        var sample = GenerateSampleObject(type);
        _samples.TryAdd(type, sample);
        return SerializeToJson(sample);
    }

    private static string SerializeToJson(object sample)
    {
        return JsonSerializer.Serialize(sample, new JsonSerializerOptions { WriteIndented = true });
    }

    public object GetSampleObject(Type type)
    {
        if (_samples.TryGetValue(type, out var readySample))
            return readySample;
        
        var sample = GenerateSampleObject(type);
        _samples.TryAdd(type, sample);
        return sample;
    }
    
    private static object GenerateSampleObject(Type type)
    {
        if (type == typeof(string))
        {
            return "string";
        }

        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
        {
            var listType = type.GetGenericArguments()[0];
            var list = (IList)Activator.CreateInstance(type);
            list.Add(GenerateSampleObject(listType));
            return list;
        }

        var obj = Activator.CreateInstance(type);
        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (property.CanWrite)
            {
                property.SetValue(obj, GenerateSampleObject(property.PropertyType));
            }
        }

        return obj;
    }
}