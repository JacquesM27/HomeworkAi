namespace HomeworkAi.Modules.Contracts.DTOs.Complex;

// public class ExerciseAnswerDto
// {
//     
// }

public class OpenFormExerciseAnswerMailDto : OpenFormExerciseMailDto
{
    public string WrittenMail { get; set; }
}

public class OpenFormExerciseAnswerEssayDto : OpenFormExerciseEssayDto
{
    public string WrittenEssay { get; set; }
}

public class OpenFormExerciseAnswerSummaryOfTextDto : OpenFormExerciseSummaryOfTextDto
{
    public string WrittenSummary { get; set; }
}

public class OpenAnswerExerciseAnswerSentencesTranslationDto : OpenAnswerExerciseSentencesTranslationDto
{
    public List<string> SentencesAnswers { get; set; }
}