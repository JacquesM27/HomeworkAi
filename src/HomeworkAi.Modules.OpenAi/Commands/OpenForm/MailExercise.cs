using HomeworkAi.Infrastructure.Queries;
using HomeworkAi.Modules.Contracts.Exercises;

namespace HomeworkAi.Core.Commands.OpenForm;

public sealed record MailExercise : ExerciseCommandBase, IQuery<OpenFormExerciseResponse<Mail>>;

internal sealed class MailExerciseHandler : IQueryHandler<MailExercise, OpenFormExerciseResponse<Mail>>
{
    public Task<OpenFormExerciseResponse<Mail>> HandleAsync(MailExercise query)
    {
        //TODO: format from service.
        string exerciseJsonFormat = "";
        
        //TODO: move it to some service or provider etc..
        var propmpt =
            //$"2. The language of the exercise is {TargetLanguage.Value}.\n" +
            $"2. The mother's language of the student solving the exercise is {query.MotherLanguage}.\n" +
            $"3. The exercise header (with information about exercise - not the exercise.) must be in {(query.ExerciseHeaderInMotherLanguage ? query.MotherLanguage : query.TargetLanguage)}. The header is just basic information about the exercise. Don't confuse the language of the header with the language of the sentences generated. " +
            $" Also include instructions in {(query.ExerciseHeaderInMotherLanguage ? query.MotherLanguage : query.TargetLanguage)} on how to perform the task correctly in the exercise header.\n" +
            //TODO: add more information about language level
            $"4. Language proficiency level is {query.TargetLanguageLevel}. The level of difficulty must be adapted to the exercise being generated. Based on level use appropriately difficult words in sentences.\n";
            
            //$"5. Target audience: {query.TargetAudience}";
        
        if (!string.IsNullOrWhiteSpace(query.TopicsOfSentences))
            propmpt += $"6. The main topic of the sentences in the exercise is/are: {query.TopicsOfSentences}.\n";
        else
            propmpt += $"6. The main topic of the sentences in the exercise is any.\n";
        
        if (!string.IsNullOrWhiteSpace(query.GrammarSection))
            propmpt += $"7. The exercise must be based on the grammatical element - {query.GrammarSection}. Remember to adjust the level of the grammatical element to the level of the exercise. Don't create sentences using other grammatical elements.\n";
        else
            propmpt += $"7. No grammatical elements are imposed top-down in the exercise. However, you can emphasize them keeping in mind the level of language proficiency.\n";

        if (!string.IsNullOrWhiteSpace(query.SupportMaterial))
            propmpt += $"8. In the support material section know these support materials: {query.TopicsOfSentences}.\n";
        else
            propmpt += $"8. In the support material section, generate a short summary that will be useful to the student during the exercise. Don't point out the answer there, only give hints.\n";

        propmpt += $"9. Create a short task title (do not copy it from the prompt).\n";
        propmpt += $"10. Create a short task description (do not copy it from the prompt).\n";
        propmpt += $"11. Create a correct example sentence using both languages of exercise (mother and target).\n";

        propmpt += $"""
                    12. Your responses should be structured in JSON format as follows:
                    {exerciseJsonFormat} ;
                    """;
        
        //TODO: add formatted response
        
        //TODO: add event/rabbit with exercise.
        
        throw new NotImplementedException();
    }
}