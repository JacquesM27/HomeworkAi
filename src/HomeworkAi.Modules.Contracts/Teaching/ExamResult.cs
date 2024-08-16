using HomeworkAi.Modules.Contracts.DTOs.Complex;

namespace HomeworkAi.Modules.Contracts.Teaching;

public class ExamResult
{
    public Guid Id { get; set; }
    public Exam Exam { get; set; }
    public Student Student { get; set; }
    
    public IList<OpenFormExerciseAnswerMailDto> Mails { get; set; }
    public IList<OpenFormExerciseAnswerEssayDto> Essays { get; set; }
    public IList<OpenFormExerciseAnswerSummaryOfTextDto> SummariesOfTexts { get; set; }
    
    public IList<ClosedAnswerExerciseAnswerQuestionsToText> QuestionsToTexts { get; set; }
    public IList<ClosedAnswerExerciseAnswerPassiveSide> PassiveSidesClosed { get; set; }
    public IList<ClosedAnswerExerciseAnswerParaphrasing> ParaphrasingsClosed { get; set; }
    public IList<ClosedAnswerExerciseAnswerAnswerToQuestion> AnswersToQuestionsClosed { get; set; }
    public IList<ClosedAnswerExerciseAnswerConditional> ContitionalsClosed { get; set; }
    public IList<ClosedAnswerExerciseAnswerWordMeaning> WordMeaningsClosed { get; set; }
    public IList<ClosedAnswerExerciseAnswerPhrasalVerbsTranslating> PhrasalVerbsTranslatings { get; set; }
    public IList<ClosedAnswerExerciseAnswerMissingPhrasalVerb> MissingPhrasalVerbsClosed { get; set; }
    public IList<ClosedAnswerExerciseAnswerMissingWordOrExpression> MissingWordsOrExperessionsClosed { get; set; }
    
    public IList<OpenAnswerExerciseAnswerSentencesTranslation> SentencesTranslations { get; set; }
    public IList<OpenAnswerExerciseAnswerSentenceWithVerbToCompleteBasedOnInfinitive> SentencesWithVerbToCompleteBasedOnInfinitive { get; set; }
    public IList<OpenAnswerExerciseAnswerSentenceWithVerbToComplete> SentencesWithVerbToComplete { get; set; }
    public IList<OpenAnswerExerciseAnswerIrregularVerbs> IrregularVerbs { get; set; }
    public IList<OpenAnswerExerciseAnswerQuestionsToText> QuestionsToTextsOpen { get; set; }
    public IList<OpenAnswerExerciseAnswerPassiveSide> PassiveSidesOpen { get; set; }
    public IList<OpenAnswerExerciseAnswerParaphrasing> ParaphrasingsOpen { get; set; }
    public IList<OpenAnswerExerciseAnswerAnswerToQuestion> AnswersToQuestionsOpen { get; set; }
    public IList<OpenAnswerExerciseAnswerConditional> ContitionalsOpen { get; set; }
    public IList<OpenAnswerExerciseAnswerMissingPhrasalVerb> MissingPhrasalVerbsOpen { get; set; }
    public IList<OpenAnswerExerciseAnswerMissingWordOrExpression> MissingWordsOrExperessionsOpen { get; set; }
    public IList<OpenAnswerExerciseAnswerWordMeaning> WordMeaningsOpen { get; set; }
}