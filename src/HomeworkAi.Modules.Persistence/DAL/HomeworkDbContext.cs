using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeworkAi.Modules.Persistence.DAL;

internal sealed class HomeworkDbContext(DbContextOptions<HomeworkDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<MailEntity> MailEntities { get; set; }
    public DbSet<EssayEntity> EssayEntities { get; set; }
    public DbSet<SummaryOfTextEntity> SummaryOfTextEntities { get; set; }

    public DbSet<QuestionsToTextClosedEntity> QuestionsToTextClosedEntities { get; set; }

    public DbSet<PassiveSideClosedEntity> PassiveSideClosedEntities { get; set; }

    public DbSet<ParaphrasingClosedEntity> ParaphrasingClosedEntities { get; set; }

    public DbSet<AnswerToQuestionClosedEntity>
        AnswerToQuestionClosedEntities { get; set; }

    public DbSet<ConditionalClosedEntity> ConditionalClosedEntities { get; set; }

    public DbSet<WordMeaningClosedEntity> WordMeaningClosedEntities { get; set; }

    public DbSet<PhrasalVerbsTranslatingEntity>
        PhrasalVerbsTranslatingEntities { get; set; }

    public DbSet<MissingPhrasalVerbClosedEntity>
        MissingPhrasalVerbClosedEntities { get; set; }

    public DbSet<MissingWordOrExpressionClosedEntity>
        MissingWordOrExpressionClosedEntities { get; set; }


    public DbSet<SentencesTranslationEntity> SentencesTranslationEntities { get; set; }

    public DbSet<SentenceWithVerbToCompleteBasedOnInfinitiveEntity> SentenceWithVerbToCompleteBasedOnInfinitiveEntities
    {
        get;
        set;
    }

    public DbSet<SentenceWithVerbToCompleteEntity> SentenceWithVerbToCompleteEntities { get; set; }
    public DbSet<IrregularVerbsEntity> IrregularVerbsEntities { get; set; }
    public DbSet<QuestionsToTextOpenEntity> QuestionsToTextOpenEntities { get; set; }
    public DbSet<PassiveSideOpenEntity> PassiveSideOpenEntities { get; set; }
    public DbSet<ParaphrasingOpenEntity> ParaphrasingOpenEntities { get; set; }
    public DbSet<AnswerToQuestionOpenEntity> AnswerToQuestionOpenEntities { get; set; }
    public DbSet<ConditionalOpenEntity> ConditionalOpenEntities { get; set; }
    public DbSet<MissingPhrasalVerbOpenEntity> MissingPhrasalVerbOpenEntities { get; set; }
    public DbSet<MissingWordOrExpressionOpenEntity> MissingWordOrExpressionOpenEntities { get; set; }
    public DbSet<WordMeaningOpenEntity> WordMeaningOpenEntities { get; set; }
    public DbSet<SuspiciousPromptEntity> SuspiciousPrompts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}