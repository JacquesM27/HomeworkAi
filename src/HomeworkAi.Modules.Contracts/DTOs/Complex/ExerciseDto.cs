
using HomeworkAi.Modules.Contracts.Exercises;
using HomeworkAi.Modules.Contracts.ValueObjects;

namespace HomeworkAi.Modules.Contracts.DTOs.Complex;

public abstract class ExerciseDto<TExercise>
{
    public Guid Id { get; } = Guid.NewGuid();
    public TExercise Exercise { get; set; }
    public bool ExerciseHeaderInMotherLanguage { get; set; }
    public Language MotherLanguage { get; set; }
    public Language TargetLanguage { get; set; }
    public string TargetLanguageLevel { get; set; }
    public string? TopicsOfSentences { get; set; }
    public string? GrammarSection { get; set; }
    public double AverageRating { get; set; }
    public int RatingCount { get; set; }
}

public abstract class OpenFormExerciseDto<TExercise> : ExerciseDto<TExercise>
    where TExercise : OpenFormExercise
{
}

public abstract class OpenAnswerExerciseDto<TExercise> : ExerciseDto<TExercise>
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

public abstract class ClosedAnswerExerciseDto<TExercise> : ExerciseDto<TExercise>
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

public class OpenFormExerciseMailDto : OpenFormExerciseDto<Mail>;

public class OpenFormExerciseEssayDto : OpenFormExerciseDto<Essay>;

public class OpenFormExerciseSummaryOfTextDto : OpenFormExerciseDto<SummaryOfText>;

public class OpenAnswerExerciseSentencesTranslationDto : OpenAnswerExerciseDto<SentencesTranslation>;

public class
    OpenAnswerExerciseSentenceWithVerbToCompleteBasedOnInfinitiveDto : OpenAnswerExerciseDto<
    SentenceWithVerbToCompleteBasedOnInfinitive>;

//TODO
public class
    OpenAnswerExerciseSentenceWithVerbToCompleteDto : OpenAnswerExerciseDto<SentenceWithVerbToComplete>;

public class OpenAnswerExerciseIrregularVerbsDto : OpenAnswerExerciseDto<IrregularVerbs>;

public class OpenAnswerExerciseQuestionsToTextDto : OpenAnswerExerciseDto<QuestionsToTextOpen>;

public class OpenAnswerExercisePassiveSideDto : OpenAnswerExerciseDto<PassiveSideOpen>;

public class OpenAnswerExerciseParaphrasingDto : OpenAnswerExerciseDto<ParaphrasingOpen>;

public class OpenAnswerExerciseAnswerToQuestionDto : OpenAnswerExerciseDto<AnswerToQuestionOpen>;

public class OpenAnswerExerciseConditionalDto : OpenAnswerExerciseDto<ConditionalOpen>;

public class OpenAnswerExerciseMissingPhrasalVerbDto : OpenAnswerExerciseDto<MissingPhrasalVerbOpen>;

public class
    OpenAnswerExerciseMissingWordOrExpressionDto : OpenAnswerExerciseDto<MissingWordOrExpressionOpen>;

public class OpenAnswerExerciseWordMeaningDto : OpenAnswerExerciseDto<WordMeaningOpen>;

public class ClosedAnswerExerciseQuestionsToTextDto : ClosedAnswerExerciseDto<QuestionsToTextClosed>;

public class ClosedAnswerExercisePassiveSideDto : ClosedAnswerExerciseDto<PassiveSideClosed>;

public class ClosedAnswerExerciseParaphrasingDto : ClosedAnswerExerciseDto<ParaphrasingClosed>;

public class ClosedAnswerExerciseAnswerToQuestionDto : ClosedAnswerExerciseDto<AnswerToQuestionClosed>;

public class ClosedAnswerExerciseConditionalDto : ClosedAnswerExerciseDto<ConditionalClosed>;

public class ClosedAnswerExerciseWordMeaningDto : ClosedAnswerExerciseDto<WordMeaningClosed>;

//TODO
public class
    ClosedAnswerExercisePhrasalVerbsTranslatingDto : ClosedAnswerExerciseDto<PhrasalVerbsTranslating>;

public class ClosedAnswerExerciseMissingPhrasalVerbDto : ClosedAnswerExerciseDto<MissingPhrasalVerbClosed>;

public class
    ClosedAnswerExerciseMissingWordOrExpressionDto : ClosedAnswerExerciseDto<MissingWordOrExpressionClosed>;