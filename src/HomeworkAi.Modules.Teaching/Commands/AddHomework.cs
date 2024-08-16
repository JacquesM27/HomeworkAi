using HomeworkAi.Infrastructure.Commands;

namespace HomeworkAi.Modules.Teaching.Commands;

public sealed record AddHomework : ICommand
{
    public string Name { get; init; }

    //TODO: replace with user id.
    public Guid TeacherId { get; init; }
    public Guid ClassId { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime DueDate { get; init; }

    public IList<Guid> MailIds { get; init; }
    public IList<Guid> EssayIds { get; init; }
    public IList<Guid> SummaryOfTextIds { get; init; }
    
    public IList<Guid> QuestionsToTextClosedIds { get; init; }
    public IList<Guid> PassiveSideClosedIds { get; init; }
    public IList<Guid> ParaphrasingClosedIds { get; init; }
    public IList<Guid> AnswersToQuestionsClosedIds { get; init; }
    public IList<Guid> ConditionalClosedIds { get; init; }
    public IList<Guid> WordMeaningClosedIds { get; init; }
    public IList<Guid> PhrasalVerbsTranslatingIds { get; init; }
    public IList<Guid> MissingPhrasalVerbClosedIds { get; init; }
    public IList<Guid> MissingWordOrExpressionClosedIds { get; init; }
    
    public IList<Guid> AnswersToQuestionsOpenIds { get; init; }
    public IList<Guid> ConditionalOpenIds { get; init; }
    public IList<Guid> IrregularVerbsIds { get; init; }
    public IList<Guid> MissingPhrasalVerbsOpenIds { get; init; }
    public IList<Guid> ParaphrasingOpenIds { get; init; }
    public IList<Guid> PassiveSideOpenIds { get; init; }
    public IList<Guid> QuestionsToTextOpenIds { get; init; }
    public IList<Guid> SentencesTranslationIds { get; init; }
    public IList<Guid> SentencesWithVerbToCompleteBasedOnInfinitiveIds { get; init; }
    public IList<Guid> SentencesWithVerbToCompleteIds { get; init; }
    public IList<Guid> WordMeaningsOpenIds { get; init; }  
}