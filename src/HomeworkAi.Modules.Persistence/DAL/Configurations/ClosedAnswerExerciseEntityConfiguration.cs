using HomeworkAi.Modules.Persistence.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkAi.Modules.Persistence.DAL.Configurations;

internal sealed class ClosedAnswerExerciseEntityConfiguration
    : IEntityTypeConfiguration<QuestionsToTextClosedEntity>,
        IEntityTypeConfiguration<PassiveSideClosedEntity>,
        IEntityTypeConfiguration<ParaphrasingClosedEntity>,
        IEntityTypeConfiguration<AnswerToQuestionClosedEntity>,
        IEntityTypeConfiguration<ConditionalClosedEntity>,
        IEntityTypeConfiguration<WordMeaningClosedEntity>,
        IEntityTypeConfiguration<PhrasalVerbsTranslatingEntity>,
        IEntityTypeConfiguration<MissingPhrasalVerbClosedEntity>,
        IEntityTypeConfiguration<MissingWordOrExpressionClosedEntity>
{
    public void Configure(EntityTypeBuilder<QuestionsToTextClosedEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<PassiveSideClosedEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ParaphrasingClosedEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<AnswerToQuestionClosedEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<ConditionalClosedEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<WordMeaningClosedEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<PhrasalVerbsTranslatingEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<MissingPhrasalVerbClosedEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    public void Configure(EntityTypeBuilder<MissingWordOrExpressionClosedEntity> builder)
    {
        ConfigureCommonProperties(builder);
    }

    private static void ConfigureCommonProperties<T>(EntityTypeBuilder<T> builder)
        where T : ClosedAnswerExerciseEntity
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ExerciseHeaderInMotherLanguage).IsRequired();
        builder.Property(e => e.MotherLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguage).IsRequired().HasMaxLength(50);
        builder.Property(e => e.TargetLanguageLevel).HasMaxLength(50);
        builder.Property(e => e.TopicsOfSentences).HasMaxLength(500);
        builder.Property(e => e.GrammarSection).HasMaxLength(500);
        builder.Property(e => e.AmountOfSentences);
        builder.Property(e => e.TranslateFromMotherLanguage);
        builder.Property(e => e.QuestionsInMotherLanguage);
        builder.Property(e => e.ZeroConditional);
        builder.Property(e => e.FirstConditional);
        builder.Property(e => e.SecondConditional);
        builder.Property(e => e.ThirdConditional);
        builder.Property(e => e.DescriptionInMotherLanguage);
        builder.Property(e => e.ExerciseJson).HasColumnType("jsonb");
        builder.Property(e => e.CheckedByTeacher).IsRequired();
    }
}