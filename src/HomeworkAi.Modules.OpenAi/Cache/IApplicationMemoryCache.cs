namespace HomeworkAi.Core.Cache;

public interface IApplicationMemoryCache
{
    Type? GetExerciseType(string exerciseName);
    IEnumerable<string> GetClosedAnswerExercises();
    IEnumerable<string> GetOpenAnswerExercises();
    IEnumerable<string> GetOpenFormExercises();
    IEnumerable<string> GetLanguages();
}