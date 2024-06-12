using HomeworkAi.Core.DTO.Exercises;
using HomeworkAi.Core.Services;
using Shouldly;

namespace HomeworkAi.Core.Tests.Unit.Services;

public class ObjectSamplerProviderTests
{
    private readonly ObjectSamplerProvider _provider = new();

    [Fact]
    public void GetSampleJson_ReturnsCorrectJson()
    {
        // Arrange
        var expectedJson = @"
        {
            ""Words"": [
                ""string""
            ],
            ""WordMeanings"": [
                ""string""
            ],
            ""CorrectMeanings"": [
                {
                    ""Word"": ""string"",
                    ""CorrectWordMeaning"": ""string""
                }
            ],
            ""Header"": {
                ""Title"": ""string"",
                ""TaskDescription"": ""string"",
                ""Example"": ""string"",
                ""SupportMaterial"": ""string""
            }
        }".Replace(" ", "").Replace("\n", "").Replace("\r", "");

        // Act
        var json = _provider.GetSampleJson(typeof(WordMeaning)).Replace(" ", "").Replace("\n", "").Replace("\r", "");

        // Assert
        json.ShouldBe(expectedJson);
    }
    
    [Fact]
    public void GetSampleObject_ReturnsCorrectObject()
    {
        // Arrange
        var type = typeof(WordMeaning);

        // Act
        var sample = _provider.GetSampleObject(type);

        // Assert
        sample.ShouldNotBeNull();
        sample.ShouldBeOfType<WordMeaning>();

        var wordMeaning = (WordMeaning)sample;
        wordMeaning.Header.ShouldNotBeNull();
        wordMeaning.Header.Title.ShouldBe("string");
        wordMeaning.Header.TaskDescription.ShouldBe("string");
        wordMeaning.Header.Instruction.ShouldBe("string");
        wordMeaning.Header.Example.ShouldBe("string");
        wordMeaning.Header.SupportMaterial.ShouldBe("string");
        wordMeaning.CorrectMeanings.ShouldHaveSingleItem();
        wordMeaning.CorrectMeanings.ToList()[0].Word.ShouldBe("string");
        wordMeaning.CorrectMeanings.ToList()[0].CorrectWordMeaning.ShouldBe("string");
    }

    [Fact]
    public void GetSampleJson_CachesResult()
    {
        // Arrange
        var type = typeof(WordMeaning);

        // Act
        var json1 = _provider.GetSampleJson(type);
        var json2 = _provider.GetSampleJson(type);

        // Assert
        json1.ShouldBe(json2);
    }
}