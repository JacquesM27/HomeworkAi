namespace HomeworkAi.Core.DTO.Exercises;

public abstract class Exercise
{
    public ExerciseHeader Header { get; set; }
    
    public class ExerciseHeader
    {
        public string Title { get; set; }
        public string TaskDescription  { get; set; }
        public string Instruction { get; set; }
        public string Example { get; set; }
        public string SupportMaterial { get; set; }
    }
}
//TODO: move to otherfiles
#region open form
public abstract class OpenFormExercise : Exercise
{
}

public class MailExercise : OpenFormExercise
{
}

public class Essay : OpenFormExercise
{    
}

public class SummaryOfText : OpenFormExercise
{    
    public string TextToSummary { get; set; }
}
#endregion

#region open answers
public abstract class OpenAnswerExercise : Exercise
{
}

public class SentencesTranscription : Exercise
{
    public List<string> Sentences { get; set; }
}

public class SentenceWithVerbToCompleteBasedOnInfinitive : Exercise
{
    public List<Sentence> Sentences { get; set; }
    
    public class Sentence
    {
        public string Text { get; set; }
        public string Infinitive { get; set; }
        public string CorrectAnswer { get; set; }
    }
}

public class SentenceWithVerbToComplete : Exercise
{
    public List<Sentence> Sentences { get; set; }
    
    public class Sentence
    {
        public string Text { get; set; }
        // string Verb { get; set; }
        public string CorrectAnswer { get; set; }
    }
}

public class IrregularVerbs : Exercise
{
    public List<Verb> Verbs { get; set; }
    public bool ShowMotherLanguage { get; set; }
    public bool ShowFirstForm { get; set; }
    
    public class Verb
    {
        public string MotherLanguage { get; set; }
        public string FirstForm { get; set; }
        public string SecondForm { get; set; }
        public string ThirdForm { get; set; }
    }
}

// Something is wrong with this class
// public class WordFormation : Exercise
// {
//     public List<Sentence> Sentences { get; set; }
//         
//     public class Sentence
//     {
//         public string Text { get; set; }
//         public string Verb { get; set; }
//         public string CorrectAnswer { get; set; }
//     }
// }

public class QuestionsToTextOpen : Exercise
{
    public string Text { get; set; }
    public List<string> Questions { get; set; }
}

public class PassiveSideOpen : Exercise
{
    public List<string> Sentences { get; set; }
}

public class ParaphrasingOpen : Exercise
{
    public List<SentenceWithParaphrasing> Sentences { get; set; }
    
    public class SentenceWithParaphrasing
    {
        public string Sentence { get; set; }
        public string PhrasalVerb { get; set; }
    }
}

public class AnswerToQuestionOpen : Exercise
{
    public List<string> Sentences { get; set; }
}

public class ConditionalOpen : Exercise
{
    public List<string> ZeroConditionalSentences { get; set; }
    public List<string> FirstConditionalSentences { get; set; }
    public List<string> SecondConditionalSentences { get; set; }
    public List<string> ThirdConditionalSentences { get; set; }
}

public class MissingPhrasalVerbsOpen : Exercise
{
    public List<SentenceWithPhrasalVerb> SentencesWithPhrasalVerb { get; set; }
    public class SentenceWithPhrasalVerb
    {
        public string SentenceWithUnderscoreInsteadOfPhrasalVerb { get; set; }
        public string CorrectPhrasalVerb { get; set; }
        public string CorrectSentence { get; set; }
    }
}

public class MissingWordOrExpressionOpen : Exercise
{
    public List<SentenceWithMisingWordOrExpression> SentencesWithMisingWordOrExpression { get; set; }
    public class SentenceWithMisingWordOrExpression
    {
        public string SentenceWithUnderscoreInsteadOfWordOrExpression { get; set; }
        public string CorrectWordOrExpression { get; set; }
        public string CorrectSentence { get; set; }
    }
}


#endregion

#region closed answers
public class QuestionsToTextClosed : Exercise
{
    public string Text { get; set; }
    public List<ClosedQuestion> Questions { get; set; }
}

public class PassiveSideClosed : Exercise
{
    public List<ClosedQuestion> Sentences { get; set; }
}

public class ParaphrasingClosed : Exercise
{
    public List<ClosedQuestion> Sentences { get; set; }
}

public class AnswerToQuestionClosed : Exercise
{
    public List<ClosedQuestion> Sentences { get; set; }
}

public class ConditionalClosed : Exercise
{
    public List<ClosedQuestion> ZeroConditionalSentences { get; set; }
    public List<ClosedQuestion> FirstConditionalSentences { get; set; }
    public List<ClosedQuestion> SecondConditionalSentences { get; set; }
    public List<ClosedQuestion> ThirdConditionalSentences { get; set; }
}

public class SentenceFormationClosed : Exercise
{
    public List<Sentence> Sentences { get; set; }
    
    public class Sentence
    {
        public List<string> Words { get; set; }
        public string CorrectAnswer { get; set; }
    }
}

public class WordMeaning : Exercise
{
    public List<CorrectMeaning> CorrectMeanings { get; set; }

    public class CorrectMeaning
    {
        public string Word { get; set; }
        public string CorrectWordMeaning { get; set; }
    }
}

public class PhrasalVerbsTranslating : Exercise
{
    public List<ClosedQuestion> SentenceWithPhrasalVerb { get; set; }
}

public class MissingPhrasalVerbsClosed : Exercise
{
    public List<SentenceWithPhrasalVerb> SentencesWithPhrasalVerb { get; set; }
    public class SentenceWithPhrasalVerb
    {
        public string SentenceWithUnderscoreInsteadOfPhrasalVerb { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

public class MissingWordOrExpressionClosed : Exercise
{
    public List<SentenceWithMisingWordOrExpression> SentencesWithMisingWordOrExpression { get; set; }
    public class SentenceWithMisingWordOrExpression
    {
        public string SentenceWithUnderscoreInsteadOfWordOrExpression { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

public class ClosedQuestion
{
    public string Text { get; set; }
    public List<Answer> Answers { get; set; }
}

public class Answer
{
    public string Text { get; set; }
    public bool Correct { get; set; }
}

#endregion