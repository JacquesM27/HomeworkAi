﻿namespace HomeworkAi.Modules.Contracts.Exercises;


public abstract class OpenAnswerExercise : Exercise
{
}

public class SentencesTranslation : OpenAnswerExercise
{
    public List<string> Sentences { get; set; }
}

public class SentenceWithVerbToCompleteBasedOnInfinitive : OpenAnswerExercise
{
    public List<Sentence> Sentences { get; set; }
    
    public class Sentence
    {
        public string Text { get; set; }
        public string Infinitive { get; set; }
        public string CorrectAnswer { get; set; }
    }
}

public class SentenceWithVerbToComplete : OpenAnswerExercise
{
    public List<Sentence> Sentences { get; set; }
    
    public class Sentence
    {
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
    }
}

public class IrregularVerbs : OpenAnswerExercise
{
    public List<Verb> Verbs { get; set; }
    
    public class Verb
    {
        public string MotherLanguage { get; set; }
        public string FirstForm { get; set; }
        public string SecondForm { get; set; }
        public string ThirdForm { get; set; }
    }
}

public class QuestionsToTextOpen : OpenAnswerExercise
{
    public string Text { get; set; }
    public List<string> Questions { get; set; }
}

public class PassiveSideOpen : OpenAnswerExercise
{
    public List<string> Sentences { get; set; }
}

public class ParaphrasingOpen : OpenAnswerExercise
{
    public List<SentenceWithParaphrasing> Sentences { get; set; }
    
    public class SentenceWithParaphrasing
    {
        public string Sentence { get; set; }
        public string PhrasalVerb { get; set; }
    }
}

public class AnswerToQuestionOpen : OpenAnswerExercise
{
    public List<string> Sentences { get; set; }
}

public class ConditionalOpen : OpenAnswerExercise
{
    public List<string> ZeroConditionalSentences { get; set; }
    public List<string> FirstConditionalSentences { get; set; }
    public List<string> SecondConditionalSentences { get; set; }
    public List<string> ThirdConditionalSentences { get; set; }
}

public class MissingPhrasalVerbOpen : OpenAnswerExercise
{
    public List<SentenceWithPhrasalVerb> SentencesWithPhrasalVerb { get; set; }
    public class SentenceWithPhrasalVerb
    {
        public string SentenceWithUnderscoreInsteadOfPhrasalVerb { get; set; }
        public string CorrectPhrasalVerb { get; set; }
        public string CorrectSentence { get; set; }
    }
}

public class MissingWordOrExpressionOpen : OpenAnswerExercise
{
    public List<SentenceWithMisingWordOrExpression> SentencesWithMisingWordOrExpression { get; set; }
    public class SentenceWithMisingWordOrExpression
    {
        public string SentenceWithUnderscoreInsteadOfWordOrExpression { get; set; }
        public string CorrectWordOrExpression { get; set; }
        public string CorrectSentence { get; set; }
    }
}

//TODO: add word meaning open exercise