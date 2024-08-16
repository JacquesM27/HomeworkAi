using HomeworkAi.Modules.Contracts.DTOs.Complex;

namespace HomeworkAi.Modules.Contracts.Teaching;

public class Homework
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Teacher Teacher { get; set; }
    public Class Class { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    
    public IList<OpenFormExerciseMailDto> Mails { get; set; }
    public IList<OpenFormExerciseEssayDto> Essays { get; set; }
    public IList<OpenFormExerciseSummaryOfTextDto> SummariesOfTextsClosed { get; set; }

    public IList<ClosedAnswerExerciseQuestionsToTextDto> QuestionsToTextsClosed { get; set; }
    public IList<ClosedAnswerExercisePassiveSideDto> PassiveSidesClosed { get; set; }
    public IList<ClosedAnswerExerciseParaphrasingDto> ParaphrasingsClosed { get; set; }
    public IList<ClosedAnswerExerciseAnswerToQuestionDto> AnswersToQuestionsClosed { get; set; }
    public IList<ClosedAnswerExerciseConditionalDto> ContitionalsClosed { get; set; }
    public IList<ClosedAnswerExerciseWordMeaningDto> WordMeaningsClosed { get; set; }
    public IList<ClosedAnswerExercisePhrasalVerbsTranslatingDto> PhrasalVerbsTranslatings { get; set; }
    public IList<ClosedAnswerExerciseMissingPhrasalVerbDto> MissingPhrasalVerbsClosed { get; set; }
    public IList<ClosedAnswerExerciseMissingWordOrExpressionDto> MissingWordsOrExperessionsClosed { get; set; }
    
    public IList<OpenAnswerExerciseAnswerToQuestionDto> AnswersToQuestionsOpen { get; set; }
    public IList<OpenAnswerExerciseConditionalDto> ContitionalsOpen { get; set; }
    public IList<OpenAnswerExerciseIrregularVerbsDto> IrregularVerbs { get; set; }
    public IList<OpenAnswerExerciseMissingPhrasalVerbDto> MissingPhrasalVerbsOpen { get; set; }
    public IList<OpenAnswerExerciseMissingWordOrExpressionDto> MissingWordsOrExperessionsOpen { get; set; }
    public IList<OpenAnswerExerciseParaphrasingDto> ParaphrasingsOpen { get; set; }
    public IList<OpenAnswerExercisePassiveSideDto> PassiveSidesOpen { get; set; }
    public IList<OpenAnswerExerciseQuestionsToTextDto> QuestionsToTextsOpen { get; set; }
    public IList<OpenAnswerExerciseSentencesTranslationDto> SentencesTranslations { get; set; }
    public IList<OpenAnswerExerciseSentenceWithVerbToCompleteBasedOnInfinitiveDto> SentencesWithVerbToCompleteBasedOnInfinitive { get; set; }
    public IList<OpenAnswerExerciseSentenceWithVerbToCompleteDto> SentencesWithVerbToComplete { get; set; }
    public IList<OpenAnswerExerciseWordMeaningDto> WordMeaningsOpen { get; set; }
}