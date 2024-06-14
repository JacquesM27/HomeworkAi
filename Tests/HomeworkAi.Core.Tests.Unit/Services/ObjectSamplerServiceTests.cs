using FluentAssertions;
using HomeworkAi.Core.DTO.Exercises;
using HomeworkAi.Core.Services;
using Shouldly;

namespace HomeworkAi.Core.Tests.Unit.Services;

public class ObjectSamplerServiceTests
{
    private readonly ObjectSamplerService _service = new();

    [Fact]
    public void GetSampleJson_ReturnsCorrectJson()
    {
        // Arrange
        var expectedJson = @"
        {
            ""CorrectMeanings"": [
                {
                    ""Word"": ""string"",
                    ""CorrectWordMeaning"": ""string""
                }
            ],
            ""Header"": {
                ""Title"": ""string"",
                ""TaskDescription"": ""string"",
                ""Instruction"": ""string"",
                ""Example"": ""string"",
                ""SupportMaterial"": ""string""
            }
        }".Replace(" ", "").Replace("\n", "").Replace("\r", "");

        // Act
        var json = _service.GetSampleJson(typeof(WordMeaning)).Replace(" ", "").Replace("\n", "").Replace("\r", "");

        // Assert
        json.ShouldBe(expectedJson);
    }
    
    [Fact]
    public void GetSampleObject_ReturnsCorrectObject()
    {
        // Arrange
        var type = typeof(WordMeaning);

        // Act
        var sample = _service.GetSampleObject(type);

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
        var json1 = _service.GetSampleJson(type);
        var json2 = _service.GetSampleJson(type);

        // Assert
        json1.ShouldBe(json2);
    }

    [Fact]
    public void GetStringValues_ShouldThrowArgumentNullException_WhenObjectIsNull()
    {
        // Arrange
        object obj = null;

        // Act
        Action act = () => _service.GetStringValues(obj);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GetStringValues_ShouldReturnEmptyString_WhenClassIsEmpty()
    {
        // Arrange
        var obj = new EmptyClass();

        // Act
        var result = _service.GetStringValues(obj);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void GetStringValues_ShouldReturnEmptyString_WhenStringFieldsAreNullOrWhitespace()
    {
        // Arrange
        var obj = new ClassWithStrings
        {
            Field1 = null,
            Field2 = "   ",
            Field3 = ""
        };

        // Act
        var result = _service.GetStringValues(obj);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void GetStringValues_ShouldReturnAllNonEmptyStringFields_WhenClassHasData()
    {
        // Arrange
        var obj = new ClassWithStrings
        {
            Field1 = "Value1",
            Field2 = "   ",
            Field3 = "Value3"
        };

        // Act
        var result = _service.GetStringValues(obj);

        // Assert
        result.Should().Be("Value1" + Environment.NewLine + "Value3" + Environment.NewLine);
    }

    [Fact]
    public void GetStringValues_ShouldReturnConcatenatedStringFields_WhenAllFieldsHaveValues()
    {
        // Arrange
        var obj = new ClassWithStrings
        {
            Field1 = "Value1",
            Field2 = "Value2",
            Field3 = "Value3"
        };

        // Act
        var result = _service.GetStringValues(obj);

        // Assert
        result.Should().Be("Value1" + Environment.NewLine + "Value2" + Environment.NewLine + "Value3" + Environment.NewLine);
    }

    [Fact]
    public void GetStringValues_ShouldReturnOnlyStringFields_WhenClassHasVariousTypes()
    {
        // Arrange
        var obj = new ClassWithVariousTypes
        {
            StringField = "StringValue",
            IntField = 123,
            DateTimeField = DateTime.Now,
            NestedField = new NestedClass { NestedStringField = "NestedValue" }
        };

        // Act
        var result = _service.GetStringValues(obj);

        // Assert
        result.Should().Be("StringValue" + Environment.NewLine);
    }

    [Fact]
    public void GetStringValues_ShouldReturnStringFields_WhenRecordHasStringsAndOtherTypes()
    {
        // Arrange
        var record = new RecordWithStrings("Value1", "Value2", 123);

        // Act
        var result = _service.GetStringValues(record);

        // Assert
        result.Should().Be("Value1" + Environment.NewLine + "Value2" + Environment.NewLine);
    } 
    
    
    #region GetStringValuesClasses
    
    private class EmptyClass { }

    private class ClassWithStrings
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
    }

    private class ClassWithVariousTypes
    {
        public string StringField { get; set; }
        public int IntField { get; set; }
        public DateTime DateTimeField { get; set; }
        public NestedClass NestedField { get; set; }
    }

    private class NestedClass
    {
        public string NestedStringField { get; set; }
    }

    private record RecordWithStrings(string Field1, string Field2, int IntField);

    #endregion
}