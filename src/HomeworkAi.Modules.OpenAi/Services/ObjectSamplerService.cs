﻿using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace HomeworkAi.Modules.OpenAi.Services;

public class ObjectSamplerService : IObjectSamplerService
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public string GetSampleJson(Type type)
    {
        var sample = GenerateSampleObject(type);
        return SerializeToJson(sample);
    }

    private static string SerializeToJson(object sample)
    {
        return JsonSerializer.Serialize(sample, Options);
    }

    public object GetSampleObject(Type type)
    {
        return GenerateSampleObject(type);
    }

    public string GetStringValues(object? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var type = obj.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var sb = new StringBuilder();

        foreach (var property in properties)
        {
            if (property.PropertyType != typeof(string))
                continue;

            var value = property.GetValue(obj) as string;

            if (string.IsNullOrWhiteSpace(value))
                continue;

            sb.AppendLine(value);
        }

        return sb.ToString();
    }

    public IEnumerable<string> GetStringCollectionValues(object? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var type = obj.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var result = new List<string>();

        foreach (var property in properties)
        {
            if (property.PropertyType != typeof(string))
                continue;

            var value = property.GetValue(obj) as string;

            if (string.IsNullOrWhiteSpace(value))
                continue;

            result.Add(value);
        }

        return result;
    }

    /// <summary>
    /// Only for types with default constructor!
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static object GenerateSampleObject(Type type)
    {
        if (type == typeof(string))
            return "string";

        if (type.IsValueType)
            return Activator.CreateInstance(type)!;

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
        {
            var listType = type.GetGenericArguments()[0];
            var list = (IList)Activator.CreateInstance(type)!;
            list.Add(GenerateSampleObject(listType));
            return list;
        }

        var obj = Activator.CreateInstance(type);
        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            if (property.CanWrite)
                property.SetValue(obj, GenerateSampleObject(property.PropertyType));

        return obj!;
    }
}