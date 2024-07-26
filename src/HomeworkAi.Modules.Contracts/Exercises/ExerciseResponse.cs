// using System.Text.Json.Serialization;
using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Modules.Contracts.Exercises;

// [JsonDerivedType(typeof(OpenFormExerciseResponseMail), nameof(OpenFormExerciseResponseMail))]
// [JsonDerivedType(typeof(OpenFormExerciseResponseEssay), nameof(OpenFormExerciseResponseEssay))]
// [JsonDerivedType(typeof(OpenFormExerciseResponseSummaryOfText), nameof(OpenFormExerciseResponseSummaryOfText))]
public interface IExerciseResponse
{
    
}

public abstract class ExerciseResponse<TExercise> : IExerciseResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public TExercise Exercise { get; set; }
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public Language MotherLanguage { get; set; }
    public Language TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
}

public abstract class OpenFormExerciseResponse<TExercise> : ExerciseResponse<TExercise>
    where TExercise : OpenFormExercise
{
    
}

public abstract class OpenAnswerExerciseResponse<TExercise> : ExerciseResponse<TExercise>
    where TExercise : OpenAnswerExercise
{
    public int? AmountOfSentences { get; set; }
    public bool? TranslateFromMotherLanguage { get; set; }
    public bool? QuestionsInMotherLanguage { get; set; }
    
    public bool? ZeroConditional { get; set; }
    public bool? FirstConditional { get; set; }
    public bool? SecondConditional { get; set; }
    public bool? ThirdConditional { get; set; }

    public bool? ShowMotherLanguage { get; set; }
    public bool? ShowFirstForm { get; set; }
}

public abstract class ClosedAnswerExerciseResponse<TExercise> : ExerciseResponse<TExercise>
    where TExercise : ClosedAnswerExercise
{
    public int? AmountOfSentences { get; set; }
    
    public bool? TranslateFromMotherLanguage { get; set; }
    public bool? QuestionsInMotherLanguage { get; set; }
    
    public bool? ZeroConditional { get; set; }
    public bool? FirstConditional { get; set; }
    public bool? SecondConditional { get; set; }
    public bool? ThirdConditional { get; set; }

    public bool? DescriptionInMotherLanguage { get; set; }
}


public class OpenFormExerciseResponseMail : OpenFormExerciseResponse<Mail>;

public class OpenFormExerciseResponseEssay : OpenFormExerciseResponse<Essay>;

public class OpenFormExerciseResponseSummaryOfText : OpenFormExerciseResponse<SummaryOfText>;

public class OpenAnswerExerciseResponseSentencesTranslation : OpenAnswerExerciseResponse<SentencesTranslation>;

public class OpenAnswerExerciseResponseSentenceWithVerbToCompleteBasedOnInfinitive : OpenAnswerExerciseResponse<SentenceWithVerbToCompleteBasedOnInfinitive>;

//TODO
public class OpenAnswerExerciseResponseSentenceWithVerbToComplete : OpenAnswerExerciseResponse<SentenceWithVerbToComplete>;

public class OpenAnswerExerciseResponseIrregularVerbs : OpenAnswerExerciseResponse<IrregularVerbs>;

public class OpenAnswerExerciseResponseQuestionsToText : OpenAnswerExerciseResponse<QuestionsToTextOpen>;

public class OpenAnswerExerciseResponsePassiveSide : OpenAnswerExerciseResponse<PassiveSideOpen>;

public class OpenAnswerExerciseResponseParaphrasing : OpenAnswerExerciseResponse<ParaphrasingOpen>;

public class OpenAnswerExerciseResponseAnswerToQuestion : OpenAnswerExerciseResponse<AnswerToQuestionOpen>;

public class OpenAnswerExerciseResponseConditional : OpenAnswerExerciseResponse<ConditionalOpen>;

public class OpenAnswerExerciseResponseMissingPhrasalVerb : OpenAnswerExerciseResponse<MissingPhrasalVerbOpen>;

public class OpenAnswerExerciseResponseMissingWordOrExpression : OpenAnswerExerciseResponse<MissingWordOrExpressionOpen>;

public class OpenAnswerExerciseResponseWordMeaning : OpenAnswerExerciseResponse<WordMeaningOpen>;

public class ClosedAnswerExerciseResponseQuestionsToText : ClosedAnswerExerciseResponse<QuestionsToTextClosed>;

public class ClosedAnswerExerciseResponsePassiveSide : ClosedAnswerExerciseResponse<PassiveSideClosed>;

public class ClosedAnswerExerciseResponseParaphrasing : ClosedAnswerExerciseResponse<ParaphrasingClosed>;

public class ClosedAnswerExerciseResponseAnswerToQuestion : ClosedAnswerExerciseResponse<AnswerToQuestionClosed>;

public class ClosedAnswerExerciseResponseConditional : ClosedAnswerExerciseResponse<ConditionalClosed>;

public class ClosedAnswerExerciseResponseWordMeaning : ClosedAnswerExerciseResponse<WordMeaningClosed>;

//TODO
public class ClosedAnswerExerciseResponsePhrasalVerbsTranslating : ClosedAnswerExerciseResponse<PhrasalVerbsTranslating>;

public class ClosedAnswerExerciseResponseMissingPhrasalVerb : ClosedAnswerExerciseResponse<MissingPhrasalVerbClosed>;

public class ClosedAnswerExerciseResponseMissingWordOrExpression : ClosedAnswerExerciseResponse<MissingWordOrExpressionClosed>;
