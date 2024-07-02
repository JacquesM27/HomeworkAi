using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Contracts.ValueObjects;
using HomeworkAi.Modules.OpenAi.Cache;
using Shouldly;

namespace HomeworkAi.Core.Tests.Unit.Cache;

public class ApplicationMemoryCacheTests
{
    private readonly ApplicationMemoryCache _cache = new();
    
    [Fact]
    public void GetExerciseType_ShouldReturnCorrectType()
    {
        // Arrange
        var exercise = typeof(QuestionsToTextClosed);

        // Act
        var exerciseType = _cache.GetExerciseType(exercise.Name);

        // Assert
        exerciseType.ShouldBe(exercise);
    }
    
    [Fact]
    public void GetExerciseType_ShouldNotReturnCorrectType()
    {
        // Arrange
        const string exercise = "non-existent exercise";

        // Act
        var exerciseType = _cache.GetExerciseType(exercise);

        // Assert
        exerciseType.ShouldBeNull();
    }

    [Fact]
    public void GetClosedAnswerExercises_ShouldHasAllDerivedNames()
    {
        // Arrange
        List<string> exercises =
        [
            nameof(QuestionsToTextClosed),
            nameof(PassiveSideClosed),
            nameof(ParaphrasingClosed),
            nameof(AnswerToQuestionClosed),
            nameof(ConditionalClosed),
            nameof(WordMeaningClosed),
            nameof(PhrasalVerbsTranslating),
            nameof(MissingPhrasalVerbClosed),
            nameof(MissingWordOrExpressionClosed)
        ];
        
        // Act
        var closedAnswerExercises = _cache.GetClosedAnswerExercises().ToList();
        
        // Assert
        foreach (var exercise in exercises)
        {
            closedAnswerExercises.ShouldContain(exercise);
        }
        closedAnswerExercises.Count.ShouldBe(exercises.Count);
    }
    
    [Fact]
    public void GetOpenAnswerAnswerExercises_ShouldHasAllDerivedNames()
    {
        // Arrange
        List<string> exercises =
        [
            nameof(SentenceWithVerbToCompleteBasedOnInfinitive),
            nameof(SentenceWithVerbToComplete),
            nameof(SentencesTranslation),
            nameof(IrregularVerbs),
            nameof(QuestionsToTextOpen),
            nameof(PassiveSideOpen),
            nameof(ParaphrasingOpen),
            nameof(AnswerToQuestionOpen),
            nameof(ConditionalOpen),
            nameof(MissingWordOrExpressionOpen),
            nameof(MissingPhrasalVerbOpen),
            nameof(WordMeaningOpen)
        ];
        
        // Act
        var openAnswerExercises = _cache.GetOpenAnswerExercises().ToList();
        
        // Assert
        foreach (var exercise in exercises)
        {
            openAnswerExercises.ShouldContain(exercise);
        }
        openAnswerExercises.Count.ShouldBe(exercises.Count);
    }

    [Fact]
    public void GetOpenFormExercises_ShouldHasAllDerivedNames()
    {
        // Arrange
        List<string> exercises =
        [
            nameof(Mail),
            nameof(Essay),
            nameof(SummaryOfText),
        ];
        
        // Act
        var openFormExercises = _cache.GetOpenFormExercises().ToList();
        
        // Assert
        foreach (var exercise in exercises)
        {
            openFormExercises.ShouldContain(exercise);
        }
        openFormExercises.Count.ShouldBe(exercises.Count);
    }

    [Fact]
    public void GetLanguages_ShouldHasAllSystemLanguages()
    {
        // Arrange
        var languages = Language.Languages;
        
        // Act
        var cacheLanguages = _cache.GetLanguages().ToList();
        
        foreach (var language in languages)
        {
            cacheLanguages.ShouldContain(language);
        }
    }
}