using FluentAssertions;
using HomeworkAi.Core.Extensions;

namespace HomeworkAi.Core.Tests.Unit.Extensions;

public class ReflectionExtensionsTests
{
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

    [Fact]
    public void GetStringValues_ShouldThrowArgumentNullException_WhenObjectIsNull()
    {
        // Arrange
        object obj = null;

        // Act
        Action act = () => obj.GetStringValues();

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GetStringValues_ShouldReturnEmptyString_WhenClassIsEmpty()
    {
        // Arrange
        var obj = new EmptyClass();

        // Act
        var result = obj.GetStringValues();

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
        var result = obj.GetStringValues();

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
        var result = obj.GetStringValues();

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
        var result = obj.GetStringValues();

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
        var result = obj.GetStringValues();

        // Assert
        result.Should().Be("StringValue" + Environment.NewLine);
    }

    [Fact]
    public void GetStringValues_ShouldReturnStringFields_WhenRecordHasStringsAndOtherTypes()
    {
        // Arrange
        var record = new RecordWithStrings("Value1", "Value2", 123);

        // Act
        var result = record.GetStringValues();

        // Assert
        result.Should().Be("Value1" + Environment.NewLine + "Value2" + Environment.NewLine);
    }    
}