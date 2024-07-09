﻿namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public class ClosedAnswerExerciseEntity
{
    public Guid Id { get; set; }
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public string MotherLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
    public int? AmountOfSentences { get; set; }
    public bool? TranslateFromMotherLanguage { get; set; }
    public bool? QuestionsInMotherLanguage { get; set; }
    public bool? ZeroConditional { get; set; }
    public bool? FirstConditional { get; set; }
    public bool? SecondConditional { get; set; }
    public bool? ThirdConditional { get; set; }
    public bool? DescriptionInMotherLanguage { get; set; }
    public string ExerciseType { get; set; }
    public string ExerciseJson { get; set; } // JSONB column
    public bool CheckedByTeacher { get; set; }
}