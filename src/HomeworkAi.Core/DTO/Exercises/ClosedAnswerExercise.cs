namespace HomeworkAi.Core.DTO.Exercises;


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
