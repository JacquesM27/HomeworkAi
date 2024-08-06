namespace HomeworkAi.Modules.Contracts.Exercises;

public abstract class ClosedAnswerExercise : Exercise
{
}

public class QuestionsToTextClosed : ClosedAnswerExercise
{
    public string Text { get; set; }
    public List<ClosedQuestion> Questions { get; set; }
}

public class PassiveSideClosed : ClosedAnswerExercise
{
    public List<ClosedQuestion> Sentences { get; set; }
}

public class ParaphrasingClosed : ClosedAnswerExercise
{
    public List<ClosedQuestion> Sentences { get; set; }
}

public class AnswerToQuestionClosed : ClosedAnswerExercise
{
    public List<ClosedQuestion> Sentences { get; set; }
}

public class ConditionalClosed : ClosedAnswerExercise
{
    public List<ClosedQuestion> ZeroConditionalSentences { get; set; }
    public List<ClosedQuestion> FirstConditionalSentences { get; set; }
    public List<ClosedQuestion> SecondConditionalSentences { get; set; }
    public List<ClosedQuestion> ThirdConditionalSentences { get; set; }
}

public class WordMeaningClosed : ClosedAnswerExercise
{
    public List<WordMeaning> WordMeanings { get; set; }

    public class WordMeaning
    {
        public int No { get; set; }
        public string Word { get; set; }
        public List<MeaningAnswer> MeaningAnswers { get; set; }
    }

    public class MeaningAnswer
    {
        public string ShortDescription { get; set; }
        public bool Correct { get; set; }
    }
}
//wyrażenia (break a record, catch an eye on)?
//TODO
public class PhrasalVerbsTranslating : ClosedAnswerExercise
{
    public List<ClosedQuestion> SentenceWithPhrasalVerb { get; set; }
}

public class MissingPhrasalVerbClosed : ClosedAnswerExercise
{
    public List<SentenceWithPhrasalVerb> SentencesWithPhrasalVerb { get; set; }

    public class SentenceWithPhrasalVerb
    {
        public int No { get; set; }
        public string SentenceWithUnderscoreInsteadOfPhrasalVerb { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

public class MissingWordOrExpressionClosed : ClosedAnswerExercise
{
    public List<SentenceWithMisingWordOrExpression> SentencesWithMisingWordOrExpression { get; set; }

    public class SentenceWithMisingWordOrExpression
    {
        public int No { get; set; }
        public string SentenceWithUnderscoreInsteadOfWordOrExpression { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

public class ClosedQuestion
{
    public int No { get; set; }
    public string Text { get; set; }
    public List<Answer> Answers { get; set; }
}

public class Answer
{
    public string Text { get; set; }
    public bool Correct { get; set; }
}