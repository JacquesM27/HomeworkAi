using HomeworkAi.Modules.Contracts.DTOs.Complex;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Modules.Contracts.Teaching;

public class Homework
{
    public Guid Id { get; set; }

    //public IEnumerable<IExerciseResponse> Exercises { get; set; }
    public Teacher Teacher { get; set; }
    public Student? IndividualStudent { get; set; }
    public Class? Class { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    
    public List<OpenFormExerciseMailDto> Mails { get; set; }
    public List<OpenFormExerciseEssayDto> Essays { get; set; }
    public List<OpenFormExerciseSummaryOfTextDto> SummariesOfTexts { get; set; }

    public List<ClosedAnswerExerciseQuestionsToTextDto> QuestionsToTexts { get; set; }
    public List<ClosedAnswerExercisePassiveSideDto> PassiveSidesClosed { get; set; }
    public List<ClosedAnswerExerciseParaphrasingDto> ParaphrasingsClosed { get; set; }
    public List<ClosedAnswerExerciseAnswerToQuestionDto> AnswersToQuestionsClosed { get; set; }
    public List<ClosedAnswerExerciseConditionalDto> ContitionalsClosed { get; set; }
    public List<ClosedAnswerExerciseWordMeaningDto> WordMeaningsClosed { get; set; }
    public List<ClosedAnswerExercisePhrasalVerbsTranslatingDto> PhrasalVerbsTranslatings { get; set; }
    public List<ClosedAnswerExerciseMissingPhrasalVerbDto> MissingPhrasalVerbsClosed { get; set; }
    public List<ClosedAnswerExerciseMissingWordOrExpressionDto> MissingWordsOrExperessionsClosed { get; set; }
    
    public List<OpenAnswerExerciseAnswerToQuestionDto> AnswersToQuestionsOpen { get; set; }
    public List<OpenAnswerExerciseConditionalDto> ContitionalsOpen { get; set; }
    public List<OpenAnswerExerciseIrregularVerbsDto> IrregularVerbs { get; set; }
    public List<OpenAnswerExerciseMissingPhrasalVerbDto> MissingPhrasalVerbsOpen { get; set; }
    public List<OpenAnswerExerciseMissingWordOrExpressionDto> MissingWordsOrExperessionsOpen { get; set; }
    public List<OpenAnswerExerciseParaphrasingDto> ParaphrasingsOpen { get; set; }
    public List<OpenAnswerExercisePassiveSideDto> PassiveSidesOpen { get; set; }
    public List<OpenAnswerExerciseQuestionsToTextDto> QuestionsToTextsOpen { get; set; }
    public List<OpenAnswerExerciseSentencesTranslationDto> SentencesTranslations { get; set; }
    public List<OpenAnswerExerciseSentenceWithVerbToCompleteBasedOnInfinitiveDto> SentencesWithVerbToCompleteBasedOnInfinitive { get; set; }
    public List<OpenAnswerExerciseWordMeaningDto> WordMeaningsOpen { get; set; }
}