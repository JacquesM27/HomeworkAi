namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public abstract class OpenAnswerExerciseAnswerEntity<TExercise> where TExercise : OpenAnswerExerciseEntity
{
    public Guid Id { get; set; }
    public TExercise Exercise { get; set; }
}

public sealed class SentencesTranslationOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<SentencesTranslationEntity>;
public sealed class SentenceWithVerbToCompleteBasedOnInfinitiveOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<SentenceWithVerbToCompleteBasedOnInfinitiveEntity>;
public sealed class SentenceWithVerbToCompleteOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<SentenceWithVerbToCompleteEntity>;
public sealed class IrregularVerbsOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<IrregularVerbsEntity>;
public sealed class QuestionsToTextOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<QuestionsToTextOpenEntity>;
public sealed class PassiveSideOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<PassiveSideOpenEntity>;
public sealed class ParaphrasingOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<ParaphrasingOpenEntity>;
public sealed class AnswerToQuestionOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<AnswerToQuestionOpenEntity>;
public sealed class ConditionalOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<ConditionalOpenEntity>;
public sealed class MissingPhrasalVerbOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<MissingPhrasalVerbOpenEntity>;
public sealed class MissingWordOrExpressionOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<MissingWordOrExpressionOpenEntity>;
public sealed class WordMeaningOpenAnswerEntity : OpenAnswerExerciseAnswerEntity<WordMeaningOpenEntity>;
