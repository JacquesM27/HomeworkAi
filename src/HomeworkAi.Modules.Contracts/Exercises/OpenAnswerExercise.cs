namespace HomeworkAi.Modules.Contracts.Exercises;

public abstract class OpenAnswerExercise : Exercise
{
}

public class SentencesTranslation : OpenAnswerExercise
{
    public List<Sentence> Sentences { get; set; }
    
    public class Sentence
    {
        public int No { get; set; }
        public string Text { get; set; }
    }
}

public class SentenceWithVerbToCompleteBasedOnInfinitive : OpenAnswerExercise
{
    public List<Sentence> Sentences { get; set; }

    public class Sentence
    {
        public int No { get; set; }
        public string Text { get; set; }
        public string Infinitive { get; set; }
        public string CorrectAnswer { get; set; }
    }
}

//TODO
public class SentenceWithVerbToComplete : OpenAnswerExercise
{
    public List<Sentence> Sentences { get; set; }

    public class Sentence
    {
        public int No { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
    }
}

public class IrregularVerbs : OpenAnswerExercise
{
    public List<Verb> Verbs { get; set; }

    public class Verb
    {
        public int No { get; set; }
        public MotherLanguage MotherLanguageVerb { get; set; }
        public TargetLanguage TargetLanguageVerbForms { get; set; }

        public class MotherLanguage
        {
            public string VerbInMotherLanguage { get; set; }
        }

        public class TargetLanguage
        {
            public string FirstForm { get; set; }
            public string SecondForm { get; set; }
            public string ThirdForm { get; set; }
        }
    }
}

public class QuestionsToTextOpen : OpenAnswerExercise
{
    public string Text { get; set; }
    public List<Question> Questions { get; set; }
    public class Question
    {
        public int No { get; set; }
        public string Text { get; set; }
    }
}

public class PassiveSideOpen : OpenAnswerExercise
{
    public List<Sentence> Sentences { get; set; }
    
    public class Sentence
    {
        public int No { get; set; }
        public string Text { get; set; }
    }
}

public class ParaphrasingOpen : OpenAnswerExercise
{
    public List<SentenceWithParaphrasing> Sentences { get; set; }

    public class SentenceWithParaphrasing
    {
        public int No { get; set; }
        public string Sentence { get; set; }
    }
}

public class AnswerToQuestionOpen : OpenAnswerExercise
{
    public List<Sentence> Sentences { get; set; }
    
    public class Sentence
    {
        public int No { get; set; }
        public string Text { get; set; }
    }
}

public class ConditionalOpen : OpenAnswerExercise
{
    public List<Sentence> ZeroConditionalSentences { get; set; }
    public List<Sentence> FirstConditionalSentences { get; set; }
    public List<Sentence> SecondConditionalSentences { get; set; }
    public List<Sentence> ThirdConditionalSentences { get; set; }
    
    public class Sentence
    {
        public int No { get; set; }
        public string Text { get; set; }
    }
}

public class MissingPhrasalVerbOpen : OpenAnswerExercise
{
    public List<SentenceWithPhrasalVerb> SentencesWithPhrasalVerb { get; set; }

    public class SentenceWithPhrasalVerb
    {
        public int No { get; set; }
        public string SentenceWithUnderscoreInsteadOfPhrasalVerb { get; set; }
        public string CorrectPhrasalVerb { get; set; }
    }
}

public class MissingWordOrExpressionOpen : OpenAnswerExercise
{
    public List<SentenceWithMisingWordOrExpression> SentencesWithMisingWordOrExpression { get; set; }

    public class SentenceWithMisingWordOrExpression
    {
        public int No { get; set; }
        public string SentenceWithUnderscoreInsteadOfWordOrExpression { get; set; }
        public string CorrectWordOrExpression { get; set; }
    }
}

public class WordMeaningOpen : OpenAnswerExercise
{
    public List<Word> Words { get; set; }
    
    public class Word
    {
        public int No { get; set; }
        public string Text { get; set; }
    }
}