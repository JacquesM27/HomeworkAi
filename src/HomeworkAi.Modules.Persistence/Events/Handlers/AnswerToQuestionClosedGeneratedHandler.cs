using System.Text.Json;
using HomeworkAi.Infrastructure.Events;
using HomeworkAi.Modules.Contracts.Events.Exercises.ClosedAnswer;
using HomeworkAi.Modules.Persistence.DAL.Entities;
using HomeworkAi.Modules.Persistence.DAL.Repositories;

namespace HomeworkAi.Modules.Persistence.Events.Handlers;

internal sealed class AnswerToQuestionClosedGeneratedHandler(IClosedAnswerExerciseRepository repository)
    : IEventHandler<AnswerToQuestionClosedGenerated>
{
    public Task HandleAsync(AnswerToQuestionClosedGenerated @event)
    {
        var json = JsonSerializer.Serialize(@event.Exercise.Exercise);

        var type = @event.GetType();
        var fullname = type.FullName;
        
        /*
         var type = assemblies.FirstOrDefault(x => x.GetType(route.Type) != null)?
                    .GetType(route.Type);
         */
        
        var mapped = new ClosedAnswerExerciseEntity
        {
            Id = Guid.NewGuid(),
            ExerciseHeaderInMotherLanguage = @event.Exercise.ExerciseHeaderInMotherLanguage,
            MotherLanguage = @event.Exercise.MotherLanguage,
            TargetLanguage = @event.Exercise.TargetLanguage,
            TargetLanguageLevel = @event.Exercise.TargetLanguageLevel,
            TopicsOfSentences = @event.Exercise.TopicsOfSentences,
            GrammarSection = @event.Exercise.GrammarSection,
            AmountOfSentences = @event.Exercise.AmountOfSentences,
            TranslateFromMotherLanguage = @event.Exercise.TranslateFromMotherLanguage,
            QuestionsInMotherLanguage = @event.Exercise.QuestionsInMotherLanguage,
            ZeroConditional = @event.Exercise.ZeroConditional,
            FirstConditional = @event.Exercise.FirstConditional,
            SecondConditional = @event.Exercise.SecondConditional,
            ThirdConditional = @event.Exercise.ThirdConditional,
            DescriptionInMotherLanguage = @event.Exercise.DescriptionInMotherLanguage,
            ExerciseJson = json,
            //ExerciseType = "AnswerToQuestionClosed",
            CheckedByTeacher = false
        };

        return repository.AddAsync(mapped); 
    }
}