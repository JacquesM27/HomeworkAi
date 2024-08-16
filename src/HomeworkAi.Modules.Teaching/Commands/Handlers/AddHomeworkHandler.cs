using HomeworkAi.Infrastructure.Cache;
using HomeworkAi.Infrastructure.Commands;
using HomeworkAi.Modules.Persistence.DAL.Entities;
using HomeworkAi.Modules.Persistence.DAL.Repositories;
using HomeworkAi.Modules.Teaching.Exceptions;

namespace HomeworkAi.Modules.Teaching.Commands.Handlers;

internal sealed class AddHomeworkHandler(
    ICacheStorage cache, 
    IHomeworkRepository repository,
    IOpenFormExerciseRepository openFormRepository,
    IOpenAnswerExerciseRepository openAnswerRepository,
    IClosedAnswerExerciseRepository closedAnswerRepository,
    IUserRepository userRepository,
    IClassRepository classRepository) 
    : ICommandHandler<AddHomework>
{
    public async Task HandleAsync(AddHomework command)
    {
        var teacher = await userRepository.GetTeacher(command.TeacherId)
                      ?? throw new TeacherNotFoundException(command.TeacherId);
        
        var homeworkClass = await classRepository.Get(command.ClassId) 
                            ?? throw new ClassNotFoundException(command.ClassId);

        var homework = new HomeworkEntity()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Teacher = teacher,
            Class = homeworkClass,
            CreatedDate = command.CreatedDate,
            DueDate = command.DueDate,
            Mails = await openFormRepository.GetMailsAsync(command.MailIds),
            Essays = await openFormRepository.GetEssaysAsync(command.EssayIds),
            SummariesOfTexts = await openFormRepository.GetSummariesOfTextAsync(command.SummaryOfTextIds),
            
            QuestionsToTextsClosed = await closedAnswerRepository.GetQuestionsToTextAsync(command.QuestionsToTextClosedIds),
            PassiveSidesClosed = await closedAnswerRepository.GetPassiveSideAsync(command.PassiveSideClosedIds),
            ParaphrasingsClosed = await closedAnswerRepository.GetParaphrasingAsync(command.ParaphrasingClosedIds),
            AnswersToQuestionsClosed = await closedAnswerRepository.GetAnswerToQuestionAsync(command.AnswersToQuestionsClosedIds),
            ConditionalsClosed = await closedAnswerRepository.GetConditionalAsync(command.ConditionalClosedIds),
            WordMeaningsClosed = await closedAnswerRepository.GetWordMeaningAsync(command.WordMeaningClosedIds),
            PhrasalVerbsTranslatings = await closedAnswerRepository.GetPhrasalVerbsTranslatingAsync(command.PhrasalVerbsTranslatingIds),
            MissingPhrasalVerbsClosed = await closedAnswerRepository.GetMissingPhrasalVerbAsync(command.MissingPhrasalVerbClosedIds),
            MissingWordsOrExperessionsClosed = await closedAnswerRepository.GetMissingWordOrExpressionAsync(command.MissingWordOrExpressionClosedIds)
            
        };

        await repository.AddAsync(homework);
        cache.Set($"teacher_homework:{teacher.Id}", homework.Id);
    }
}
