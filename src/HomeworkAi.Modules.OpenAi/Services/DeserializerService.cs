using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using HomeworkAi.Modules.OpenAi.Cache;
using HomeworkAi.Modules.OpenAi.Exceptions;
using HomeworkAi.Modules.Contracts;
using HomeworkAi.Modules.Contracts.Exercises;
using Microsoft.Extensions.Primitives;

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
        
        var result = JsonSerializer.Deserialize<T>(json);

        if (result is not null) 
            return result;
        
        var fixedJson = FixJson(json);
        result = JsonSerializer.Deserialize<T>(json) 
                 ?? throw new DeserializationException(fixedJson);
        
        return result;
    }
    
    public string FixJson(string json)
    {
        //it works only for string values xD
        var fixedValues = FixValues2(json);
        //var fixedBrackets = FixBrackets(fixedValues);
        //var fixCollections = FixCollections(fixedBrackets);
        //var fixCollections = FixCollections(json);
        return fixedValues;
    }
    
    const string Pattern = @"(?<=\""\w+\"":\s*)""[\w\s\d\.\'\-ĄąĆćĘęŁłŃńÓóŚśŹźŻż:]*""(?![\}\]])";
    public string FixValues2(string json)
    {
        // Compile the regex pattern
        var regex = new Regex(Pattern, RegexOptions.Compiled);

        // Use the Regex to find all matches
        var matches = regex.Matches(json);

        // Initialize a string to build the fixed JSON
        string fixedJson = json;

        // Iterate through the matches in reverse order to avoid altering indices of remaining matches
        for (int i = matches.Count - 1; i >= 0; i--)
        {
            var match = matches[i];

            // Check if the character after the matched value is not a comma, closing brace, or closing bracket
            if (match.Index + match.Length < json.Length && json[match.Index + match.Length] != ',' &&
                json[match.Index + match.Length] != '}' && json[match.Index + match.Length] != ']')
            {
                // Add a comma after the match if it's not followed by a closing brace or bracket
                fixedJson = fixedJson.Insert(match.Index + match.Length, ",");
            }
        }

        // Handle edge cases to remove trailing commas before closing braces or brackets
        fixedJson = RemoveTrailingComma(fixedJson);

        return fixedJson;
    }

    private string RemoveTrailingComma(string json)
    {
        // Pattern to find trailing commas before closing braces or brackets
        var pattern = @",(\s*[}\]])";

        // Remove trailing commas before closing braces or brackets
        return Regex.Replace(json, pattern, "$1");
    }
    
    private string FixValues(string json)
    {
        var valuePattern = @"{?\s+\""\w+\"":\s*""?\w*""?,?{?\[?";
        var valueRegex = new Regex(valuePattern);
        var valueMatches = valueRegex.Matches(json);

        if (valueMatches.Count == 0)
            return json;
        
        var sb = new StringBuilder();
        var firstPart = json.Substring(0, valueMatches.First().Index);
        sb.Append(firstPart);
        
        foreach (Match match in valueMatches)
        {
            if (match.Value.EndsWith('{') || match.Value.EndsWith('['))
            {
                sb.Append(match.Value);
                continue;
            }
            bool hasNextValue = false;
            var restValueOfJson = json.Substring(match.Length + match.Index);
            for (var index = 0; index < restValueOfJson.Length; index++)
            {
                var c = restValueOfJson[index];
                if (c == '\"')
                {
                    hasNextValue = true;
                    break;
                }

                if (c == ']' || c == '}')
                {
                    hasNextValue = false;
                    break;
                }
            }

            if (hasNextValue && !match.Value.EndsWith(','))
                sb.Append(match.Value + ",");
            else
                sb.Append(match.Value);
        }

        var last = valueMatches.Last();
        sb.Append(json.Substring(last.Index + last.Length));

        var result = sb.ToString();
        return result;
    }

    private string FixBrackets(string json)
    {
        var bracketsPattern = @"[}\]]\s*[{\""]";
        var bracketsRegex = new Regex(bracketsPattern);
        var bracketsMatches = bracketsRegex.Matches(json);

        if (bracketsMatches.Count == 0)
            return json;

        var sb = new StringBuilder();
        var firstPart = json.Substring(0, bracketsMatches.First().Index);
        sb.Append(firstPart);
        foreach (Match match in bracketsMatches)
        {
            var fixedValue = match.Value.Substring(0, 1)
                             + ","
                             + match.Value.Substring(1);
            sb.Append(fixedValue);
        }

        var last = bracketsMatches.Last();
        sb.Append(json.Substring(last.Index + last.Length));

        var result = sb.ToString();
        return result;
    }

    private string FixCollections(string json)
    {
        var collectionPattern = @"\[\s*[\""+\w{1}]";
        var collectionRegex = new Regex(collectionPattern);
        var collectionMatches = collectionRegex.Matches(json);

        if (collectionMatches.Count == 0)
            return json;
        
        var sb = new StringBuilder();
        var firstPart = json.Substring(0, collectionMatches.First().Index+1);
        sb.Append(firstPart);
        
        var collectionElementsPattern = @"(\s*[\""+\w+\.]+),{0,1}|\]";
        //there will be at least one element because of closing bracket
        var collectionElementsRegex = new Regex(collectionElementsPattern);

        for (var i = 0; i < collectionMatches.Count; i++)
        {
            var collectionMatch = collectionMatches[i];
            var startOfSubstring = collectionMatch.Index;

             string jsonSub2;
             if (collectionMatches.Count - 1 > i)
             {
                 var nextMatch = collectionMatches[i + 1];
                 var startIndex = nextMatch.Index;
                 jsonSub2 = json.Substring(startOfSubstring, startIndex - startOfSubstring + 1);
             }
             else
             {
                 jsonSub2 = json.Substring(startOfSubstring);
             }
            var jsonSubstring = jsonSub2;
            //var jsonSubstring = json.Substring(startOfSubstring);
            var elementsMatches = collectionElementsRegex.Matches(jsonSubstring);
            int appendedCharsCount = 0;
            for (var j = 0; j < elementsMatches.Count; j++)
            {
                var elementMatch = elementsMatches[j];
                appendedCharsCount += elementMatch.Length;

                if (elementMatch.Value.EndsWith(','))
                {
                    //correct line
                    sb.Append((elementMatch.Value));
                    continue;
                }

                
                // if (j == elementsMatches.Count - 2) //last element of collection
                // {
                //     sb.Append((elementMatch.Value));
                //     continue;
                // }

                if (elementsMatches.Count - 1 > j)
                {
                    if (elementsMatches[j + 1].Value == "]" || elementsMatches[j + 1].Value == "],")
                    {
                        sb.Append((elementMatch.Value));
                        continue;
                    }
                }
                if (elementMatch.Value == "]" || elementMatch.Value == "],") //it is the last one
                {
                    //sb.Append((elementMatch.Value));
                    break;
                }
                
                sb.Append((elementMatch.Value + ","));
            }

            if (i == collectionMatches.Count - 1)
            {
                //append all text
                int startIndex = collectionMatch.Index + appendedCharsCount;
                var stringToAppend = json.Substring(startIndex);
                sb.Append(stringToAppend);
            }
            else
            {
                int startIndex = collectionMatch.Index + appendedCharsCount;
                var nextArray = collectionMatches[i + 1];
                int startOfNextArray = nextArray.Index;
                var stringToAppend = json.Substring(startIndex +1, startOfNextArray - startIndex);
                sb.Append(stringToAppend);
                //append text to next array
            }
            //append text to open of next collection or end
        }

        return sb.ToString();
    }
}