namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public class HomeworkEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public TeacherEntity Teacher { get; set; }
    public ClassEntity Class { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    
    public IList<MailEntity> Mails { get; set; }
    public IList<EssayEntity> Essays { get; set; }
    public IList<SummaryOfTextEntity> SummariesOfTexts { get; set; }

    public IList<QuestionsToTextClosedEntity> QuestionsToTextsClosed { get; set; }
    public IList<PassiveSideClosedEntity> PassiveSidesClosed { get; set; }
    public IList<ParaphrasingClosedEntity> ParaphrasingsClosed { get; set; }
    public IList<AnswerToQuestionClosedEntity> AnswersToQuestionsClosed { get; set; }
    public IList<ConditionalClosedEntity> ConditionalsClosed { get; set; }
    public IList<WordMeaningClosedEntity> WordMeaningsClosed { get; set; }
    public IList<PhrasalVerbsTranslatingEntity> PhrasalVerbsTranslatings { get; set; }
    public IList<MissingPhrasalVerbClosedEntity> MissingPhrasalVerbsClosed { get; set; }
    public IList<MissingWordOrExpressionClosedEntity> MissingWordsOrExperessionsClosed { get; set; }
    
    public IList<SentencesTranslationEntity> SentencesTranslations { get; set; }
    public IList<SentenceWithVerbToCompleteBasedOnInfinitiveEntity> SentencesWithVerbToCompleteBasedOnInfinitive { get; set; }
    public IList<SentenceWithVerbToCompleteEntity> SentencesWithVerbToComplete { get; set; }
    public IList<IrregularVerbsEntity> IrregularVerbs { get; set; }
    public IList<QuestionsToTextOpenEntity> QuestionsToTextsOpen { get; set; }
    public IList<PassiveSideOpenEntity> PassiveSidesOpen { get; set; }
    public IList<ParaphrasingOpenEntity> ParaphrasingsOpen { get; set; }
    public IList<AnswerToQuestionOpenEntity> AnswersToQuestionsOpen { get; set; }
    public IList<ConditionalOpenEntity> ContitionalsOpen { get; set; }
    public IList<MissingPhrasalVerbOpenEntity> MissingPhrasalVerbsOpen { get; set; }
    public IList<MissingWordOrExpressionOpenEntity> MissingWordsOrExperessionsOpen { get; set; }
    public IList<WordMeaningOpenEntity> WordMeaningsOpen { get; set; }
}