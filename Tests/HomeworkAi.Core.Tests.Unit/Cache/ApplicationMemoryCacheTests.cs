﻿using HomeworkAi.Core.Cache;
using HomeworkAi.Core.DTO.Exercises;
using HomeworkAi.Core.Entities;
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
            nameof(SentenceFormationClosed),
            nameof(WordMeaning),
            nameof(PhrasalVerbsTranslating),
            nameof(MissingPhrasalVerbsClosed),
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
            nameof(SentencesTranscription),
            nameof(SentenceWithVerbToCompleteBasedOnInfinitive),
            nameof(SentenceWithVerbToComplete),
            nameof(IrregularVerbs),
            nameof(QuestionsToTextOpen),
            nameof(PassiveSideOpen),
            nameof(ParaphrasingOpen),
            nameof(AnswerToQuestionOpen),
            nameof(ConditionalOpen),
            nameof(MissingPhrasalVerbsOpen),
            nameof(MissingWordOrExpressionOpen)
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
            nameof(MailExercise),
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