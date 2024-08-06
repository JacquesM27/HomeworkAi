namespace HomeworkAi.Modules.Contracts.DTOs.Complex;

public abstract class ExerciseAnswerDto
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
}

public abstract class OpenFormExerciseAnswerDto : ExerciseAnswerDto;

public abstract class ClosedAnswerExerciseAnswerDto : ExerciseAnswerDto
{
    public List<Answer> Answers { get; set; }
}
public abstract class OpenAnswerExerciseAnswerDto : ExerciseAnswerDto
{
    public List<Answer> Answers { get; set; }
}

public class OpenFormExerciseAnswerMailDto : OpenFormExerciseAnswerDto
{
    public string WrittenMail { get; set; }
}

public class OpenFormExerciseAnswerEssayDto : OpenFormExerciseAnswerDto
{
    public string WrittenEssay { get; set; }
}

public class OpenFormExerciseAnswerSummaryOfTextDto : OpenFormExerciseAnswerDto
{
    public string WrittenSummary { get; set; }
}

public class ClosedAnswerExerciseAnswerQuestionsToText : ClosedAnswerExerciseAnswerDto;
public class ClosedAnswerExerciseAnswerPassiveSide : ClosedAnswerExerciseAnswerDto;
public class ClosedAnswerExerciseAnswerParaphrasing : ClosedAnswerExerciseAnswerDto;
public class ClosedAnswerExerciseAnswerAnswerToQuestion : ClosedAnswerExerciseAnswerDto;
public class ClosedAnswerExerciseAnswerConditional : ClosedAnswerExerciseAnswerDto;
public class ClosedAnswerExerciseAnswerWordMeaning : ClosedAnswerExerciseAnswerDto;
public class ClosedAnswerExerciseAnswerPhrasalVerbsTranslating : ClosedAnswerExerciseAnswerDto;
public class ClosedAnswerExerciseAnswerMissingPhrasalVerb : ClosedAnswerExerciseAnswerDto;
public class ClosedAnswerExerciseAnswerMissingWordOrExpression : ClosedAnswerExerciseAnswerDto;

public class OpenAnswerExerciseAnswerAnswerToQuestion : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerConditional : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerIrregularVerbs : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerMissingPhrasalVerb : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerMissingWordOrExpression : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerParaphrasing : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerPassiveSide : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerQuestionsToText : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerSentencesTranslation : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerSentenceWithVerbToCompleteBasedOnInfinitive : OpenAnswerExerciseAnswerDto;
public class OpenAnswerExerciseAnswerWordMeaning : OpenAnswerExerciseAnswerDto;

public class Answer
{
    public int No { get; set; }
    public string Text { get; set; }
}