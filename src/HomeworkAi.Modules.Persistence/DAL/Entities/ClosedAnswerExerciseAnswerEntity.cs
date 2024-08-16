namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public abstract class ClosedAnswerExerciseAnswerEntity<TExercise> where TExercise : ClosedAnswerExerciseEntity
{
    public Guid Id { get; set; }
    public TExercise Exercise { get; set; }
}

public sealed class QuestionsToTextClosedAnswerEntity : ClosedAnswerExerciseAnswerEntity<QuestionsToTextClosedEntity>;
public sealed class PassiveSideClosedAnswerEntity : ClosedAnswerExerciseAnswerEntity<PassiveSideClosedEntity>;
public sealed class ParaphrasingClosedAnswerEntity : ClosedAnswerExerciseAnswerEntity<ParaphrasingClosedEntity>;
public sealed class AnswerToQuestionClosedAnswerEntity : ClosedAnswerExerciseAnswerEntity<AnswerToQuestionClosedEntity>;
public sealed class ConditionalClosedAnswerEntity : ClosedAnswerExerciseAnswerEntity<ConditionalClosedEntity>;
public sealed class WordMeaningClosedAnswerEntity : ClosedAnswerExerciseAnswerEntity<WordMeaningClosedEntity>;
public sealed class PhrasalVerbsTranslatingAnswerEntity : ClosedAnswerExerciseAnswerEntity<PhrasalVerbsTranslatingEntity>;
public sealed class MissingPhrasalVerbClosedAnswerEntity : ClosedAnswerExerciseAnswerEntity<MissingPhrasalVerbClosedEntity>;
public sealed class MissingWordOrExpressionClosedAnswerEntity : ClosedAnswerExerciseAnswerEntity<MissingWordOrExpressionClosedEntity>;
