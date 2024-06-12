using System.Reflection;
using System.Text;

namespace HomeworkAi.Core.Extensions;

public static class ReflectionExtensions
{
    public static string GetStringValues(this object? obj)
    {
        //TODO: add custom exception
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
}