namespace HomeworkAi.Modules.Persistence.DAL.Entities;

public class HomeworkResultEntity
{
    public Guid Id { get; set; }
    public HomeworkEntity Homework { get; set; }
    public StudentEntity Student { get; set; }
    
    public IList<MailOpenFormAnswerEntity> Mails { get; set; }
    public IList<EssayOpenFormAnswerEntity> Essays { get; set; }
    public IList<SummaryOfTextOpenFormAnswerEntity> SummariesOfTexts { get; set; }
    
    public IList<QuestionsToTextClosedAnswerEntity> QuestionsToTexts { get; set; }
    public IList<PassiveSideClosedAnswerEntity> PassiveSidesClosed { get; set; }
    public IList<ParaphrasingClosedAnswerEntity> ParaphrasingsClosed { get; set; }
    public IList<AnswerToQuestionClosedAnswerEntity> AnswersToQuestionsClosed { get; set; }
    public IList<ConditionalClosedAnswerEntity> ContitionalsClosed { get; set; }
    public IList<WordMeaningClosedAnswerEntity> WordMeaningsClosed { get; set; }
    public IList<PhrasalVerbsTranslatingAnswerEntity> PhrasalVerbsTranslatings { get; set; }
    public IList<MissingPhrasalVerbClosedAnswerEntity> MissingPhrasalVerbsClosed { get; set; }
    public IList<MissingWordOrExpressionClosedAnswerEntity> MissingWordsOrExperessionsClosed { get; set; }
    
    public IList<SentencesTranslationOpenAnswerEntity> SentencesTranslations { get; set; }
    public IList<SentenceWithVerbToCompleteBasedOnInfinitiveOpenAnswerEntity> SentencesWithVerbToCompleteBasedOnInfinitive { get; set; }
    public IList<SentenceWithVerbToCompleteOpenAnswerEntity> SentencesWithVerbToComplete { get; set; }
    public IList<IrregularVerbsOpenAnswerEntity> IrregularVerbs { get; set; }
    public IList<QuestionsToTextOpenAnswerEntity> QuestionsToTextsOpen { get; set; }
    public IList<PassiveSideOpenAnswerEntity> PassiveSidesOpen { get; set; }
    public IList<ParaphrasingOpenAnswerEntity> ParaphrasingsOpen { get; set; }
    public IList<AnswerToQuestionOpenAnswerEntity> AnswersToQuestionsOpen { get; set; }
    public IList<ConditionalOpenAnswerEntity> ContitionalsOpen { get; set; }
    public IList<MissingPhrasalVerbOpenAnswerEntity> MissingPhrasalVerbsOpen { get; set; }
    public IList<MissingWordOrExpressionOpenAnswerEntity> MissingWordsOrExperessionsOpen { get; set; }
    public IList<WordMeaningOpenAnswerEntity> WordMeaningsOpen { get; set; }
}