namespace HomeworkAi.Core.DTO.Exercises;

public abstract class OpenFormExercise : Exercise
{
}

public class MailExercise : OpenFormExercise
{
}

public class Essay : OpenFormExercise
{    
}

public class SummaryOfText : OpenFormExercise
{    
    public string TextToSummary { get; set; }
}
