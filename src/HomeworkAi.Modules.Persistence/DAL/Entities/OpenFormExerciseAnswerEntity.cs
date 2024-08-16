namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public abstract class OpenFormExerciseAnswerEntity<TExercise> where TExercise : OpenFormExerciseEntity
{
    public Guid Id { get; set; }
    public TExercise Exercise { get; set; }
}

public sealed class MailOpenFormAnswerEntity : OpenFormExerciseAnswerEntity<MailEntity>;

public sealed class EssayOpenFormAnswerEntity : OpenFormExerciseAnswerEntity<EssayEntity>;
public sealed class SummaryOfTextOpenFormAnswerEntity : OpenFormExerciseAnswerEntity<SummaryOfTextEntity>;