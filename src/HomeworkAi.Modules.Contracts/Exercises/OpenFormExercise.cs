namespace HomeworkAi.Modules.Contracts.Exercises;

public abstract class OpenFormExercise : Exercise
{
}

public class Mail : OpenFormExercise
{
}

public class Essay : OpenFormExercise
{    
}

public class SummaryOfText : OpenFormExercise
{    
    public string TextToSummary { get; set; }
}
